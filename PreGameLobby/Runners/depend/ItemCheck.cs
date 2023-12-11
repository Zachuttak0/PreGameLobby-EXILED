using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreGameLobby.Runners.depend
{
    class ItemCheck
    {
        public static bool PreGameLobbyItemCheck(UnityEngine.Vector3 vector)
        {
            float xcord = vector.x;
            float ycord = vector.y;
            float zcord = vector.z;
            if (PreGameLobbyCheckX(xcord) && PreGameLobbyCheckY(ycord) && PreGameLobbyCheckZ(zcord))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool PreGameLobbyCheckX(float x)
        {
            if ((x > -22.0) && (x < 25.0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool PreGameLobbyCheckY(float y)
        {
            if ((y > 980.0) && (y < 1002.0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool PreGameLobbyCheckZ(float z)
        {
            if ((z > -15.0) && (z < 24.0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
