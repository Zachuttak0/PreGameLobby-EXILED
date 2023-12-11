using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features.Toys;

namespace PreGameLobby.Runners.depend
{
    class Bar
    {
        public static void PreGameLobbyBarSpawn()
        {
            if(!(PreGameLobby.Instance.PreGameLobbyBarOn))
            {
                PreGameLobby.Instance.PreGameLobbyBarOn = true;
                PreGameLobby.PreGameLobbyBar.Spawn();
            }
        }
        public static void PreGameLobbyBarDeSpawn()
        {
            if(PreGameLobby.Instance.PreGameLobbyBarOn)
            {
                PreGameLobby.Instance.PreGameLobbyBarOn = false;
                PreGameLobby.PreGameLobbyBar.Destroy();


            }
        }
    }
}
