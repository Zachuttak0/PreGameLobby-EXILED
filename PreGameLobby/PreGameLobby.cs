using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using MEC;

namespace PreGameLobby
{
    public class PreGameLobby : Plugin<Config>
    {
        public static PreGameLobby Instance { get; } = new PreGameLobby();
        public override PluginPriority Priority { get; } = PluginPriority.Medium;
        public static System.Random PreGameLobbyrngGen = new System.Random();
        public bool PreGameLobbyItemDrops = false;
        public bool PreGameLobbyRunNow = false;
        public int PreGameLobbyrngNum = 0;
        public void PreGameLobbyVarsReset()
        {
            PreGameLobbyItemDrops = PreGameLobby.Instance.Config.ItemDrops;
            PreGameLobbyRunNow = true;
            PreGameLobbyrngNum = 0;
        }
        public override void OnEnabled()
        {
            PreGameLobbyRegisterEvents();
        }
        public override void OnDisabled()
        {
            PreGameLobbyUnregisterEvents();
        }
        public void PreGameLobbyRegisterEvents()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers += PreGameLobbyStartRunning;
            Exiled.Events.Handlers.Server.ChoosingStartTeamQueue += PreGameLobbyStopRunning;
            Exiled.Events.Handlers.Server.EndingRound += JustInCaseFailsafe;
        }
        public void PreGameLobbyUnregisterEvents()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers -= PreGameLobbyStartRunning;
            Exiled.Events.Handlers.Server.ChoosingStartTeamQueue -= PreGameLobbyStopRunning;
            Exiled.Events.Handlers.Server.EndingRound -= JustInCaseFailsafe;
        }
        public void PreGameLobbyStartRunning()
        {
            PreGameLobbyVarsReset();
            Runners.LobbyRunner.StartLobbySpawner();
            Timing.CallDelayed(0.1f, () => // 0.1 secs
            {
                Runners.ItemRunner.StartItemSpawner();
            });
        }
        public void PreGameLobbyStopRunning(ChoosingStartTeamQueueEventArgs ev)
        {
            PreGameLobbyItemDrops = false;
            PreGameLobbyRunNow = false;
            Runners.LobbyDespawner.PreGameLobbyDeSpawner();
            Timing.CallDelayed(0.1f, () => // 0.1 secs
            {
                Runners.FFoff.TurnFfOff();
            });
        }
        public void JustInCaseFailsafe(EndingRoundEventArgs ev)
        {
            Timing.KillCoroutines();
        }
        private PreGameLobby()
        {

        }
    }
}
