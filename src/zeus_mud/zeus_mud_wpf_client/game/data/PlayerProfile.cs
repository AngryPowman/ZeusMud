using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeus_mud.game.data
{
    public class PlayerProfile
    {
        public static UInt64 guid { get; set; }
        public static string email { get; set; }
        public static Int32 gender { get; set; }
        public static string nickname { get; set; }
        public static string register_ip { get; set; }
        public static Int64 last_login { get; set; }
        public static UInt32 gold { get; set; }
    }
}
