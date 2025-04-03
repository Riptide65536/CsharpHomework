using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdersWinform
{
    public partial class DetailsMenu : Form
    {
        public Order Order { get; }
        public DetailsMenu(Order order)
        {
            InitializeComponent();
            this.Order = order;
            InitBindings();
        }
        public DetailsMenu()
        {
            InitializeComponent();
            this.Order = new Order(-1);
            InitBindings();
        }

        public void InitBindings()
        {
            dataGridView1.DataSource = Order.Details;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.Columns["Item"].ReadOnly = true;

            idInput.Text = Order.Id.ToString();
            CustomerIdInput.Text = Order.Customer.Id.ToString();
            CustomerNameInput.Text = Order.Customer.Name;
            dateTimePicker1.Value = Order.CreateTime;

            this.dataGridView1.Columns[0].AutoSizeMode = 
                DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[2].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void addDetailButton_Click(object sender, EventArgs e)
        {
            Order.Details.Add(new OrderDetails(new Goods("", 0), 0));
        }

        private void deleteDetailButton_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.CurrentRow;
            string? s = Convert.ToString(selectedRow.Cells["Item"].Value);
            int a = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);

            OrderDetails? od
                = Order.Details.FirstOrDefault(d => d.Item.ToString() == s && d.Quantity == a);

            if (od != null)
            {
                Order.RemoveDetail(od);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void idInput_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(idInput.Text, out int input))
            {
                MessageBox.Show("请输入数字！");
                idInput.Text = "-1";
                return;
            }

            Order.Id = input;
        }

        private void CustomerIdInput_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(CustomerIdInput.Text, out int input))
            {
                MessageBox.Show("请输入数字！");
                CustomerIdInput.Text = "0";
                return;
            }

            Order.Customer.Id = input;
        }

        private void CustomerNameInput_TextChanged(object sender, EventArgs e)
        {
            Order.Customer.Name = CustomerNameInput.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Order.CreateTime = dateTimePicker1.Value;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            if(e.ColumnIndex == 0)
            {

                FGoodsSelect selwindow = new();
                selwindow.ShowDialog();

                var currentDetail = Order.Details[e.RowIndex];
                currentDetail.Item = selwindow.select;
                
                selwindow.Close();
            }
            dataGridView1.InvalidateRow(e.RowIndex);
        }
    }
}
