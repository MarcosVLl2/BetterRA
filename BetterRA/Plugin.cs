using System;
using System.Collections.Generic;
using System.Linq;
using LabApi.Events.Handlers;
using LabApi.Loader.Features.Plugins;
using UserSettings.ServerSpecific;

namespace BetterRA
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin? Instance { get; private set; }
        public override string Name => "BetterRA";
        public override string Description => "Better RemoteAdmin for everyone";
        public override string Author => "MarcosVLl2";
        public override Version RequiredApiVersion => new(1, 1, 7);
        public override bool IsTransparent => true;
        public override Version Version => new(0, 0, 3);

        public override void Enable()
        {
            Instance = this;

            List<ServerSpecificSettingBase> all = ServerSpecificSettingsSync.DefinedSettings?.ToList() ?? [];
            all.AddRange(Keybinds.SettingBase);
            ServerSpecificSettingsSync.DefinedSettings = [.. all];

            ServerSpecificSettingsSync.ServerOnSettingValueReceived += Keybinds.OnValueReceived;
            PlayerEvents.Joined += Events.OnJoined;
        }

        public override void Disable()
        {
            ServerSpecificSettingsSync.ServerOnSettingValueReceived -= Keybinds.OnValueReceived;
            PlayerEvents.Joined -= Events.OnJoined;


            if (ServerSpecificSettingsSync.DefinedSettings is not null)
            {
                ServerSpecificSettingsSync.DefinedSettings =
                [
                    .. ServerSpecificSettingsSync.DefinedSettings.Where(setting =>
                        !Keybinds.SettingBase.Contains(setting))
                ];
                ServerSpecificSettingsSync.SendToAll();
            }

            Instance = null;
        }
    }
}