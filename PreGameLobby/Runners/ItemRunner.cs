using Exiled.API.Features.Items;
using MEC;
using PlayerRoles;
using System.Collections.Generic;

namespace PreGameLobby.Runners
{
    class ItemRunner
    {
        public static void PreGameLobbyItemSpawner()
        {
            if (PreGameLobby.Instance.PreGameLobbyItemDrops)
            {
                foreach (Exiled.API.Features.Player _player in Exiled.API.Features.Player.List)
                {
                    if (_player.Role == RoleTypeId.Tutorial)
                    {
                        PreGameLobby.Instance.PreGameLobbyrngNum = PreGameLobby.PreGameLobbyrngGen.Next(1, 20);
                        if (PreGameLobby.Instance.PreGameLobbyrngNum == 19)
                        {
                            _player.AddItem(Firearm.Create(ItemType.Jailbird));
                            _player.Broadcast(10, "You got a Jailbird (if you have room)", Broadcast.BroadcastFlags.Normal, true);
                        }
                        else if (PreGameLobby.Instance.PreGameLobbyrngNum == 18)
                        {
                            _player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Pink);
                            _player.Broadcast(10, "You got a Pink Candy (if you have room)", Broadcast.BroadcastFlags.Normal, true);
                        }
                        else if (PreGameLobby.Instance.PreGameLobbyrngNum == 17)
                        {
                            _player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Yellow);
                            _player.Broadcast(10, "You got a Yellow Candy (if you have room)", Broadcast.BroadcastFlags.Normal, true);
                        }
                        else if (PreGameLobby.Instance.PreGameLobbyrngNum == 15)
                        {
                            _player.AddItem(Firearm.Create(ItemType.GunCom45));
                            _player.Broadcast(10, "You got a Com-45 (if you have room) (no reloads)", Broadcast.BroadcastFlags.Normal, true);
                        }
                        else if (PreGameLobby.Instance.PreGameLobbyrngNum == 14)
                        {
                            _player.AddItem(Firearm.Create(ItemType.GunA7));
                            _player.Broadcast(10, "You got a A7 (if you have room) (no reloads)", Broadcast.BroadcastFlags.Normal, true);
                        }
                    }
                }
            }
        }
        public static void StartItemSpawner()
        {
            Timing.RunCoroutine(_UpdateTime(), Segment.SlowUpdate);
            Timing.Instance.TimeBetweenSlowUpdateCalls = 3f;
        }
        private static IEnumerator<float> _UpdateTime()
        {
            while (true)
            {
                if (PreGameLobby.Instance.PreGameLobbyItemDrops)
                {
                    PreGameLobbyItemSpawner();
                }
                else
                {
                    yield break;
                }
                yield return 3f;
            }
        }
    }
}
