using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManager
{
    public partial class OrderMenu : Form
    {

        public void InitializeBindings()
        {
            using var content = new OrdersContext();
            this.orderBinding.DataSource = content.Orders.ToList();
            this.dataGridViewOrders.DataSource = orderBinding;
        }

        public void InitializeFilters()
        {
            filterSelect.SelectedIndex = 0;
            filterInput.Enabled = false;
            sortSelect1.SelectedIndex = 0;
            sortSelect2.SelectedIndex = 0;
        }
        public OrderMenu()
        {
            InitializeComponent();
            InitializeBindings();
            InitializeFilters();
        }
        

        private void filterSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterSelect.SelectedIndex != 0)
            {
                filterInput.Enabled = true;
            }
            else
            {
                filterInput.Text = "";
                filterInput.Enabled = false;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // 抽取筛选条件
            Expression<Func<Order, bool>> predicate;
            switch (filterSelect.SelectedIndex)
            {
                case 0:
                    predicate = (o => true);
                    break;
                case 1://订单编号
                    predicate = (o => o.OrderId.ToString() == filterInput.Text);
                    break;
                case 2://姓名
                    predicate = (o => o.Customer != null && o.Customer.Name == filterInput.Text);
                    break;
                case 3://货物名
                    predicate = (o => o.Details.FirstOrDefault(od => od.GoodsName == filterInput.Text) != default);
                    break;
                default:
                    MessageBox.Show("错误！还没有实现！");
                    return;
            }

            // 抽取排序条件
            Func<Order, object> sortField;
            switch (sortSelect1.SelectedIndex)
            {
                case 0: sortField = o => o.OrderId; break;           //订单编号
                case 1: sortField = o => o.Customer?.Name ?? ""; break; //用户名
                case 2: sortField = o => o.Customer?.CustomerId ?? 0; break;  //用户编号
                case 3: sortField = o => o.CreateTime; break;   //时间
                case 4: sortField = o => o.TotalPrice; break;   //总金额
                default: MessageBox.Show("错误！还没有实现！"); return;
            }

            // 筛选，并且重组数据绑定
            // TODO：筛选和排序的算法需要完善
            using var content = new OrdersContext();
            orderBinding.DataSource = sortSelect1.SelectedIndex == 0 ?
                content.Orders.Where(predicate).OrderByDescending(sortField).ToList() :
                content.Orders.Where(predicate).OrderBy(sortField).ToList();
        }

        private void EditOrderButton_Click(object sender, EventArgs e)
        {
            using var content = new OrdersContext();
            var selectedRow = dataGridViewOrders.CurrentRow;
            int orderId = Convert.ToInt32(selectedRow.Cells[0].Value);
            var order = content.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if(order == null)
            {
                MessageBox.Show("错误！订单不可为空！");
                return;
            }

            DetailsMenu detailsMenu = new(order);
            detailsMenu.ShowDialog();

            Order new_order = detailsMenu.Order;
            if (new_order == null)
            {
                MessageBox.Show("错误！订单信息不可为空！");
                return;
            }
            try
            {
                content.SaveChanges();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            detailsMenu.Close();
            InitializeBindings();
        }

        private void AddOrderButton_Click(object sender, EventArgs e)
        {
            DetailsMenu detailsMenu = new();
            detailsMenu.ShowDialog();

            Order new_order = detailsMenu.Order;
            if (new_order == null)
            {
                MessageBox.Show("错误！订单信息不可为空！");
                return;
            }
            try
            {
                using var content = new OrdersContext();
                content.Orders.Add(new_order);
                content.SaveChanges();
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            detailsMenu.Close();
            InitializeBindings();
        }

        private void DeleteOrderButton_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridViewOrders.CurrentRow;
            int orderId = Convert.ToInt32(selectedRow.Cells["OrderId"].Value);
            using var content = new OrdersContext();
            var order = content.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                MessageBox.Show("错误！订单不可为空！");
                return;
            }
            content.Orders.Remove(order);
            content.SaveChanges();
            InitializeBindings();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            new OrdersContext().SaveChanges();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
