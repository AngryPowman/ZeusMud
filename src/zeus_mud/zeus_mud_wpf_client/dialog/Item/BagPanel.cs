using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zeus_mud_wpf_client.dialog.Item
{
    public partial class BagPanel : UserControl
    {
        public BagPanel()
        {
            InitializeComponent();
        }

        private void BagPanel_Load(object sender, EventArgs e)
        {
            _addItem("康师傅牌泡面", 99, 0);
            _addItem("腌制鸡头肉", 99, 0);
            _addItem("哥布林的破帽子", 1, 0);
            _addItem("卡拉战神精魄", 1, 0);
            _addItem("周鸿祎的执念", 1, 0);
            _addItem("唐僧给悟空的信", 1, 0);
            _addItem("巨人的挑战书", 1, 0);
        }

        public void addItem()
        { 
        
        }

        private void _addItem(string name, int count, int itemType)
        {
            ListViewItem item = new ListViewItem(name);
            item.SubItems.Add(count.ToString());
            item.SubItems.Add("");
            lsvItems.Items.Add(item);
        }
    }
}
