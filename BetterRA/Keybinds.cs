using System;
using LabApi.Features.Wrappers;
using UnityEngine;
using UserSettings.ServerSpecific;
using Logger = LabApi.Features.Console.Logger;

namespace BetterRA
{
    public class Keybinds
    {
        public enum SettingsEnum
        {
            Header = 8220,
            OpenRA = 8221,
        }

        public static readonly ServerSpecificSettingBase[] SettingBase =
        [
            new SSGroupHeader((int)SettingsEnum.Header,
                "BetterRA", true, "BetterRA Keybinds, available only to server moderators"),
            new SSKeybindSetting((int)SettingsEnum.OpenRA,
                "Open BetterRA", KeyCode.J, false, true, "Open Better RemoteAdmin panel")
        ];


        public static void OnValueReceived(ReferenceHub hub, ServerSpecificSettingBase setting)
        {
            var player = Player.Get(hub);
            try
            {
                Handle(player, hub, setting);
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to handle {setting.SettingId}: {ex}");
            }
        }

        private static void Handle(Player player, ReferenceHub hub, ServerSpecificSettingBase setting)
        {
            switch (setting.SettingId)
            {
                case (int)SettingsEnum.Header:
                    break;
                case (int)SettingsEnum.OpenRA:
                    if (setting.DebugValue == "Released")
                    {
                    }

                    break;
            }
        }
    }
}