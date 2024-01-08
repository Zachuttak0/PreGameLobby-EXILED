using Exiled.API.Interfaces;
using System.ComponentModel;

namespace PreGameLobby
{
    public sealed class Config : IConfig
    {
        [Description("Turn the plugin on and off (true for on, false for off)")]
        public bool IsEnabled { get; set; } = true;
        [Description("adds info to debug problems into the console")]
        public bool Debug { get; set; } = false;
        [Description("If 'true' then there will be items spawning in the pre-game lobby (ie. Jailbird, Pink Candy, ex...)")]
        public bool ItemDrops { get; set; } = true;
        [Description("Determinans if admins can start a death match in the pregame lobby")]
        public bool Death { get; set; } = true;
    }
}