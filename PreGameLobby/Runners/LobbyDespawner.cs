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
                    _player.Kill("Round is Starting");
                }
            }
            Map.CleanAllRagdolls();
            foreach (Pickup pickup in Pickup.List)
            {
                if ((pickup.Type == ItemType.Jailbird) || (pickup.Type == ItemType.SCP330))
                {
                    pickup.UnSpawn();
                }
            }
        }
    }
}
