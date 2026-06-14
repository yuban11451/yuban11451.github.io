using System.Diagnostics;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

var repoRoot = FindRepoRoot(AppContext.BaseDirectory);
if (repoRoot is null)
{
    Fail("没有找到 Git 仓库。请把这个程序放在博客仓库目录里运行。");
    return 1;
}

WriteHeader("一键推送博客");
WriteInfo($"仓库目录: {repoRoot}");

var branch = (await Capture("git", "branch --show-current", repoRoot)).Trim();
if (string.IsNullOrWhiteSpace(branch))
{
    Fail("没有检测到当前分支。");
    return 1;
}

WriteInfo($"当前分支: {branch}");

var hugoPath = Path.Combine(repoRoot, "hugo.exe");
var hasHugoExe = File.Exists(hugoPath);
var hugoCommand = hasHugoExe ? hugoPath : "hugo";
WriteStep("检查 Hugo 构建");
if (!await Run(hugoCommand, "--minify", repoRoot))
{
    Fail("Hugo 构建失败，已停止推送。请先修复上面的错误。");
    return 1;
}

WriteStep("暂存所有改动");
if (!await Run("git", "add -A", repoRoot))
{
    Fail("git add 失败。");
    return 1;
}

var stagedStatus = await Capture("git", "diff --cached --name-status", repoRoot);
if (string.IsNullOrWhiteSpace(stagedStatus))
{
    WriteSuccess("没有需要提交的改动。");
    Pause();
    return 0;
}

WriteInfo("本次将提交:");
Console.WriteLine(stagedStatus.Trim());

var message = args.Length > 0
    ? string.Join(' ', args).Trim()
    : $"Update blog {DateTime.Now:yyyy-MM-dd HH:mm:ss}";

WriteStep($"提交: {message}");
if (!await Run("git", $"commit -m \"{EscapeArgument(message)}\"", repoRoot))
{
    Fail("git commit 失败。");
    return 1;
}

WriteStep($"推送到 origin/{branch}");
if (!await Run("git", $"push origin {branch}", repoRoot))
{
    Fail("git push 失败。请检查网络、GitHub 登录状态或远端权限。");
    return 1;
}

WriteSuccess("推送完成。GitHub Actions 会自动构建并发布博客。");
Pause();
return 0;

static string? FindRepoRoot(string startPath)
{
    var dir = new DirectoryInfo(startPath);
    while (dir is not null)
    {
        if (Directory.Exists(Path.Combine(dir.FullName, ".git")))
        {
            return dir.FullName;
        }

        dir = dir.Parent;
    }

    return null;
}

static async Task<bool> Run(string fileName, string arguments, string workingDirectory)
{
    var result = await RunProcess(fileName, arguments, workingDirectory, captureOutput: false);
    return result.ExitCode == 0;
}

static async Task<string> Capture(string fileName, string arguments, string workingDirectory)
{
    var result = await RunProcess(fileName, arguments, workingDirectory, captureOutput: true);
    return result.Output;
}

static async Task<ProcessResult> RunProcess(string fileName, string arguments, string workingDirectory, bool captureOutput)
{
    using var process = new Process();
    process.StartInfo = new ProcessStartInfo
    {
        FileName = fileName,
        Arguments = arguments,
        WorkingDirectory = workingDirectory,
        UseShellExecute = false,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        StandardOutputEncoding = Encoding.UTF8,
        StandardErrorEncoding = Encoding.UTF8
    };

    var output = new StringBuilder();

    process.OutputDataReceived += (_, e) =>
    {
        if (e.Data is null)
        {
            return;
        }

        if (captureOutput)
        {
            output.AppendLine(e.Data);
        }
        else
        {
            Console.WriteLine(e.Data);
        }
    };

    process.ErrorDataReceived += (_, e) =>
    {
        if (e.Data is null)
        {
            return;
        }

        if (captureOutput)
        {
            output.AppendLine(e.Data);
        }
        else
        {
            Console.Error.WriteLine(e.Data);
        }
    };

    try
    {
        process.Start();
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine(ex.Message);
        return new ProcessResult(-1, output.ToString());
    }

    process.BeginOutputReadLine();
    process.BeginErrorReadLine();
    await process.WaitForExitAsync();

    return new ProcessResult(process.ExitCode, output.ToString());
}

static string EscapeArgument(string value)
{
    return value.Replace("\\", "\\\\").Replace("\"", "\\\"");
}

static void WriteHeader(string text)
{
    Console.WriteLine("========================================");
    Console.WriteLine(text);
    Console.WriteLine("========================================");
}

static void WriteStep(string text)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine();
    Console.WriteLine($"> {text}");
    Console.ResetColor();
}

static void WriteInfo(string text)
{
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine(text);
    Console.ResetColor();
}

static void WriteSuccess(string text)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine();
    Console.WriteLine(text);
    Console.ResetColor();
}

static void Fail(string text)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine();
    Console.WriteLine(text);
    Console.ResetColor();
    Pause();
}

static void Pause()
{
    Console.WriteLine();
    Console.Write("按 Enter 退出...");
    Console.ReadLine();
}

internal sealed record ProcessResult(int ExitCode, string Output);
