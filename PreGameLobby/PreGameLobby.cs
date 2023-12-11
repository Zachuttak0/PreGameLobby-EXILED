using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Toys;
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
        public bool PreGameLobbyBarOn = false;
        public static Primitive PreGameLobbyBar;
        public void PreGameLobbyVarsReset()
        {
            PreGameLobbyItemDrops = PreGameLobby.Instance.Config.ItemDrops;
            PreGameLobbyRunNow = true;
            PreGameLobbyBarOn = false;
            PreGameLobbyBar = Primitive.Create(UnityEngine.PrimitiveType.Plane, new UnityEngine.Vector3(-1, 1000, -8), new UnityEngine.Vector3(180, 0, 0), new UnityEngine.Vector3(10, 10, 10), true, new UnityEngine.Color(0, 0, 0));
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
            Runners.depend.Bar.PreGameLobbyBarSpawn();
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
            Runners.depend.Bar.PreGameLobbyBarDeSpawn();
        }
        public void JustInCaseFailsafe(EndingRoundEventArgs ev)
        {
            Timing.KillCoroutines();
            Runners.depend.Bar.PreGameLobbyBarDeSpawn();
        }
        private PreGameLobby()
        {

        }
    }
}
