# TestServerPlayground-BlogPost

## dotnet setup commands

cd C:\SourceCode

mkdir TestServerPlayground

cd TestServerPlayground

dotnet new --help

dotnet new webapp --name TestServerPlayground
dotnet new nunit --name TestServerPlayground.Tests

dotnet new sln --name TestServerPlayground

dotnet sln add .\TestServerPlayground\TestServerPlayground.csproj
dotnet sln add .\TestServerPlayground.Tests\TestServerPlayground.Tests.csproj

## NuGet Packages

Microsoft.AspNetCore.Mvc.Testing

## Steps

### Step 1 - Calling a in-proc mocked server

SetUpFixture
OneTimeSetUp -> Setup the HostBuilder

add using statements

### Step 2 - Calling the actual Startup for your WebApp

- Add an API to TestServerPlayground
  - Microsoft.AspNet.WebApi

- Add reference to TestServerPlayground

## Code Snippets



## Documentation Links

https://github.com/Microsoft/vstest-docs/blob/master/RFCs/0001-Test-Platform-Architecture.md

https://github.com/Microsoft/vstest-docs/blob/master/RFCs/0005-Test-Platform-SDK.md