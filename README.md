# DotnetMigrator

DotnetMigrator is a small tool I created while working on the .NET 7 to .NET 10 upgrade activity.

## Why this tool?

During the migration process, there were several repetitive and manual steps involved.

Without a migrator tool, you would typically have to:

- Manually edit every `.csproj` file  
- Manually update the target framework  
- Upgrade and align NuGet package versions  
- Upgrade Razor-related components where required  
- Identify and fix breaking changes one by one  

To make this process more structured and manageable, this tool was created to automate and support the upgradation.

## What it helps with

- Running the .NET upgrade process  
- Converting projects to SDK-style format  
- Updating the target framework to .NET 10  
- Supporting NuGet package upgrades  
- Assisting with Razor upgrades and cleanup  
- Helping validate the solution after migration  

## How to run

1. Clone the repository  
2. Navigate to the project folder  
3. Run:

   dotnet run -- "< path of the target project folder which need to be upgraded >"

## Note

This tool was built as part of an internal migration exercise and can be extended further based on project needs.
