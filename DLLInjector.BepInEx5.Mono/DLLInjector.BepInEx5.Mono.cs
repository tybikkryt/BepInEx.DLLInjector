using BepInEx;

namespace DLLInjector
{
	[BepInPlugin(DLLInjectorLib.pluginGuid, DLLInjectorLib.pluginName, DLLInjectorLib.pluginVersion)]
	public class DLLInjectorPlugin : BaseUnityPlugin
	{
		private void Awake()
		{
			DLLInjectorLib.Log = Logger.LogMessage;
			DLLInjectorLib.pluginPath = Paths.PluginPath;
			DLLInjectorLib.InjectAll();
		}
	}
}
