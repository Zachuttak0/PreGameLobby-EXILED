using Exiled.API.Features.Items;
using MEC;
using PlayerRoles;

namespace PreGameLobby.Events
{
    internal class DeathMatch
    {
        private static string winner;
        public static void PreGameLobbyDeathMatch()
        {
            Timing.KillCoroutines();
            PreGameLobby.Instance.PreGameLobbyEvent = true;
            Exiled.API.Features.Round.IsLobbyLocked = true;
            Timing.CallDelayed(0.1f, () => // 0.1 secs
            {
                Runners.LobbyDespawner.PreGameLobbyDeSpawner();
            });
            Timing.CallDelayed(1f, () => // 1 sec
            {
                PreGameLobbyDeathStart();
            });
        }
        public static void PreGameLobbyDeathStart()
        {
            if (PreGameLobby.Instance.PreGameLobbyRunNow)
            {
                foreach (Exiled.API.Features.Player _player in Exiled.API.Features.Player.List)
                {
                    if (PreGameLobby.Instance.PreGameLobbyRunNow)
                    {
                        _player.Role.Set(RoleTypeId.Tutorial);
                        _player.Teleport(new UnityEngine.Vector3(8, 998, -8));
                        _player.SetFriendlyFire(RoleTypeId.Tutorial, 1);
                    }
                }
                PreGameLobby.Instance.PreGameLobbyCountDownMis = 10;
                Timing.CallDelayed(1f, () => // 1 sec
                {
                    PreGameLobbyDeathCountDown();
                });
            }
        }
        public static void PreGameLobbyDeathCountDown()
        {
            PreGameLobby.Instance.PreGameLobbyStringMis = PreGameLobby.Instance.PreGameLobbyCountDownMis.ToString();
            foreach (Exiled.API.Features.Player _player in Exiled.API.Features.Player.List)
            {
                _player.Broadcast(3, PreGameLobby.Instance.PreGameLobbyStringMis, Broadcast.BroadcastFlags.Normal, true);
            }
            Timing.CallDelayed(1f, () => // 1 sec
            {
                PreGameLobbyDeathCountDownSub();
            });
        }
        public static void PreGameLobbyDeathCountDownSub()
        {
            if (PreGameLobby.Instance.PreGameLobbyCountDownMis == 1)
            {
                PreGameLobbyDeathFight();
            }
            else
            {
                PreGameLobby.Instance.PreGameLobbyCountDownMis = PreGameLobby.Instance.PreGameLobbyCountDownMis - 1;
                PreGameLobbyDeathCountDown();
            }
        }
        public static void PreGameLobbyDeathFight()
        {
            foreach (Exiled.API.Features.Player _player in Exiled.API.Features.Player.List)
            {
                _player.Broadcast(3, "FIGHT!!!", Broadcast.BroadcastFlags.Normal, true);
            }
            foreach (Exiled.API.Features.Player _player in Exiled.API.Features.Player.List)
            {
                if (_player.Role == RoleTypeId.None)
                {
                    _player.Role.Set(RoleTypeId.Spectator);
                }
            }
            foreach (Exiled.API.Features.Player _player in Exiled.API.Features.Player.List)
            {
                if (_player.Role == RoleTypeId.Tutorial)
                {
                    _player.AddItem(Item.Create(ItemType.Jailbird));
                }
            }
            PreGameLobby.Instance.PreGameLobbyDeathRunning = true;
        }
        public static void PreGameLobbyDeathEnd()
        {
            foreach (Exiled.API.Features.Player _player in Exiled.API.Features.Player.List)
            {
                if (_player.Role == RoleTypeId.Tutorial)
                {
                    winner = _player.DisplayNickname;
                }
            }
            foreach (Exiled.API.Features.Player _player in Exiled.API.Features.Player.List)
            {
                _player.Broadcast(5, winner + " is the winner", Broadcast.BroadcastFlags.Normal, true);
            }
            Timing.CallDelayed(5f, () => // 5 secs
            {
                PreGameLobbyDeathCleanup();
            });
        }
        public static void PreGameLobbyDeathCleanup()
        {
            PreGameLobby.Instance.PreGameLobbyItemDrops = false;
            PreGameLobby.Instance.PreGameLobbyRunNow = false;
            Runners.LobbyDespawner.PreGameLobbyDeSpawner();
            Timing.CallDelayed(0.1f, () => // 0.1 secs
            {
                Runners.FFoff.TurnFfOff();
            });
            Runners.depend.Bar.PreGameLobbyBarDeSpawn();
            Timing.CallDelayed(2f, () => // 2 secs
            {
                PreGameLobbyDeathCleanup2();
            });
        }
        public static void PreGameLobbyDeathCleanup2()
        {
            Exiled.API.Features.Round.IsLobbyLocked = false;
            PreGameLobby.Instance.PreGameLobbyStartRunning();
        }
    }
}
