# About

This is a simple BepInEx plugin that automatically injects your DLLs into the game on startup. No need for injectors anymore.

## Compatibility

| BepInEx ver | Mono | IL2CPP |
| ----------- | ---- | ------ |
| 5.X | ✅️ | ✖ |
| 6.X | ✅ | ✅ |
| 6.X (CoreCLR) | N/A | N/A |

## How to use

<ol>
  <li>Download the latest <a href="https://github.com/tybikkryt/BepInEx.DLLInjector/releases/latest">release</a></li>
  <li>Take the <code>plugins/DLLInjector</code> folder and place it in <code>BepInEx/plugins/</code></li>
  <li>Place all the DLL files you need to inject in the <code>DLLInjector/InjectionDlls</code></li>
  <li>Run the game and all your DLLs will be injected</li>
</ol>

## Example

This is an example of what files and folders should look like
```
REPO
├── BepInEx
│   ├── core
│   │   └── ...
│   ├── plugins
│   │   └── DLLInjector
│   │      ├── InjectionDlls                 # All DLLs you want to inject lives here
│   │      │   ├── SomeDLL.dll
│   │      │   ├── DoSomethingIdk.dll
│   │      │   └── ...
│   │      ├── DLLInjectorLib.dll            # Universal library for inject
│   │      └── DLLInjector.BepInEx5.Mono     # BepInEx plugin. Different depending on the BepInEx version and unity scripting backend (Mono or IL2CPP)
│   └── ...
├── REPO_Data
│   └── ...
├── REPO.exe
└── ...
```
