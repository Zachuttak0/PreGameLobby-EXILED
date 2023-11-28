using PlayerRoles;

namespace PreGameLobby.Runners
{
    internal class FFoff
    {
        public static void TurnFfOff()
        {
            foreach (Exiled.API.Features.Player _player in Exiled.API.Features.Player.List)
            {
                _player.SetFriendlyFire(RoleTypeId.Tutorial, 0);
            }
        }
    }
}
