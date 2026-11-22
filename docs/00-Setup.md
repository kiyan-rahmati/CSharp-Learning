# Setup (do this once, ideally while you still have internet)

## 1. Install the .NET SDK
The SDK contains the compiler, the `dotnet` command, and ASP.NET Core. You need the **SDK**, not just the runtime.

**Ubuntu / Debian** (package names vary by version; if one fails, check Microsoft's install page for your release):
```bash
sudo apt update
sudo apt install dotnet-sdk-8.0      # or dotnet-sdk-9.0 / dotnet-sdk-10.0 if available
dotnet --version
```
**Windows / macOS**: download the installer from dotnet.microsoft.com.

**Fully offline install**: download the SDK tarball/installer on a machine with internet, copy it over, and install it from the file.

## 2. Tell the lessons which version you have
Open `Directory.Build.props` and set `<TargetFramework>`:
| `dotnet --version` | TargetFramework |
|---|---|
| 8.x | `net8.0` |
| 9.x | `net9.0` |
| 10.x | `net10.0` |

Then verify everything builds:
```bash
./check-all.sh
```

## 3. Editor
- **VS Code** + the extension *C# Dev Kit* (gives IntelliSense, debugging, test explorer). Install the extension while online; extensions are cached afterwards.
- Alternatives: JetBrains Rider, Visual Studio (Windows).

## 4. Everyday `dotnet` commands
| Command | What it does |
|---|---|
| `dotnet new console -n MyApp` | create a console project |
| `dotnet run` | compile and run the project in the current folder |
| `dotnet run --project path` | run a specific project |
| `dotnet build` | compile only |
| `dotnet watch run` | re-run automatically when files change |
| `dotnet clean` | delete build output |
| `dotnet new sln` / `dotnet sln add path` | create / extend a solution |
| `dotnet add package Name` | add a NuGet package (needs internet the first time) |
| `dotnet test` | run unit tests |
| `dotnet --info` | show SDK and runtime details |

Create one solution that contains all lessons (optional):
```bash
dotnet new sln -n CSharpLearning
dotnet sln add */*.csproj
```

## 5. Working offline: what to know
- Everything in lessons **01-22 uses only the SDK**, so no packages are downloaded.
- Packages (EF Core, xUnit, Swagger...) come from NuGet. The **first** restore needs internet; afterwards they live in `~/.nuget/packages` and work offline. So before going offline, create a throwaway project that references the packages you plan to use and run `dotnet restore`.
- Docs offline: `dotnet --help`, `dotnet <command> --help`, and IntelliSense hovers in your editor show method documentation without internet.

## 6. Debugging basics
1. Click left of a line number in VS Code to set a **breakpoint** (red dot).
2. Press **F5** to run with the debugger.
3. **F10** step over, **F11** step into, **Shift+F11** step out, hover variables to see values.
Debugging is the fastest way to understand what code *really* does. Use it constantly.
