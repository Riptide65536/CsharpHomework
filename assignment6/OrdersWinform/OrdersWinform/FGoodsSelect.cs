using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdersWinform
{
    public partial class FGoodsSelect : Form
    {
        private readonly StockList stockList = AppContext.StockList;

        public Goods select = new("",0);
        public FGoodsSelect()
        {
            InitializeComponent();
            var sel = from o in stockList.Inventory.Keys
                      select o.Name;

            listBox1.DataSource = sel.ToList();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem;
            if(item == null)
            {
                MessageBox.Show("请选择货物！");
                return;
            }

            string? str = item.ToString();
            if (str == null)
            {
                MessageBox.Show("选择货物不可为空！");
                return;
            }

            var find = stockList.Inventory.FirstOrDefault(o => o.Key.Name == str);
            select = find.Key;
            this.DialogResult = DialogResult.OK;
        }
    }
}
