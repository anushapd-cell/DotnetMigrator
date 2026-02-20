# DotnetMigrator

DotnetMigrator is a small tool I created while working on the .NET 7 to .NET 10 upgrade activity.

## Why this tool?

During the migration process, there were multiple repetitive steps involved in upgrading projects and validating changes. This tool was created to simplify,autommate and organize that process.

## What it helps with

- Running the .NET upgrade process
- Converting projects to SDK-style format
- Updating the target framework
- Supporting cleanup during migration

## How to run

1. Clone the repository  
2. Navigate to the project folder  
3. Run:

   dotnet run -- "<path-to-solution>" [the path of the target project which needs to be upgraded.

## Note

This was built as part of an internal migration exercise and can be extended further if needed.
