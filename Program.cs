using System.Diagnostics;
using System.Linq;

if (args.Length == 0)
{
    Console.WriteLine("Usage:");
    Console.WriteLine("  dotnet-migrator migrate <project-path>");
    return;
}

var command = args[0];

if (command == "migrate")
{
    if (args.Length < 2)
    {
        Console.WriteLine("Please provide project path.");
        return;
    }

    // Handles paths with spaces
    var projectPath = string.Join(" ", args.Skip(1));

    Console.WriteLine($"PATH RECEIVED: [{projectPath}]");

    if (!Directory.Exists(projectPath))
    {
        Console.WriteLine("Invalid project path.");
        return;
    }

    Console.WriteLine($"Starting migration for: {projectPath}");
    RunMigration(projectPath);
}
else
{
    Console.WriteLine("Unknown command.");
}

void RunMigration(string path)
{
    Console.WriteLine("Analyzing project...");
    Console.WriteLine("Scanning directory: " + path);

    var slnFiles = Directory.GetFiles(path, "*.sln", SearchOption.AllDirectories);
    var csprojFiles = Directory.GetFiles(path, "*.csproj", SearchOption.AllDirectories);

    string? projectToBuild = null;

    if (slnFiles.Length > 0)
    {
        projectToBuild = slnFiles[0];
        Console.WriteLine($"Solution detected: {projectToBuild}");
    }
    else if (csprojFiles.Length > 0)
    {
        projectToBuild = csprojFiles[0];
        Console.WriteLine($"Project detected: {projectToBuild}");
    }
    else
    {
        Console.WriteLine("❌ No .sln or .csproj found.");
        return;
    }

    Console.WriteLine("Running Upgrade Assistant...");
    RunCommand("upgrade-assistant", $"upgrade \"{projectToBuild}\"", path);

    Console.WriteLine("Building project...");
    RunCommand("dotnet", $"build \"{projectToBuild}\"", path);

    Console.WriteLine("Migration process completed.");
}

void RunCommand(string fileName, string arguments, string workingDirectory)
{
    var process = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = fileName,
            Arguments = arguments,
            WorkingDirectory = workingDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        }
    };

    process.Start();

    string output = process.StandardOutput.ReadToEnd();
    string error = process.StandardError.ReadToEnd();

    process.WaitForExit();

    Console.WriteLine(output);
    Console.WriteLine(error);
}
