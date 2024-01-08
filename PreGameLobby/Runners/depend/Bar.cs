namespace PreGameLobby.Runners.depend
{
    class Bar
    {
        public static void PreGameLobbyBarSpawn()
        {
            if (!(PreGameLobby.Instance.PreGameLobbyBarOn))
            {
                PreGameLobby.Instance.PreGameLobbyBarOn = true;
                PreGameLobby.PreGameLobbyBar.Spawn();
            }
        }
        public static void PreGameLobbyBarDeSpawn()
        {
            if (PreGameLobby.Instance.PreGameLobbyBarOn)
            {
                PreGameLobby.Instance.PreGameLobbyBarOn = false;
                PreGameLobby.PreGameLobbyBar.Destroy();
            }
        }
    }
}
