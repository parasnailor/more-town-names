using BepInEx;
using HarmonyLib;
using Eremite;
using Eremite.Controller;

namespace TownNamesMod 
{
	[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
	// [BepInPlugin("com.wes.againstthestorm.townnames", "Town Names Mod", "1.0.0")]
	public class TownNamesPlugin : BaseUnityPlugin
	{
		public static TownNamesPlugin Instance;
		private Harmony harmony;
		private void Awake()
		{
			Logger.LogInfo("### TOWN NAMES MOD AWAKE ###");

			try
			{
				Instance = this;
				harmony = Harmony.CreateAndPatchAll(typeof(TownNamesPlugin));  
				Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
				
				// var harmony = new Harmony("townnames.mod");
				// harmony.PatchAll(typeof(Patches.WorldStateServicePatch));
				// Logger.LogInfo("### PATCHES APPLIED ###");
			}
			catch (System.Exception ex)
			{
				Logger.LogError($"### PATCH ERROR: {ex} ###");
			}
		}

		[HarmonyPatch(typeof(MainController), nameof(MainController.OnServicesReady))]
		[HarmonyPostfix]
		private static void HookMainControllerSetup()
		{ 
			// This method will run after game load (Roughly on entering the main menu)
			// At this point a lot of the game's data will be available.
			// Your main entry point to access this data will be `Serviceable.Settings` or `MainController.Instance.Settings`
			Instance.Logger.LogInfo($"Performing game initialization on behalf of {PluginInfo.PLUGIN_GUID}.");
			Instance.Logger.LogInfo($"The game has loaded {MainController.Instance.Settings.effects.Length} effects.");
		}

		[HarmonyPatch(typeof(GameController), nameof(GameController.StartGame))]
		[HarmonyPostfix]
		private static void HookEveryGameStart()
		{
			// Too difficult to predict when GameController will exist and I can hook observers to it
			// So just use Harmony and save us all some time. This method will run after every game start
			var isNewGame = MB.GameSaveService.IsNewGame();
			Instance.Logger.LogInfo($"Entered a game. Is this a new game: {isNewGame}.");
		}
	}
}