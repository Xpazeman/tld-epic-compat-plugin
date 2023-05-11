using TLDEOSBypasser;
using HarmonyLib;
using System;
using Il2Cpp;
using MelonLoader;
using Il2CppTLD.Platform;
using Il2CppTLD.OptionalContent;

[assembly: MelonInfo(typeof(BypassMod), "TLD EOS Bypasser", "1.0.0", "Xpazeman")]
[assembly: MelonGame("Hinterland", "TheLongDark")]

namespace TLDEOSBypasser;

[HarmonyPatch]
public class BypassMod : MelonMod {
    private static bool isLoaded = false;

    private const string wintermuteDLCID = "6d0289a9be2c4a609edd39583be80362";
    private const string tftftDLCID = "82ef38c9e8fb476b98664f03aff754b3";

    // Force Main menu load instead of signing in
    [HarmonyPatch(typeof(BootUpdate), nameof(BootUpdate.Update))]
    [HarmonyPostfix]
    public static void BootUpdateUpdate(BootUpdate __instance)
    {
        if (__instance.m_BootState == BootUpdate.BootState.WaitingForUserSignin)
        {
            __instance.m_BootState = BootUpdate.BootState.LoadingMainMenu;
        }

        if (__instance.m_BootState == BootUpdate.BootState.LoadingMainMenu)
        {
            if (!isLoaded) { 
                __instance.LoadMainMenu();
                isLoaded = true;
            }
        }
        
    }

    //Disable EOS methods
    [HarmonyPatch(typeof(EpicOnlineServicesManager), nameof(EpicOnlineServicesManager.Start))]
    [HarmonyPrefix]
    public static bool BypassEOSManagerAwake(EpicOnlineServicesManager __instance)
    {
        __instance.m_InternalState = EpicOnlineServicesManager.InternalStoreState.UserLoggedIn;
        __instance.DeregisterAuthTokenNotifications();
        __instance.DeregisterLoginStatusChanges();
        return false;
    }

    [HarmonyPatch(typeof(EpicOnlineServicesManager), nameof(EpicOnlineServicesManager.StartEpicAccountLogin))]
    [HarmonyPrefix]
    public static bool BypassEOSManagerAccountLogin()
    {
        return false;
    }

    [HarmonyPatch(typeof(EpicOnlineServicesManager), nameof(EpicOnlineServicesManager.StartTitleOwnershipCheck))]
    [HarmonyPrefix]
    public static bool BypassEOSManagerOwnershipCheck()
    {
        return false;
    }

    [HarmonyPatch(typeof(EpicOnlineServicesManager), nameof(EpicOnlineServicesManager.StartProductUserCreation))]
    [HarmonyPrefix]
    public static bool BypassEOSManagerUserCreation()
    {
        return false;
    }

    [HarmonyPatch(typeof(EpicOnlineServicesManager), nameof(EpicOnlineServicesManager.StartProductUserLogin))]
    [HarmonyPrefix]
    public static bool BypassEOSManagerUserLogin()
    {
        return false;
    }

    [HarmonyPatch(typeof(EpicOnlineServicesManager), nameof(EpicOnlineServicesManager.Update))]
    [HarmonyPrefix]
    public static bool BypassEOSManagerUpdate()
    {
        return false;
    }
}