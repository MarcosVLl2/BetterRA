using UnityEngine;
using UserSettings.ServerSpecific;
using Logger = LabApi.Features.Console.Logger;

namespace BetterRA
{
    public class Keybinds
    {
        private static readonly SSGroupHeader SettingHeader = new(8220, "BetterRA", true, "BetterRA Keybind");

        // ReSharper disable once InconsistentNaming
        private static readonly SSKeybindSetting SettingOpenRA = new(8221, "Open RA", KeyCode.J, true, false,
            "Open Remote Admin panel");

        private static readonly ServerSpecificSettingBase[] SettingBase =
        [
            SettingHeader, SettingOpenRA
        ];

        public static void OnButtonPressed(ReferenceHub hub, ServerSpecificSettingBase setting)
        {
            Logger.Warn($"You have pressed a button!");

            if (setting.SettingId == SettingOpenRA.SettingId)
            {
                Logger.Warn($"Open RA setting: {setting.SettingId}");
            }
        }
    }
}