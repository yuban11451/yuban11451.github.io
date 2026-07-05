using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

Console.OutputEncoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
Console.InputEncoding = Encoding.UTF8;

var repoRoot = FindRepoRoot(AppContext.BaseDirectory) ?? FindRepoRoot(Environment.CurrentDirectory);
if (repoRoot is null)
{
    Fail("Git repository was not found. Put this program in the blog repository and run it again.");
    return 1;
}

WriteHeader("Blog one-click push");
WriteInfo($"Repository: {repoRoot}");

var branch = (await Capture("git", repoRoot, "branch", "--show-current")).Trim();
if (string.IsNullOrWhiteSpace(branch))
{
    Fail("Current Git branch was not detected.");
    return 1;
}

WriteInfo($"Branch: {branch}");

var message = args.Length > 0
    ? string.Join(' ', args).Trim()
    : $"Update blog {DateTime.Now:yyyy-MM-dd HH:mm:ss}";

WriteStep("Set post drafts to published");
var publishedCount = PublishAllPosts(repoRoot);
WriteInfo(publishedCount == 0
    ? "No draft posts were found."
    : $"Published {publishedCount} draft post(s).");

var hugoPath = Path.Combine(repoRoot, "hugo.exe");
var hugoCommand = File.Exists(hugoPath) ? hugoPath : "hugo";

WriteStep("Build Hugo site");
if (!await Run(hugoCommand, repoRoot, "--minify"))
{
    Fail("Hugo build failed. Fix the build errors above and run the push again.");
    return 1;
}

WriteStep("Stage blog source changes");
if (!await Run("git", repoRoot, "add", "-A"))
{
    Fail("git add failed.");
    return 1;
}

var stagedStatus = await Capture("git", repoRoot, "diff", "--cached", "--name-status");
if (!string.IsNullOrWhiteSpace(stagedStatus))
{
    WriteInfo("Files to commit:");
    Console.WriteLine(stagedStatus.Trim());

    WriteStep($"Commit: {message}");
    if (!await Run("git", repoRoot, "commit", "-m", message))
    {
        Fail("git commit failed.");
        return 1;
    }
}
else
{
    WriteInfo("No new source changes to commit.");
}

WriteStep("Sync remote branch");
if (!await Run("git", repoRoot, "fetch", "origin"))
{
    Fail("git fetch failed. Check network access, GitHub login, or repository permission.");
    return 1;
}

var remoteBranchExists = (await Capture("git", repoRoot, "rev-parse", "--verify", "--quiet", $"origin/{branch}")).Trim();
if (!string.IsNullOrWhiteSpace(remoteBranchExists))
{
    if (!await Run("git", repoRoot, "pull", "--rebase", "origin", branch))
    {
        Fail("git pull --rebase failed. Resolve the conflict manually, then run the push again.");
        return 1;
    }
}
else
{
    WriteInfo($"Remote branch origin/{branch} does not exist yet; it will be created by push.");
}

WriteStep($"Push to origin/{branch}");
if (!await Run("git", repoRoot, "push", "origin", branch))
{
    Fail("git push failed. Check network access, GitHub login, or repository permission.");
    return 1;
}

WriteSuccess("Push finished. GitHub Actions will build and publish the site to the main branch.");
Pause();
return 0;

static int PublishAllPosts(string repoRoot)
{
    var postDir = Path.Combine(repoRoot, "content", "post");
    if (!Directory.Exists(postDir))
    {
        return 0;
    }

    var changed = 0;
    foreach (var file in Directory.EnumerateFiles(postDir, "*.md", SearchOption.AllDirectories))
    {
        var text = File.ReadAllText(file, Encoding.UTF8);
        var updated = Regex.Replace(
            text,
            @"(?m)^(\s*draft\s*[:=]\s*)true(\s*)$",
            "${1}false$2",
            RegexOptions.IgnoreCase);

        if (updated == text)
        {
            continue;
        }

        File.WriteAllText(file, updated, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
        changed++;
    }

    return changed;
}

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

static async Task<bool> Run(string fileName, string workingDirectory, params string[] arguments)
{
    var result = await RunProcess(fileName, workingDirectory, captureOutput: false, arguments);
    return result.ExitCode == 0;
}

static async Task<string> Capture(string fileName, string workingDirectory, params string[] arguments)
{
    var result = await RunProcess(fileName, workingDirectory, captureOutput: true, arguments);
    return result.Output;
}

static async Task<ProcessResult> RunProcess(
    string fileName,
    string workingDirectory,
    bool captureOutput,
    params string[] arguments)
{
    using var process = new Process();
    process.StartInfo = new ProcessStartInfo
    {
        FileName = fileName,
        WorkingDirectory = workingDirectory,
        UseShellExecute = false,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        StandardOutputEncoding = Encoding.UTF8,
        StandardErrorEncoding = Encoding.UTF8
    };

    foreach (var argument in arguments)
    {
        process.StartInfo.ArgumentList.Add(argument);
    }

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

static void WriteHeader(string text)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("========================================");
    Console.WriteLine(text);
    Console.WriteLine("========================================");
    Console.ResetColor();
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
    Console.Write("Press Enter to exit...");
    Console.ReadLine();
}

internal sealed record ProcessResult(int ExitCode, string Output);
