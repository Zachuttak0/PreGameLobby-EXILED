namespace PreGameLobby.Events
{
    class Handlers
    {
        public static void PlayerDied(Exiled.Events.EventArgs.Player.DiedEventArgs diedEventArgs)
        {
            if (PreGameLobby.Instance.PreGameLobbyRunNow)
            {
                if (PreGameLobby.Instance.PreGameLobbyEvent)
                {
                    if (PreGameLobby.Instance.PreGameLobbyDeathRunning)
                    {
                        Sub_Running.DeathMatchSub.DeathMatchSubRunning();
                    }
                }
            }
        }
    }
}
