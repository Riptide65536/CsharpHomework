using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManager
{
    public partial class FGoodsSelect : Form
    {
        public Goods select = new();
        public FGoodsSelect()
        {
            InitializeComponent();
            using var context = new OrdersContext();
            var sel = from o in context.Goods
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

            using var context = new OrdersContext();
            var find = context.Goods.FirstOrDefault(o => o.Name == str);
            if (find != null) select = find;
            else
            {
                MessageBox.Show("选择货物不存在！");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
