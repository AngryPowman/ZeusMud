using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeus_mud;
using zeus_mud_wpf_client.dialog;
using zeus_mud_wpf_client;
using System.IO;
using System.Windows.Forms;
using zeus_mud_wpf_client.dialog.Item;

namespace Wpf.ZuesMud
{
    class GlobalObject
    {
        //登录窗口实例
        public static frmLogin LoginWindowInstance { get; set; }

        //注册窗口实例
        public static frmRegister RegisterWindowInstance { get; set; }

        //游戏主窗口实例
        public static GameMainWindow MainWindowInstance { get; set; }

        //玩家信息面板实例
        public static ProfilePanel ProfilePanelInstance { get; set; }

        //房间列表面板实例
        public static RoomListPanel RoomListPanelInstance { get; set; }

        //背包窗口实例
        public static frmBag BagWindowInstance { get; set; }


        public static string ConfigPath = Environment.CurrentDirectory + @"\Config.xml";
        public static string DefaultServer { get {return "127.0.0.1";}}
        public static UInt16 DefaultPort { get {return 36911;}}

        public class EmailToPhoto
        {
            public static string Url(string email)
            {
                string avartarIdent = GameUtil.toMD5(email);
                string url = "http://www.gravatar.com/avatar/" + avartarIdent;
                return url;
            }

            public static string UrlLocalCachePath
            {
                get
                {
                    var photopath = Path.Combine(Application.UserAppDataPath, "cache", "photo");
                    Directory.CreateDirectory(photopath);
                    return Path.Combine(photopath, "master");
                }
            }

            public static System.Drawing.Image Avatar { get; set; }
        }
    }
}
