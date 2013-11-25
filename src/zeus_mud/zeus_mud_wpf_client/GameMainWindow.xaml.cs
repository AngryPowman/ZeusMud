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
using Wpf.network;
using Wpf.ZuesMud;
using zeus_mud_wpf_client.dialog;
using zeus_mud_wpf_client.network;

namespace zeus_mud_wpf_client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public delegate void ErrorMessageDelegate(string caption, string message);
    public partial class GameMainWindow : Window
    {
        public GameMainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            frmRoomCreate createRoomDlg = new frmRoomCreate();
            createRoomDlg.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GlobalObject.ProfileForm = this.PlayerProfile;
        }

        public void showDisconnectError(string caption, string message)
        {
            System.Windows.MessageBox.Show(
                GlobalObject.MainWindow,
                message, caption,
                System.Windows.MessageBoxButton.OK,
                System.Windows.MessageBoxImage.Error);
        }
    }
}
