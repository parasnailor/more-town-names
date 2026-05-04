using System.Collections.Generic;
using HarmonyLib;
using Eremite.Services;
using TownNamesMod;

namespace MoreTownNames.Patches;

[HarmonyPatch(typeof(WorldStateService), nameof(WorldStateService.GetTownsNamesKeysLeft))]
public class WorldStateServicePatch
{
	[HarmonyPostfix]
	public static void GetTownsNamesKeysLeftPostfix(ref List<string> __result)
	{
		var customNames = NameProvider.GetCustomNames();
		if (customNames.Count > 0)
		{
			__result.AddRange(customNames);
			__result.Shuffle();
		}
	}
}
