using TLDEpicGamesModCompat;
using MelonLoader;
using System;
using System.IO;

[assembly: MelonInfo(typeof(Plugin), "TLD Epic Games Mod Compatibility", "1.0.0", "Xpazeman")]
[assembly: MelonGame("Hinterland", "TheLongDark")]

namespace TLDEpicGamesModCompat;

public sealed class Plugin : MelonPlugin {
    private const string EOSBypasserModPath = "Mods/TLDEOSBypasser.dll";
    private const string EOSBypasserResourcePath = "TLDEOSBypasser.dll";
    public static MelonLogger.Instance Logger { get; private set; }

    //Prevent the crashing by removing the EOS SDK
    public override void OnPreInitialization() {
        Logger = LoggerInstance;

        EOSSDK.Remove();

        //Other possible exits
        AppDomain.CurrentDomain.ProcessExit += (s, e) => EOSSDK.Restore();
        AppDomain.CurrentDomain.UnhandledException += (s, e) => EOSSDK.Restore();
    }

    public override void OnApplicationQuit() {
        //Restore the SDK on exit
        EOSSDK.Restore();
    }

    public override void OnPreModsLoaded() {
        // Base mod to allow EOS Bypassing
        File.WriteAllBytes(EOSBypasserModPath, Resources.GetResource(EOSBypasserResourcePath));
    }
}
