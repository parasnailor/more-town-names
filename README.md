# More Town Names
A mod for [Against the Storm](https://store.steampowered.com/app/1336490/Against_the_Storm/) that adds more town names to the random name pool used during embarkation.

# Usage
The mod adds a list of about 200 names to the pool. To add more names (or remove ones added by the mod), open `BepInEx/config/MoreTownNames.cfg`, find `CustomTownNames`, and set the name list as a comma-separated string:

```
[General]
## Comma-separated list of custom town names.
# Setting type: String
# Default value: ...
CustomTownNames = Emberwatch,Stonehaven,Dunhold,Ashenvale,Ironholm...
```

# Installation
### Thunderstore (Preferred)
Install from the [store page.](https://thunderstore.io/c/against-the-storm/p/snaildev/MoreTownNames/)

### Manual
Build the mod from source, then copy `MoreTownNames.dll` into `/BepInEx/plugins/MoreTownNames/` (create the directory if it doesn't exist).

# Development
### Building
1. Copy `<game dir>/Against The Storm_Data/Managed/Assembly-CSharp.dll` to the project root
2. `dotnet build -c release MoreTownNames.csproj`

There is a post-build step to automatically create the zip archive for thunderstore. This works on Linux and should work on OSX / Unix systems. Windows lacks the `zip` command, so some modification would be needed for Windows. 
