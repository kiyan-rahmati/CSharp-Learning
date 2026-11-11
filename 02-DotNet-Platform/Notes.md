# Lesson 02: The .NET Platform

## 1. What is .NET?

.NET is a free, open-source development platform created by Microsoft.

It provides the tools, libraries, and runtime environment required to build and run different types of applications.

With .NET, developers can create:

- Web Applications
- Web APIs
- Desktop Applications
- Cloud Applications
- Backend Services
- Mobile Applications

## 2. C# vs .NET

C# and .NET are closely related, but they are not the same thing.

- **C#** is a programming language used to write application code.
- **.NET** is a development platform that provides the tools, libraries, and runtime required to build and execute applications.

In simple terms, C# is the language, while .NET is the platform.

## 3. Common Language Runtime (CLR)

CLR stands for Common Language Runtime.

It is the execution environment for .NET applications.

Its main responsibilities include:

- Memory Management
- Exception Handling
- Garbage Collection
- Code Execution
- Working with the JIT Compiler

### Garbage Collection

Garbage Collection is an automatic memory management mechanism in .NET.

It identifies objects that are no longer being used and reclaims their allocated memory.

This reduces the need for developers to manually manage memory.

## 4. .NET SDK

SDK stands for Software Development Kit.

It provides the tools required to develop .NET applications.

Main responsibilities include:

- Creating projects
- Restoring dependencies
- Building applications
- Compiling source code
- Publishing applications

The .NET SDK also includes the runtime components required for development.

## 5. .NET Runtime

The .NET Runtime provides the environment required to execute .NET applications.

A typical framework-dependent application requires a compatible runtime on the target machine.

The SDK includes the runtime components needed for development and execution.

## 6. IL and JIT Compilation

IL stands for Intermediate Language.

When C# code is compiled, it is translated into IL instead of directly becoming machine code.

The JIT compiler (Just-In-Time Compiler) converts IL into native machine code during execution.

### Compilation Process

```text
C# Source Code
      |
      v
C# Compiler
      |
      v
Intermediate Language (IL)
      |
      v
CLR + JIT Compiler
      |
      v
Native Machine Code
      |
      v
CPU Execution
```

## 7. Important .NET CLI Commands

| Command | Description |
|---|---|
| `dotnet --version` | Displays the installed SDK version |
| `dotnet --list-sdks` | Lists installed .NET SDKs |
| `dotnet --list-runtimes` | Lists installed runtimes |
| `dotnet --info` | Displays detailed .NET environment information |
| `dotnet restore` | Restores project dependencies |
| `dotnet build` | Builds the project |
| `dotnet run` | Builds and runs the application |

## 8. My Development Environment

Operating System: Ubuntu 26.04 LTS

Architecture: Linux x64

Installed .NET SDK: 10.0.403

Installed .NET Runtime: 10.0.14

Installed ASP.NET Core Runtime: 10.0.14

MSBuild Version: 18.9.15

## 9. What I Learned

In this lesson, I learned:

- The difference between C# and .NET.
- The purpose of the CLR.
- How Garbage Collection works.
- The difference between SDK and Runtime.
- What Intermediate Language (IL) is.
- How the JIT compiler works.
- How .NET applications are compiled and executed.
- How to inspect and manage the .NET environment using CLI commands.

## Conclusion

Understanding the .NET platform is an important step toward becoming a professional C# and .NET developer.

These concepts provide the foundation for working with ASP.NET Core, Web APIs, backend development, and software architecture.