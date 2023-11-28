using Exiled.API.Features.Items;
using MEC;
using PlayerRoles;
using System.Threading.Tasks;

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
                        if (PreGameLobby.Instance.PreGameLobbyrngNum == 20)
                        {
                            _player.AddItem(Firearm.Create(ItemType.Jailbird));
                            _player.Broadcast(10, "You got a Jailbird", Broadcast.BroadcastFlags.Normal, true);
                        }
                        else if (PreGameLobby.Instance.PreGameLobbyrngNum == 19)
                        {
                            _player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Red);
                            _player.Broadcast(10, "You got a Red Candy (if you have room)", Broadcast.BroadcastFlags.Normal, true);
                        }
                        else if (PreGameLobby.Instance.PreGameLobbyrngNum == 18)
                        {
                            _player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Red);
                            _player.Broadcast(10, "You got a Red Candy (if you have room)", Broadcast.BroadcastFlags.Normal, true);
                        }
                        else if (PreGameLobby.Instance.PreGameLobbyrngNum == 17)
                        {
                            _player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Yellow);
                            _player.Broadcast(10, "You got a Yellow Candy (if you have room)", Broadcast.BroadcastFlags.Normal, true);
                        }
                        else if (PreGameLobby.Instance.PreGameLobbyrngNum == 16)
                        {
                            _player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Yellow);
                            _player.Broadcast(10, "You got a Yellow Candy (if you have room)", Broadcast.BroadcastFlags.Normal, true);
                        }
                    }
                }
            }
        }
        public static void StartItemSpawner()
        {
            while (PreGameLobby.Instance.PreGameLobbyItemDrops)
            {
                Timing.CallDelayed(3f, () => // 3 secs
                {
                    PreGameLobbyItemSpawner();
                });
            }
        }
    }
}
