using BepInEx;

namespace DLLInjector
{
	[BepInPlugin(DLLInjectorLib.pluginGuid, DLLInjectorLib.pluginName, DLLInjectorLib.pluginVersion)]
	public class DLLInjectorPlugin : BaseUnityPlugin
	{
		private void Awake()
		{
			new DLLInjectorLib().InjectAll(Paths.PluginPath, Logger.LogMessage);
		}
	}
}