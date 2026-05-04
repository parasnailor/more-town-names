using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Eremite.Services;

namespace MoreTownNames.Patches;

[HarmonyPatch(typeof(WorldStateService), nameof(WorldStateService.GetTownsNamesKeysLeft))]
public class WorldStateServicePatch
{
	[HarmonyPostfix]
	public static void GetTownsNamesKeysLeftPostfix(ref List<string> __result)
	{
		List<string> customNames = Config.ConfigManager.GetCustomTownNames();
		if (customNames.Count > 0)
		{
			__result.AddRange(customNames);
			__result.Shuffle();
		}
	}
}
