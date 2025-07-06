using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace DLLInjector
{
	public class DLLInjectorLib
	{
		public const string pluginGuid = "tybikkryt.dllinjector";
		public const string pluginName = "DLLInjector";
		public const string pluginVersion = "1.0.1.0";
		public static string pluginPath;

		public static Action<string> Log;

		[DllImport("kernel32.dll")]
		public static extern IntPtr LoadLibrary(string moduleName);

		public static void InjectAll()
		{
			string dirInjectionDlls = Path.Combine(pluginPath, "DLLInjector", "InjectionDlls");
			Log($"Searching DLLs in: {dirInjectionDlls}");

			if (!Directory.Exists(dirInjectionDlls))
			{
				Log("InjectionDlls directory not found. Creating...");
				try
				{
					Directory.CreateDirectory(dirInjectionDlls);
					Log("InjectionDlls directory created successfully");
				}
				catch (Exception ex)
				{
					Log($"Failed to create InjectionDlls directory: {ex.Message}");
					return;
				}
			}

			List<string> dllFiles = [];
			try
			{
				dllFiles.AddRange(Directory.GetFiles(dirInjectionDlls, "*.dll"));
			}
			catch (Exception ex)
			{
				Log($"Error getting DLL files: {ex.Message}");
				return;
			}

			if (dllFiles.Count == 0)
			{
				Log("No DLLs found in the InjectionDlls directory");
				return;
			}


			foreach (string dllPath in dllFiles)
			{
				if (File.Exists(dllPath))
				{
					Log($"Injecting DLL {dllPath}");
					IntPtr tHandle = LoadLibrary(dllPath);
					if (tHandle != IntPtr.Zero)
					{
						Log("DLL injected successfully");
					}
					else
					{
						Log($"Failed to inject DLL. Error code: {Marshal.GetLastWin32Error()}");
					}
				}
				else
				{
					Log($"DLL not found: {dllPath}");
				}
			}

			Log("Finished injecting all DLLs");
		}
	}
}
