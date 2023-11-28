using Exiled.API.Interfaces;
using System.ComponentModel;

namespace PreGameLobby
{
    public sealed class Config : IConfig
    {
        [Description("Turn the plugin on and off (true for on, false for off)")]
        public bool IsEnabled { get; set; } = true;
        [Description("Exiled makes me add 'Debug', no clue what it does so I wouldn't touch it")]
        public bool Debug { get; set; } = false;
        [Description("If 'true' then there will be items spawning in the pre-game lobby (ie. Jailbird, Pink Candy, ex...)")]
        public bool ItemDrops { get; set; } = true;
    }
}