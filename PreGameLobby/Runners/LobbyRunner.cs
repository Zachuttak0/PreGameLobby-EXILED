using PlayerRoles;
using MEC;
using System.Collections.Generic;

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
            Timing.RunCoroutine(_UpdateTime(), Segment.SlowUpdate);
            Timing.Instance.TimeBetweenSlowUpdateCalls = 4f;
        }
        private static IEnumerator<float> _UpdateTime()
        {
            while (true)
            {
                if(PreGameLobby.Instance.PreGameLobbyRunNow)
                {
                    PreGameLobbySpawner();
                }
                else
                {
                    yield break;
                }
                yield return 4f;
            }
        }
    }
}
