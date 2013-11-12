using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.ZuesMud;
using zeus_mud_wpf_client.dialog;

namespace zeus_mud_wpf_client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class GameMainWindow : Window
    {
        public GameMainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (GlobalObject.RoomCreateForm == null)
            {
                GlobalObject.RoomCreateForm = new frmRoomCreate();
            }
            GlobalObject.RoomCreateForm.Show();
        }
    }
}
