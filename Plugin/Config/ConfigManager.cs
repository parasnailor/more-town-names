using System.Collections.Generic;
using System.IO;
using BepInEx;
using UnityEngine;

namespace TownNamesMod.Config;

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

		if (!File.Exists(configPath))
		{
			Debug.LogWarning($"[TownNames] Config file not found at {configPath}. Creating empty config.");
			File.WriteAllText(configPath, "# Add town names below, one per line\n");
			return customTownNames;
		}

		try
		{
			string[] lines = File.ReadAllLines(configPath);
			foreach (string line in lines)
			{
				string trimmed = line.Trim();
				if (!string.IsNullOrEmpty(trimmed) && !trimmed.StartsWith("#"))
				{
					customTownNames.Add(trimmed);
				}
			}
			Debug.Log($"[TownNames] Loaded {customTownNames.Count} custom town names from config");
		}
		catch (System.Exception ex)
		{
			Debug.LogError($"[TownNames] Error loading config: {ex.Message}");
		}

		return customTownNames;
	}
}
