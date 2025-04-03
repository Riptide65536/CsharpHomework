using System;
using System.Linq;
using System.Windows.Forms;

namespace OrdersWinform
{
    public partial class StockMenu : Form
    {
        private readonly StockList _stockList;
        private BindingSource _stockBinding = new BindingSource();

        // 初始化绑定增强版
        public void InitializeBinding()
        {
            _stockBinding.DataSource = _stockList.Inventory.Select(v => new
            {
                货物名 = v.Key.Name,
                货物单价 = v.Key.Price,
                货物存量 = v.Value
            }).ToList();

            StockGridView.DataSource = _stockBinding;
            StockGridView.CellFormatting += (s, e) =>
            {
                if (e.ColumnIndex == 1) // 单价列格式
                    e.Value = $"{e.Value:C}";
            };
        }

        public StockMenu()
        {
            InitializeComponent();
            _stockList = AppContext.StockList;
            InitializeBinding();
            ConfigureGrid();
        }

        private void ConfigureGrid()
        {
            StockGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            StockGridView.ReadOnly = true;
            StockGridView.AllowUserToAddRows = false;

            StockGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            StockGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            StockGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            StockGridView.Columns[0].FillWeight = 33;
            StockGridView.Columns[1].FillWeight = 33;
            StockGridView.Columns[2].FillWeight = 33;
        }

        // 添加库存（带输入验证）
        private void AddStockButton_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedGoods(out var goods) && goods != null)
            {
                using var inputForm = new QuantityInputForm("增加库存量");
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    _stockList.AddStock(goods, inputForm.Quantity);
                    RefreshBinding();
                }
            }
        }

        // 减少库存（带溢出保护）
        private void ReduceStockButton_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedGoods(out var goods) && goods != null)
            {
                using var inputForm = new QuantityInputForm("减少库存量");
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    if (_stockList.Inventory[goods] >= inputForm.Quantity)
                    {
                        _stockList.ReduceStock(goods, inputForm.Quantity);
                        RefreshBinding();
                    }
                    else
                    {
                        MessageBox.Show("库存不足无法减少");
                    }
                }
            }
        }

        // 创建新货物（带重复检查）
        private void CreateStockButton_Click(object sender, EventArgs e)
        {
            using var createForm = new GoodsEditForm();
            if (createForm.ShowDialog() == DialogResult.OK)
            {
                var newGoods = new Goods(createForm.GoodsName, createForm.UnitPrice);

                if (_stockList.Inventory.Keys.Any(g => g.Name == newGoods.Name))
                {
                    MessageBox.Show("该货物已存在");
                    return;
                }

                _stockList.AddStock(newGoods, 0);
                RefreshBinding();
            }
        }

        // 清空选中货物库存（带确认）
        private void ClearStockButton_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedGoods(out var goods) && goods != null)
            {
                if (MessageBox.Show("确认清空该货物库存？", "警告",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _stockList.ClearStock(goods);
                    RefreshBinding();
                }
            }
        }

        // 修改库存信息（支持价格/存量调整）
        private void ChangeStockButton_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedGoods(out var goods) && goods != null)
            {
                using var editForm = new GoodsEditForm(goods);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    var newGoods = new Goods(editForm.GoodsName, editForm.UnitPrice);
                    var quantity = _stockList.Inventory[goods];

                    _stockList.UpdateGoodsInfo(goods, newGoods, quantity);
                    RefreshBinding();
                }
            }
        }

        // 辅助方法：获取选中货物
        private bool TryGetSelectedGoods(out Goods? goods)
        {
            if (StockGridView.CurrentRow?.Index >= 0)
            {
                var name = StockGridView.CurrentRow.Cells[0].Value.ToString();
                goods = _stockList.Inventory.Keys.First(g => g.Name == name);
                return true;
            }
            MessageBox.Show("请先选择货物");
            goods = null;
            return false;
        }

        private void RefreshBinding()
        {
            // _stockBinding.ResetBindings(true);
            InitializeBinding();
            StockGridView.Invalidate();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}