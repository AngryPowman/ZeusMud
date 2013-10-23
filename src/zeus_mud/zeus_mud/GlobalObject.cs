using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeus_mud;
using zeus_mud.dialog;

namespace RobotWatchman
{
    class GlobalObject
    {
        public static frmLogin LoginForm { get; set; }
        public static frmRegister RegisterForm { get; set; }
        public static frmGameMain GameMainForm { get; set; }
        public static frmGameMain_ GameMainForm_ { get; set; }
        public static frmBattle BattleForm { get; set; }
        public static frmProfile ProfileForm { get; set; }

        public static string DefaultServer { get {return "127.0.0.1";}}
        public static UInt16 DefaultPort { get {return 36911;}}
        public static string Email2PhotoUrl( string email )
        {
            string avartarIdent = GameUtil.toMD5(email);
            string url = "http://www.gravatar.com/avatar/" + avartarIdent;
            return url;
        }
    }
}
