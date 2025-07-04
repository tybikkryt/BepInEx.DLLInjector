# About
This is a simple BepInEx plugin that automatically injects your DLLs into the game on startup. No need for injectors anymore.

## Compatibility
| BepInEx ver | Mono | IL2CPP |
| ----------- | ---- | ------ |
| BepInEx 5.X | ✅️ | ✖ |
| BepInEx 6.X | ✅ | ✅ |
| BepInEx 6.X (CoreCLR) | N/A | N/A |

## How to use
<ol>
  <li>Download the release for your configuration</li>
  <li>Take the `plugins/DLLInjector` folder and place it in `BepInEx/plugins/`</li>
  <li>Place all the DLL files you need in the `DLLInjector/InjectionDlls` folder</li>
  <li>Run the game and all your DLLs will be injected</li>
</ol>

## Example
This is an example of what files and folders should look like
REPO
├── BepInEx
│   ├── core
│   │   └── ...
│   ├── plugins
│   │   └── DLLInjector
│   │      ├── InjectionDlls                          # All DLLs you want to inject lives here
│   │      │   ├── SomeDLL.dll
│   │      │   ├── DoSomethingIdk.dll
│   │      │   └── ...
│   │      ├── DLLInjectorLib.dll                     # Universal library for inject
│   │      └── DLLInjector.BepInEx5.Mono              # BepInEx plugin. Different depending on the BepInEx version and unity scripting backend (Mono or IL2CPP)
│   └── ...
├── REPO_Data
│   └── ...
├── REPO.exe
└── ...
