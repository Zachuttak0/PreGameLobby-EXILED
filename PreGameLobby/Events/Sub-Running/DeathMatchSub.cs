using PlayerRoles;

namespace PreGameLobby.Events.Sub_Running
{
    class DeathMatchSub
    {
        private static int alivepeople;
        public static void DeathMatchSubRunning()
        {
            alivepeople = 0;
            foreach (Exiled.API.Features.Player _player in Exiled.API.Features.Player.List)
            {
                if (_player.Role == RoleTypeId.Tutorial)
                {
                    alivepeople++;
                }
            }
            if (alivepeople == 1)
            {
                PreGameLobby.Instance.PreGameLobbyDeathRunning = false;
                Events.DeathMatch.PreGameLobbyDeathEnd();
            }
            else
            {
                foreach (Exiled.API.Features.Player _player in Exiled.API.Features.Player.List)
                {
                    _player.Broadcast(1, alivepeople.ToString() + " players left", Broadcast.BroadcastFlags.Normal, true);
                    if (_player.Role == RoleTypeId.None)
                    {
                        _player.Role.Set(RoleTypeId.Spectator);
                    }
                }
            }
        }
    }
}
