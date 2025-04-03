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

namespace OrdersWinform
{
    public partial class OrderMenu : Form
    {
        private readonly OrderService _orderService;
        public void InitializeBindings()
        {
            var sel = from o in _orderService.Orders
                      select new
                      {
                          订单号 = o.Id,
                          创建时间 = o.CreateTime,
                          用户名 = o.Customer.Name,
                          用户编号 = o.Customer.Id,
                          总价格 = o.TotalPrice
                      };

            orderBinding.DataSource = sel.ToList();
            dataGridViewOrders.DataSource = orderBinding;

            dataGridViewOrders.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewOrders.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewOrders.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewOrders.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewOrders.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridViewOrders.Columns[0].FillWeight = 15;
            dataGridViewOrders.Columns[1].FillWeight = 30;
            dataGridViewOrders.Columns[2].FillWeight = 15;
            dataGridViewOrders.Columns[3].FillWeight = 15;
            dataGridViewOrders.Columns[4].FillWeight = 15;
        }

        public void InitializeFilters()
        {
            filterSelect.SelectedIndex = 0;
            filterInput.Enabled = false;
            sortSelect1.SelectedIndex = 0;
            sortSelect2.SelectedIndex = 0;
        }

        public OrderMenu(OrderService orderService)
        {
            InitializeComponent();
            _orderService = orderService;
            InitializeBindings();
            InitializeFilters();
        }
        public OrderMenu()
        {
            InitializeComponent();
            _orderService = new();
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
                    predicate = (o => o.Id.ToString() == filterInput.Text);
                    break;
                case 2://姓名
                    predicate = (o => o.Customer.Name == filterInput.Text);
                    break;
                case 3://货物名
                    predicate = (o => o.Details.FirstOrDefault(od => od.Item.Name == filterInput.Text) != default);
                    break;
                default:
                    MessageBox.Show("错误！还没有实现！");
                    return;
            }

            // 抽取排序条件
            Func<Order, object> sortField;
            switch(sortSelect1.SelectedIndex)
            {
                case 0: sortField = o => o.Id; break;           //订单编号
                case 1: sortField = o => o.Customer.Name; break;//用户名
                case 2: sortField = o => o.Customer.Id; break;  //用户编号
                case 3: sortField = o => o.CreateTime; break;   //时间
                case 4: sortField = o => o.TotalPrice; break;   //总金额
                default: MessageBox.Show("错误！还没有实现！"); return;
            }

            // 筛选，并且重组数据绑定
            var filtered = _orderService.SearchOrders(predicate);
            var ordered = sortSelect1.SelectedIndex == 0 ?
            filtered.OrderByDescending(sortField) :
            filtered.OrderBy(sortField);

            var sel = from o in filtered
                      select new
                      {
                          订单号 = o.Id,
                          创建时间 = o.CreateTime,
                          用户名 = o.Customer.Name,
                          用户编号 = o.Customer.Id,
                          总价格 = o.TotalPrice
                      };

            orderBinding.DataSource = sel.ToList();
        }

        private void EditOrderButton_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridViewOrders.CurrentRow;
            int orderId = Convert.ToInt32(selectedRow.Cells["订单号"].Value);
            var order = _orderService.Orders.FirstOrDefault(o => o.Id == orderId);
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
                _orderService.UpdateOrder(orderId, new_order);
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
                _orderService.AddOrder(new_order);
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
            int orderId = Convert.ToInt32(selectedRow.Cells["订单号"].Value);
            _orderService.RemoveOrder(orderId);
            InitializeBindings();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
