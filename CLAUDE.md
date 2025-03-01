# HADotNet Development Guide

## Build & Test Commands
- Build solution: `dotnet build HADotNet.sln`
- Run all tests: `dotnet test HADotNet.Core.Tests/HADotNet.Core.Tests.csproj`
- Run specific test: `dotnet test HADotNet.Core.Tests/HADotNet.Core.Tests.csproj --filter "FullyQualifiedName=HADotNet.Core.Tests.<TestClass>.<TestMethod>"`
- Before running tests, set environment variables:
  - `HADotNet_Tests_Instance` = Home Assistant URL
  - `HADotNet_Tests_ApiKey` = API key

## Code Style Guidelines
- **Naming**: PascalCase for classes, methods, properties; verb-noun pattern for methods
- **Imports**: System namespaces first, third-party next, project-specific last; alphabetical within groups
- **Documentation**: XML comments on all public members using `<summary>`, `<param>`, `<returns>`, etc.
- **Error Handling**: Custom exceptions for specific cases; `EnsureSuccessStatusCode()`; null checks
- **Types**: Use generics with constraints; property auto-implementation; strongly-typed models
- **Client Pattern**: Inherit from BaseClient; use ClientFactory for instantiation; async/await pattern
- **HTTP Conventions**: Separate methods for GET/POST/DELETE; proper serialization/deserialization
- Follow Microsoft C# coding guidelines; maintain consistency with existing code

Requires .NET Core SDK 2.1+