using System.Collections.Generic;
using HarmonyLib;
using Eremite.Services;
using TownNamesMod;
using System.Linq;

namespace MoreTownNames.Patches;

[HarmonyPatch(typeof(WorldStateService), "GetCitiesNamesKeys")]
public class WorldStateServicePatch
{
	[HarmonyPostfix]
	public static void GetCitiesNamesKeysPostfix(ref string[] __result)
	{
		var customNames = NameProvider.GetCustomNames();

        if (customNames == null || customNames.Count == 0)
            return;

        // Convert to mutable collection
        var result = __result?.ToList() ?? new List<string>();

        result.AddRange(customNames);

        // remove duplicates
        result = result.Distinct().ToList();

        result.Shuffle();

        __result = result.ToArray();
	}
}
