#!/usr/bin/sh

# src: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli

cd ".."
dotnet tool install --global dotnet-ef
dotnet ef migrations remove
dotnet ef migrations add InitialCreate
dotnet ef database update

exit