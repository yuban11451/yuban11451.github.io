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
$HugoExe = Join-Path $RepoRoot "hugo.exe"

$SourceBranch = (git -C $RepoRoot branch --show-current).Trim()
if ([string]::IsNullOrWhiteSpace($SourceBranch)) {
    throw "Cannot detect source branch."
}

if (-not $SkipBuild) {
    if (Test-Path $HugoExe) {
        Run $HugoExe @("--minify") $RepoRoot
    }
    else {
        Run "hugo" @("--minify") $RepoRoot
    }
}

Run "git" @("add", "-A") $RepoRoot

if (GitHasChanges $RepoRoot) {
    Run "git" @("commit", "-m", $Message) $RepoRoot
}
else {
    Write-Host ""
    Write-Host "No source changes to commit." -ForegroundColor Green
}

Run "git" @("fetch", "origin") $RepoRoot
$RemoteBranch = "origin/$SourceBranch"
$RemoteExists = $false
Push-Location $RepoRoot
try {
    git rev-parse --verify --quiet $RemoteBranch *> $null
    $RemoteExists = ($LASTEXITCODE -eq 0)
}
finally {
    Pop-Location
}

if ($RemoteExists) {
    Run "git" @("pull", "--rebase", "origin", $SourceBranch) $RepoRoot
}
else {
    Write-Host ""
    Write-Host "Remote branch $RemoteBranch does not exist yet; push will create it." -ForegroundColor Yellow
}

Run "git" @("push", "origin", $SourceBranch) $RepoRoot

Write-Host ""
Write-Host "Deploy finished. GitHub Actions will publish the site to main." -ForegroundColor Green
