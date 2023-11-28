using PlayerRoles;
using System.Threading.Tasks;
using MEC;

namespace PreGameLobby.Runners
{
    internal class LobbyRunner
    {
        public static void PreGameLobbySpawner()
        {
            if (PreGameLobby.Instance.PreGameLobbyRunNow)
            {
                foreach (Exiled.API.Features.Player _player in Exiled.API.Features.Player.List)
                {
                    if ((_player.Role == RoleTypeId.Spectator) || (_player.Role == RoleTypeId.None))
                    {
                        _player.Role.Set(RoleTypeId.Tutorial);
                        _player.Teleport(new UnityEngine.Vector3(8, 998, -8));
                        _player.SetFriendlyFire(RoleTypeId.Tutorial, 1);
                    }
                }
            }
        }
        public static void StartLobbySpawner()
        {
            while (PreGameLobby.Instance.PreGameLobbyRunNow)
            {
                Timing.CallDelayed(4f, () => // 4 secs
                {
                    PreGameLobbySpawner();
                });
            }
        }
    }
}
