#!/usr/bin/sh

# src: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
# dotnet tool install --global dotnet-ef

# myusername=$(whoami)

# if [ -e "C:\\Users\\$myusername\\LCPDB.mdf" ] then
#     rm -rf "C:\\Users\\$myusername\\LCPDB.mdf"
# end

# if [ -e "C:\\Users\\$myusername\\LCPDB_log.ldf" ] then
#     rm -rf "C:\\Users\\$myusername\\LCPDB_log.ldf"
# end

dotnet tool update --global dotnet-ef

cd ".."
dotnet ef database drop --force
dotnet ef migrations remove --force
dotnet ef migrations add InitialCreate
dotnet ef database update

exit