using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace TownNamesMod;

[BepInPlugin("com.wes.againstthestorm.townnames", "Town Names Mod", "1.0.0")]
public class TownNamesPlugin : BaseUnityPlugin
{
	private Harmony harmonyInstance;

	private void Start()
	{
		Logger.LogInfo("Town Names Mod loading...");

		try
		{
			harmonyInstance = new Harmony("com.wes.againstthestorm.townnames");
			harmonyInstance.PatchAll(typeof(Patches.WorldStateServicePatch));
			Logger.LogInfo("Town Names Mod patches applied successfully!");
		}
		catch (System.Exception ex)
		{
			Logger.LogError($"Failed to apply patches: {ex.Message}");
		}
	}

	private void OnDestroy()
	{
		harmonyInstance?.UnpatchSelf();
	}
}
