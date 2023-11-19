#!/usr/bin/sh

cd ".."
dotnet clean
dotnet restore
dotnet build
dotnet run

exit