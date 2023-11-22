#!/usr/bin/sh

# src: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
# dotnet tool install --global dotnet-ef

clear

myusername=$(whoami)

if [[ -e "C:\\Users\\$myusername\\LCPDB.mdf" ]]; then
    rm -f "C:\\Users\\$myusername\\LCPDB.mdf"
fi

if [[ -e "C:\\Users\\$myusername\\LCPDB_log.ldf" ]]; then
    rm -f "C:\\Users\\$myusername\\LCPDB_log.ldf"
fi

cd ..
dotnet tool update --global dotnet-ef
dotnet ef database drop --force
dotnet ef migrations remove --force
dotnet ef migrations add InitialCreate
dotnet ef database update

exit