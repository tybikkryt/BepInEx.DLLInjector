using BepInEx;
using BepInEx.Unity.IL2CPP;

namespace DLLInjector
{
	[BepInPlugin(DLLInjectorLib.pluginGuid, DLLInjectorLib.pluginName, DLLInjectorLib.pluginVersion)]
	public class DLLInjectorPlugin : BasePlugin
	{
		public override void Load()
		{
			DLLInjectorLib.Log = Log.LogMessage;
			DLLInjectorLib.pluginPath = Paths.PluginPath;
			DLLInjectorLib.InjectAll();
		}
	}
}
