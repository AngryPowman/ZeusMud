using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Wpf.ZuesMud;
using zeus_mud;

namespace zeus_mud_wpf_client
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        public void Application_Startup(object sender, StartupEventArgs e)
        {
            this.ShutdownMode = ShutdownMode.OnMainWindowClose;

            //开启Winform窗口样式
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            //曲线救国，在启动器中实例化Winform对象
            GlobalObject.LoginWindowInstance = new frmLogin();
            GlobalObject.LoginWindowInstance.Show();
        }
    }
}
