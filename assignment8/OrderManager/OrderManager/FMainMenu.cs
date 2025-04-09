namespace OrderManager
{
    public partial class MainWindow : Form
    {   
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrderMenu orderMenu = new();
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
