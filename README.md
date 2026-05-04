# Against the Storm - Town Names Mod

A BepInEx mod that adds custom town names to Against the Storm's random town name pool during embarkation.

## Features

- Add unlimited custom town names via a simple text configuration file
- Names are merged with the game's default town names
- Easy to customize without recompiling the mod
- Comments supported in the config file

## Installation

1. **Install BepInEx** (if not already installed)
   - Download BepInEx for Unity games from https://github.com/BepInEx/BepInEx/releases
   - Extract to your Against the Storm game directory
   - Run the game once to generate the BepInEx folder structure

2. **Build the mod**
   ```bash
   dotnet build -c Release
   ```

3. **Copy the DLL**
   - Find `MoreTownNames.dll` in the `bin/Release/net472` directory
   - Copy it to `<GameDir>/BepInEx/plugins/`

4. **Add custom town names**
   - Copy `Config/townnames.txt` to `<GameDir>/BepInEx/config/townnames.txt`
   - Edit the file to add your custom town names (one per line)
   - Lines starting with `#` are treated as comments

## Configuration

Edit `<GameDir>/BepInEx/config/townnames.txt`:

```
# Your custom town names here
MyTownName
AnotherTown
# This is a comment and will be ignored
YetAnotherTown
```

- One name per line
- Names are case-sensitive
- Lines starting with `#` are comments
- Empty lines are ignored
- The config file is loaded at game startup

## How It Works

1. When you embark on a new game, the mod intercepts the town name generation
2. Your custom names from `townnames.txt` are added to the game's default pool
3. When the random button is clicked, it can now select from both default and custom names
4. All names are shuffled to ensure variety

## Building from Source

### Requirements
- .NET SDK 6.0+ or Visual Studio 2019+
- Against the Storm game (for Assembly-CSharp.dll)

### Setup

1. **Get the game assembly:**
   ```bash
   ./setup.sh
   ```
   
   Or manually copy it:
   ```bash
   cp "<GameDir>/Against the Storm_Data/Managed/Assembly-CSharp.dll" .
   ```

2. **Build the mod:**
   ```bash
   ./package.sh
   ```

The script automatically downloads BepInEx/Harmony from NuGet, so you don't need to manually manage those.

## Troubleshooting

**Names not appearing:**
- Check that `townnames.txt` is in the correct location (`BepInEx/config/`)
- Verify BepInEx console shows "Town Names Mod patches applied successfully!"
- Ensure custom names aren't empty or only comments

**Build errors:**
- Update the `.csproj` file to point to your actual game assembly locations
- Ensure you have the correct .NET Framework version installed

## License

Feel free to modify and distribute this mod.
