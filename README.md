# Sawyer's Console Template

This repo is a template for the .NET SDK to make a slightly more batteries
included console csproj, subject to my preferences.

This is a companion to
[A Beginner's Guide to .NET's HostBuilder](https://medium.com/@sawyer.watts/a-beginners-guide-to-net-s-hostbuilder-part-0-78882aab60f8).

## Installation

Here are the steps in bash:

```sh
template_dir=~/.dotnetTemplates/SawyerCSharpConsole
git clone https://github.com/sawyerwatts/SawyerCSharpConsole.git $template_dir
rm -rf $template_dir/.git
rm $template_dir/.gitignore
rm $template_dir/.editorconfig
rm $template_dir/README.md
rm $template_dir/LICENSE
dotnet new install $template_dir
```

Here are the steps in PowerShell:

```ps1
$templateDir="$env:USERPROFILE\.dotnetTemplates\SawyerCSharpConsole"
git clone https://github.com/sawyerwatts/SawyerCSharpConsole.git $templateDir
rm $templateDir\.git -r -force
rm $templateDir\.gitignore
rm $templateDir\.editorconfig
rm $templateDir\README.md
rm $templateDir\LICENSE
dotnet new install $templateDir
```

## Uninstallation

Here are the steps in bash:

```sh
template_dir=~/.dotnetTemplates/SawyerCSharpConsole
dotnet new uninstall $template_dir
rm -rf $template_dir
```

Here are the steps in PowerShell:

```ps1
$templateDir="$env:USERPROFILE\.dotnetTemplates\SawyerCSharpConsole"
dotnet new uninstall $templateDir
rm $templateDir -r -force
```

## Features

1. This uses the `Worker` SDK, so it has access to the `HostApplicationBuilder`,
allowing easy dependency injection and access to the `appsettings*.json` files.
2. This comes pre-baked with Serilog configured as the implementation to the
built in `ILogger<T>`, and these settings are controlled via the
`appsettings*.json` files. Serilog is configured to buffer file writes and to
write file and console logs via a background thread.
3. `Program` supplies a `CancellationToken` to `Driver.RunAsync`, and it will
mimic the functionality that the various web/app hosts supply when managing
long-running applications: interrupt signals are captured by the host, the host
will update the `CancellationToken` so the app can gracefully shut down, and if
the app doesn't close in five seconds, then the app will be forcefully closed.
4. `Driver` has `Settings` and `RegisterTo`, an easy reminder how to best
register settings POCOs with validation on startup.
