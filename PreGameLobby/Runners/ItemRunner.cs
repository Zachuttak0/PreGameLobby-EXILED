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
                        int rngNum = PreGameLobby.PreGameLobbyrngGen.Next(1, 10);
                        int rngINum = PreGameLobby.PreGameLobbyrngGen.Next(1, 20);
                        int rngCNum = PreGameLobby.PreGameLobbyrngGen.Next(1, 7);
                        if (rngNum == 9)
                        {
                            if (rngINum == 2)
                            {
                                if (rngCNum == 1)
                                {
                                    _player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Rainbow);
                                }
                                else if (rngCNum == 2)
                                {
                                    _player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Yellow);
                                }
                                else if (rngCNum == 3)
                                {
                                    _player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Purple);
                                }
                                else if (rngCNum == 4)
                                {
                                    _player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Red);
                                }
                                else if (rngCNum == 5)
                                {
                                    _player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Green);
                                }
                                else if (rngCNum == 6)
                                {
                                    _player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Blue);
                                }
                                else if (rngCNum == 7)
                                {
                                    _player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Pink);
                                }
                            }
                            else if (rngINum == 4)
                            {
                                _player.AddItem(Item.Create(ItemType.MicroHID));
                            }
                            else if (rngINum == 3)
                            {
                                _player.AddItem(Item.Create(ItemType.SCP018));
                            }
                            else if (rngINum == 5)
                            {
                                _player.AddItem(Item.Create(ItemType.ParticleDisruptor));
                            }
                            else if (rngINum == 6)
                            {
                                _player.AddItem(Item.Create(ItemType.SCP207));
                            }
                            else if (rngINum == 7)
                            {
                                _player.AddItem(Item.Create(ItemType.AntiSCP207));
                            }
                            else if (rngINum == 8)
                            {
                                _player.AddItem(Item.Create(ItemType.Jailbird));
                            }
                            else if (rngINum == 1)
                            {
                                _player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Pink);
                            }
                            else if (rngINum == 9)
                            {
                                _player.AddItem(Item.Create(ItemType.GrenadeHE));
                            }
                            else if (rngINum == 10)
                            {
                                _player.AddItem(Item.Create(ItemType.GrenadeFlash));
                            }
                            else if (rngINum == 11)
                            {
                                _player.AddItem(Item.Create(ItemType.GunCom45));
                                _player.AddItem(Item.Create(ItemType.Ammo9x19));
                                _player.AddItem(Item.Create(ItemType.Ammo9x19));
                                _player.AddItem(Item.Create(ItemType.Ammo9x19));
                            }
                            else if (rngINum == 12)
                            {
                                _player.AddItem(Item.Create(ItemType.GunA7));
                                _player.AddItem(Item.Create(ItemType.Ammo762x39));
                                _player.AddItem(Item.Create(ItemType.Ammo762x39));
                                _player.AddItem(Item.Create(ItemType.Ammo762x39));
                            }
                            else if (rngINum == 13)
                            {
                                _player.AddItem(Item.Create(ItemType.SCP500));
                            }
                            else if (rngINum == 14)
                            {
                                _player.AddItem(Item.Create(ItemType.Coin));
                            }
                            else
                            {
                                _player.AddItem(Item.Create(ItemType.SCP018));
                            }
                            _player.Broadcast(10, "Check Your Inventory ;)", Broadcast.BroadcastFlags.Normal, true);
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
