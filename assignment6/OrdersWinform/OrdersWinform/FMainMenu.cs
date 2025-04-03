namespace OrdersWinform
{
    public partial class MainWindow : Form
    {
        private readonly OrderService _orderService = new();
        
        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
        }
        public void InitializeData()
        {
            // 初始化货物信息
            Dictionary<Goods, int> inventory = new()
            {
                [new Goods("apple", 0.99m)] = 100,
                [new Goods("banana", 0.85m)] = 200,
                [new Goods("pear", 1.25m)] = 250,
                [new Goods("grape", 1.56m)] = 150,
                [new Goods("cherry", 0.55m)] = 600,
                [new Goods("melon", 3.2m)] = 50
            };
            foreach(Goods key in inventory.Keys)
            {
                AppContext.StockList.AddStock(key, inventory[key]);
            }

            // 初始化订单信息
            Customer customer = new(0, "张三");
            DateTime time = new(2025, 1, 1, 12, 0, 0);
            List<OrderDetails> odList = [
                new OrderDetails(inventory.Keys.ToList()[0], 10),
                new OrderDetails(inventory.Keys.ToList()[1], 5),
                new OrderDetails(inventory.Keys.ToList()[2], 3)
            ];

            Order order = new(0, customer, time);
            foreach(OrderDetails od in odList)
            {
                order.AddDetail(od);
            }

            _orderService.AddOrder(order);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrderMenu orderMenu = new(_orderService);
            orderMenu.ShowDialog();
            this.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockMenu stockMenu = new();
            stockMenu.ShowDialog();
            this.Show();
        }
    }
}
