# More Town Names
A mod that adds more town names to the random name pool used during embarkation.

# Usage
The mod adds a list of about 200 names to the pool. To add more names (or remove ones added by the mod), open `BepInEx/config/MoreTownNames.cfg`, find `CustomTownNames`, and set the name list as a comma-separated string:

```
[General]
## Comma-separated list of custom town names.
# Setting type: String
# Default value: ...
CustomTownNames = Emberwatch,Stonehaven,Dunhold,Ashenvale,Ironholm...
```

# Known Issues
Currently, the new town names will not be available in the random name pool until a new cycle has begun. This limitation is due to how the game tracks unused town names for each cycle, refreshing the list of available town names only at the beginning of a new cycle.

# AI Disclosure
ChatGPT was used to generate the thunderstore icon and some of the town names.