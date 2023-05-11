﻿using System.IO;

namespace TLDEpicGamesModCompat;

internal static class EOSSDK
{
    // Paths for EOSSDK
    private const string EOSSDKName = "EOSSDK-Win64-Shipping.dll";
    private const string TLDPluginsFolder = @"tld_Data\Plugins\x86_64\";
    private const string BackupFolder = TLDPluginsFolder + @"\backup\";
    private const string EOSSDKPath = TLDPluginsFolder + EOSSDKName;
    private const string EOSSDKBackupPath = BackupFolder + EOSSDKName;

    // Remove EOSSDK to not crash melonloader immediately
    public static void Remove()
    {
        Directory.CreateDirectory(BackupFolder);
        if (File.Exists(EOSSDKPath))
            File.Move(EOSSDKPath, EOSSDKBackupPath);

        Plugin.Logger.Msg("Removed EOSSDK");
    }

    // Restore EOSSDK for if the player wants to go unmodded
    public static void Restore()
    {
        if (File.Exists(EOSSDKBackupPath))
            File.Move(EOSSDKBackupPath, EOSSDKPath);

        Plugin.Logger.Msg("Restored EOSSDK");
    }
}