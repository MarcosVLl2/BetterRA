using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Features.Permissions;
using LabApi.Features.Wrappers;
using UserSettings.ServerSpecific;

namespace BetterRA;

public class Events
{
    public static void OnJoined(PlayerJoinedEventArgs args)
    {
        if (Plugin.Instance != null)
            ServerSpecificSettingsSync.SendToPlayersConditionally(hub =>
                Player.Get(hub).HasPermission(Plugin.Instance.Config.RaPermission));
    }
}