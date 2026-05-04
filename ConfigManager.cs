using System.Collections.Generic;
using System.IO;
using BepInEx;
using UnityEngine;

namespace MoreTownNames.Config;

public static class ConfigManager
{
	private static List<string> customTownNames;

	public static List<string> GetCustomTownNames()
	{
		if (customTownNames != null)
		{
			return customTownNames;
		}

		customTownNames = new List<string>();
		string configPath = Path.Combine(Paths.ConfigPath, "townnames.txt");

		Debug.Log($"[TownNames] Looking for config at: {configPath}");

		if (!File.Exists(configPath))
		{
			Debug.LogWarning($"[TownNames] Config file not found at {configPath}");
			File.WriteAllText(configPath, "# Add town names below, one per line\n");
			return customTownNames;
		}

		try
		{
			string[] lines = File.ReadAllLines(configPath);
			Debug.Log($"[TownNames] Config file has {lines.Length} lines");

			foreach (string line in lines)
			{
				string trimmed = line.Trim();
				if (!string.IsNullOrEmpty(trimmed) && !trimmed.StartsWith("#"))
				{
					Debug.Log($"[TownNames] Adding name: {trimmed}");
					customTownNames.Add(trimmed);
				}
			}
			Debug.Log($"[TownNames] Loaded {customTownNames.Count} custom town names");
		}
		catch (System.Exception ex)
		{
			Debug.LogError($"[TownNames] Error loading config: {ex.Message}");
		}

		return customTownNames;
	}
}

