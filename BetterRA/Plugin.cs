using LabApi.Loader.Features.Plugins;
using Version = System.Version;

namespace BetterRA
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "BetterRA";
        public override string Description => "Better RemoteAdmin for everyone";
        public override string Author => "MarcosVLl2";
        public override Version RequiredApiVersion => new Version(1, 1, 7);
        public override bool IsTransparent => true;
        public override Version Version => new Version(0, 0, 2);

        public override void Enable()
        {
            return;
        }

        public override void Disable()
        {
            return;
        }
    }
}