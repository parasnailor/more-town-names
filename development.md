# Dump Game Assemblies with ilspycmd
`ilspycmd -p "<steam dir>/steamapps/common/Against the Storm/Against the Storm_Data/Managed/Assembly-CSharp.dll" -o ./dump/`

# Building
1. `export StormPath=<path to game data folder>`
2. `dotnet build -c release MoreTownNames.csproj`
