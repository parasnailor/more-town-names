using BepInEx;
using HarmonyLib;
using Eremite.Controller;
using Eremite.Services;
using BepInEx.Configuration;

namespace MoreTownNames 
{
	[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
	public class TownNamesPlugin : BaseUnityPlugin
	{
		public static TownNamesPlugin Instance;
		internal static ConfigEntry<string> CustomNames;

		private Harmony harmony;
		private void Awake()
		{
			Logger.LogInfo("### MORE TOWN NAMES LOADED ###");
			Instance = this;

			string defaultNames = "Emberwatch,Stonehaven,Dunhold,Ashenvale,Ironholm,Mistwood,Crescent Bay," +
			"Northmark,Shadowpeak,Goldleaf,Ravenfort,Silvermere,Eversong;";

            CustomNames = Config.Bind(
				"General",
				"CustomTownNames",
				defaultNames,
				"Comma-separated list of town names to add to the pool."
			);

            Logger.LogInfo($"Loaded config names: {CustomNames.Value}");

			harmony = new Harmony(PluginInfo.PLUGIN_GUID);
			harmony.PatchAll();
			Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} patching complete.");
		}

		[HarmonyPatch(typeof(MainController), "OnServicesReady")]
		[HarmonyPostfix]
		private static void HookMainControllerSetup()
		{ 
			// This method will run after game load (Roughly on entering the main menu)
			// At this point a lot of the game's data will be available.
			// Your main entry point to access this data will be `Serviceable.Settings` or `MainController.Instance.Settings`
			Instance.Logger.LogInfo($"Performing game initialization on behalf of {PluginInfo.PLUGIN_GUID}.");
			Instance.Logger.LogInfo($"The game has loaded {MainController.Instance.Settings.effects.Length} effects.");
		}

		[HarmonyPatch(typeof(GameController), "StartGame")]
		[HarmonyPostfix]
		private static void HookEveryGameStart()
		{
			// Too difficult to predict when GameController will exist and I can hook observers to it
			// So just use Harmony and save us all some time. This method will run after every game start
			var isNewGame = AccessTools.Method(typeof(GameService), "IsNewGame").Invoke(null, null);
			Instance.Logger.LogInfo($"Entered a game. Is this a new game: {isNewGame}.");
		}
	}
}