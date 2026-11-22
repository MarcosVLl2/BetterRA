using LabApi.Loader.Features.Plugins;
using UserSettings.ServerSpecific;
using Version = System.Version;

namespace BetterRA
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "BetterRA";
        public override string Description => "Better RemoteAdmin for everyone";
        public override string Author => "MarcosVLl2";
        public override Version RequiredApiVersion => new(1, 1, 7);
        public override bool IsTransparent => true;
        public override Version Version => new(0, 0, 2);

        public override void Enable()
        {
            ServerSpecificSettingsSync.ServerOnSettingValueReceived += Keybinds.OnButtonPressed;
        }

        public override void Disable()
        {
            ServerSpecificSettingsSync.ServerOnSettingValueReceived -= Keybinds.OnButtonPressed;
        }
    }
}