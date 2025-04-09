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

namespace OrderManager
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
            this.Order = new Order();
            InitBindings();
        }

        public void InitBindings()
        {
            using var OrdersContext = new OrdersContext();
            Order.Details = OrdersContext.OrderDetails
                .Where(o => o.OrderId == Order.OrderId).ToList();
            orderDetailsBindingSource.DataSource = Order.Details;

            // 提取客户列表，其名字形成的列表在combobox内显示
            CustomerComboBox.DataSource = OrdersContext.Customers
                .Select(c => c.Name).ToList();
            CustomerComboBox.Text = Order.Customer?.Name ?? "";

            dateTimePicker1.Value = Order.CreateTime < dateTimePicker1.MinDate ?
                DateTime.Now : Order.CreateTime;
        }

        private void addDetailButton_Click(object sender, EventArgs e)
        {
            // 添加一个新的订单明细
            var newDetail = new OrderDetail
            {
                GoodsId = 0, // 默认商品ID
                Quantity = 0, // 默认数量
                OrderId = Order.OrderId
            };

            Order.Details.Add(newDetail);
            orderDetailsBindingSource.ResetBindings(false);
        }

        private void deleteDetailButton_Click(object sender, EventArgs e)
        {
            // 删除选中的订单明细
            var selectedRow = dataGridView1.CurrentRow;
            if (selectedRow == null) return;

            var goodsName = Convert.ToString(selectedRow.Cells["GoodsName"].Value);
            var quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);

            var detailToRemove = Order.Details.FirstOrDefault(d =>
                d.Goods?.Name == goodsName && d.Quantity == quantity);
            if (detailToRemove != null)
            {
                Order.Details.Remove(detailToRemove);

                using var context = new OrdersContext();
                var todel = context.OrderDetails.FirstOrDefault
                    (d => d.OrderDetailId == detailToRemove.OrderDetailId);
                if (todel != null)
                {
                    context.OrderDetails.Remove(todel);
                    context.SaveChanges(); // 确保删除操作被保存
                }
            }

            orderDetailsBindingSource.ResetBindings(false);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            using var context = new OrdersContext();
            // 查询用户，如果有就将用户id号更新，否则在context类增加
            string curName = CustomerComboBox.Text;
            var res = context.Customers.FirstOrDefault(c => c.Name == curName);

            if (res == null)
            {
                context.Customers.Add(new Customer() { Name = curName });
                context.SaveChanges();
                res = context.Customers.FirstOrDefault(c => c.Name == curName);
            }

            if (res != null)
            {
                Order.CustomerId = res.CustomerId;
            }

            // 保存订单明细
            foreach (var detail in Order.Details)
            {
                detail.GoodsId = detail.Goods == null ? 0 : detail.Goods.GoodsId;
                detail.OrderId = Order.OrderId;
                detail.Goods = null; // 清除导航属性，避免循环引用
                if (detail.OrderDetailId == 0) // 新增的明细
                {
                    context.OrderDetails.Add(detail);
                }
                else // 更新已有的明细
                {
                    context.OrderDetails.Update(detail);
                }
            }
            Order.Details.Clear(); // 清除导航属性，避免循环引用
            try
            {
                context.SaveChanges();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！" + ex.Message);
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Order.CreateTime = dateTimePicker1.Value;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            if (e.ColumnIndex == 0) // 假设第0列是商品选择列
            {
                FGoodsSelect selwindow = new();
                selwindow.ShowDialog();

                var currentDetail = Order.Details[e.RowIndex];
                currentDetail.Goods = selwindow.select; // 假设FGoodsSelect有SelectedGoods属性

                selwindow.Close();
            }

            else if(e.ColumnIndex == 2)
            {

            }

                orderDetailsBindingSource.ResetBindings(false);
        }
    }
}
