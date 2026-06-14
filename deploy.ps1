param(
    [string]$Message = "Update blog $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')",
    [switch]$SkipBuild
)

$ErrorActionPreference = "Stop"

function Run {
    param(
        [string]$Command,
        [string[]]$Arguments,
        [string]$WorkingDirectory
    )

    Write-Host ""
    Write-Host "> $Command $($Arguments -join ' ')" -ForegroundColor Cyan
    Push-Location $WorkingDirectory
    try {
        & $Command @Arguments
        if ($LASTEXITCODE -ne 0) {
            throw "Command failed with exit code $LASTEXITCODE"
        }
    }
    finally {
        Pop-Location
    }
}

function GitHasChanges {
    param([string]$WorkingDirectory)

    Push-Location $WorkingDirectory
    try {
        $status = git status --porcelain
        if ($LASTEXITCODE -ne 0) {
            throw "git status failed"
        }

        return -not [string]::IsNullOrWhiteSpace(($status -join ""))
    }
    finally {
        Pop-Location
    }
}

$RepoRoot = $PSScriptRoot
$PublicDir = Join-Path $RepoRoot "public"
$HugoExe = Join-Path $RepoRoot "hugo.exe"

if (-not (Test-Path $PublicDir)) {
    throw "Cannot find public directory: $PublicDir"
}

if (-not $SkipBuild) {
    if (Test-Path $HugoExe) {
        Run $HugoExe @("--minify") $RepoRoot
    }
    else {
        Run "hugo" @("--minify") $RepoRoot
    }
}

Run "git" @("fetch", "origin") $PublicDir
Run "git" @("pull", "--ff-only", "origin", "main") $PublicDir

if (GitHasChanges $PublicDir) {
    Run "git" @("add", "-A") $PublicDir
    Run "git" @("commit", "-m", $Message) $PublicDir
    Run "git" @("push", "origin", "main") $PublicDir
}
else {
    Write-Host ""
    Write-Host "No public changes to commit." -ForegroundColor Green
}

Run "git" @("add", "-A") $RepoRoot

if (GitHasChanges $RepoRoot) {
    $SourceBranch = (git -C $RepoRoot branch --show-current).Trim()
    if ([string]::IsNullOrWhiteSpace($SourceBranch)) {
        throw "Cannot detect source branch."
    }

    Run "git" @("commit", "-m", $Message) $RepoRoot
    Run "git" @("push", "origin", $SourceBranch) $RepoRoot
}
else {
    Write-Host ""
    Write-Host "No source changes to commit." -ForegroundColor Green
}

Write-Host ""
Write-Host "Deploy finished." -ForegroundColor Green
