#!/usr/bin/sh

# src: https://learn.microsoft.com/pt-br/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio-code#scaffold-a-controller

dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet tool uninstall -g dotnet-aspnet-codegenerator
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet tool update -g dotnet-aspnet-codegenerator

exit