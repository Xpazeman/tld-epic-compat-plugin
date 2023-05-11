#TLD Modding - Epic Compatibility Plugin

Since the release of TFTFT, Epic users haven't been able to mod their games, because EOS (Epic Online Services) flags MelonLoader as a cheating program and closes the game as soon as it starts.

To avoid this, this plugin disables EOS for the game (not sure if this also disables achievements, but it's probable), so ML doesn't crash on startup.

Super special thanks to Baydock for making this for BTD6, this is a port to TLD from that.

## **IMPORTANT THINGS:**
- This *will disable both Wintermute and TFTFT* since there's no service to check for ownership. This will show them as unowned, even if you own them. Remove the plugin to be able to play wintermute or use the dlc content
- This is a plugin, so it goes in your Plugins folder **not your Mods folder**
- The first time you run the game, it will create TLDEOSBypasser.dll on your Mods folder if it doesn't exist already
- This is for TLD 2.06+, so you need *ML 0.6.1, have .net6 installed, and use mods updated to work with this version*
- Check the mod list for instructions, common issues, and a list of updated mods: https://xpazeman.com/tld-mod-list
- I used Baydock's BTD6Bypasser as a base to build this, he's the one that did all the heavy lifting and I just ported it all to TLD