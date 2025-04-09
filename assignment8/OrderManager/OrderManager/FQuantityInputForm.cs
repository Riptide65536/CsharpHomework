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
    public partial class QuantityInputForm : Form
    {
        public int Quantity { get; private set; }
        public QuantityInputForm(string title)
        {
            InitializeComponent();
            this.Text = title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Quantity = (int)numinput.Value;
            DialogResult = DialogResult.OK;
        }
    }
}
