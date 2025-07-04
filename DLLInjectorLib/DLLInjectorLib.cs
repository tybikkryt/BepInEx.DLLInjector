using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DLLInjector
{
	public class DLLInjectorLib
    {
		public const string pluginGuid = "tybikkryt.dllinjector";
		public const string pluginName = "DLLInjector";
		public const string pluginVersion = "1.0.0.0";

		[DllImport("kernel32.dll")]
		public static extern IntPtr LoadLibrary(string moduleName);

		public void InjectAll(string pluginPath, Action<string> log)
		{
			string dirInjectionDlls = Path.Combine(pluginPath, "DLLInjector", "InjectionDlls");
			log($"Searching DLLs in: {dirInjectionDlls}");

			if (!Directory.Exists(dirInjectionDlls))
			{
				log("InjectionDlls directory not found. Creating...");
				try
				{
					Directory.CreateDirectory(dirInjectionDlls);
					log("InjectionDlls directory created successfully");
				}
				catch (Exception ex)
				{
					log($"Failed to create InjectionDlls directory: {ex.Message}");
					return;
				}
			}

			List<string> dllFiles = new List<string>();
			try
			{
				dllFiles.AddRange(Directory.GetFiles(dirInjectionDlls, "*.dll"));
			}
			catch (Exception ex)
			{
				log($"Error getting DLL files: {ex.Message}");
				return;
			}

			if (dllFiles.Count == 0)
			{
				log("No DLLs found in the InjectionDlls directory");
				return;
			}


			foreach (string dllPath in dllFiles)
			{
				if (File.Exists(dllPath))
				{
					log($"Injecting DLL {dllPath}");
					IntPtr tHandle = LoadLibrary(dllPath);
					if (tHandle != IntPtr.Zero)
					{
						log("DLL injected successfully");
					}
					else
					{
						log($"Failed to inject DLL. Error code: {Marshal.GetLastWin32Error()}");
					}
				}
				else
				{
					log($"DLL not found: {dllPath}");
				}
			}

			log("Finished injecting all DLLs");
		}
	}
}