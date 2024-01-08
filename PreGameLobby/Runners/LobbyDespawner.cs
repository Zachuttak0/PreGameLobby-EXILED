using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using PlayerRoles;

namespace PreGameLobby.Runners
{
    internal class LobbyDespawner
    {
        public static void PreGameLobbyDeSpawner()
        {
            foreach (Exiled.API.Features.Player _player in Exiled.API.Features.Player.List)
            {
                if (_player.Role == RoleTypeId.Tutorial)
                {
                    _player.ClearInventory();
                    _player.Kill("");
                    _player.ClearBroadcasts();
                }
            }
            Map.CleanAllRagdolls();
            Log.Info("Made by zachuttak0 (discord)");
            foreach (Pickup pickup in Pickup.List)
            {
                if (depend.ItemCheck.PreGameLobbyItemCheck(pickup.Position))
                {
                    pickup.Destroy();
                }
            }
        }
    }
}
