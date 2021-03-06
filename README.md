# example-mvc5-application
This is an example ASP.NET MVC 5 Web API 2 application with AutoFac for IoC. I wanted to create an example application to demonstrate the way I develop web applications using Microsoft technologies. The Web API application is called RESTful Radio API.

**Used the following NuGet packages:**

- NUnit 3
- Moq
- BDD based on NUnit 3
- SpecFlow 2 for acceptance testing
- SpecFlow.NUnit
- AutoFac for Inversion of Control using the Dependency Injection and Service Locator pattern
- AutoFac.MVC5
- Owin
- AutoFac.Owin
- Microsoft.Owin.Testing for running the Open Web Interface for .NET inside SpecFlow
- ASP.NET MVC 5
- ASP.NET Web API 2 for the RESTful endpoints
- Swashbuckle Swagger
- Newtonsoft.Json
- Entity Framework 6
- FluentMigrator
- FluentMigrator.Tools

**Used the following products and development tools:**

- C# 6.0
- Visual Studio 2015 Community Edition
- SQL Server 2014 Express Edition
- .NET Framework 4.5.2
- JetBrains ReSharper 10
- ReSharper.StyleCop extension
- StyleCop
- ReSharper Cyclomatic Complexity extension
- CodeMaid Visual Studio extension
- Entity Framework Reverse POCO generator
- T4 Toolbox for Visual Studio 2015

**ReSharper**

I have also included my ReSharper templates for generating migrations and unit-test classes.

**Please use the _CreateExampleDatabase.sql script in the ExampleApplication.Database project to create the database before compiling/running the database migrations.**

ExampleApplication.Database has the following MSBuild Task added to the .csproj file to run database migrations every time the project is compiled. All the SQL files bar _CreateExampleDatabase.sql are set as Embedded Resource so FluentMigrator can find them.

```xml
<UsingTask TaskName="FluentMigrator.MSBuild.Migrate" AssemblyFile="..\packages\FluentMigrator.Tools.1.6.1\tools\AnyCPU\40\FluentMigrator.MSBuild.dll" />
<Target Name="AfterBuild">
  <Migrate Database="SqlServer2014" Connection="ExampleDatabase" Target=".\bin\ExampleApplication.Database.dll">
  </Migrate>
</Target>
```

Thanks for checking it out. I hope it helps to serve as an example on how to develop RESTful applications using AutoFac, Web API 2 and FluentMigrator.

Kind regards  
Raf
