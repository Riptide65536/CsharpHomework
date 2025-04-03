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
    public partial class GoodsEditForm : Form
    {
        public string GoodsName => textName.Text;
        public decimal UnitPrice => numPrice.Value;

        public GoodsEditForm(Goods? existing = null)
        {
            this.Text = existing == null ? "新建货物" : "编辑货物";
            InitializeComponent();

            if (existing != null)
            {
                textName.Text = existing.Name;
                numPrice.Value = existing.Price;
            }
        }

        private void SaveButton_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
