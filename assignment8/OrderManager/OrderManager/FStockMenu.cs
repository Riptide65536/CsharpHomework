using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace OrderManager
{
    public partial class StockMenu : Form
    {

        // 初始化绑定增强版
        public void InitializeBinding()
        {
            using var content = new OrdersContext();
            stockBinding.DataSource = content.Goods.ToList();
        }

        public StockMenu()
        {
            InitializeComponent();
            InitializeBinding();
        }

        // 修改 AddStockButton_Click 方法中的以下代码
        private void AddStockButton_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedGoods(out var goods) && goods != null)
            {
                using var inputForm = new QuantityInputForm("增加库存量");
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    using var content = new OrdersContext();
                    var existingGoods = content
                        .Goods.FirstOrDefault(g => g.GoodsId == goods.GoodsId);
                    if (existingGoods == null) return;
                    existingGoods.StockQuantity += inputForm.Quantity;
                    content.SaveChanges();
                    RefreshBinding();
                    
                }
            }
        }

        // 减少库存
        private void ReduceStockButton_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedGoods(out var goods) && goods != null)
            {
                using var inputForm = new QuantityInputForm("减少库存量");
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    using var content = new OrdersContext();
                    var existingGoods = content.Goods
                        .FirstOrDefault(g => g.GoodsId == goods.GoodsId);

                    if (existingGoods == null) return;
                    if (existingGoods.StockQuantity < inputForm.Quantity)
                    {
                        MessageBox.Show("库存不足，无法减少");
                        return;
                    }

                    existingGoods.StockQuantity -= inputForm.Quantity;
                    content.SaveChanges();
                    RefreshBinding();
                }
            }
        }

        // 创建新货物（带重复检查）
        private void CreateStockButton_Click(object sender, EventArgs e)
        {
            using var createForm = new GoodsEditForm();
            if (createForm.ShowDialog() == DialogResult.OK)
            {
                var newGoods = new Goods()
                {
                    Name = createForm.GoodsName,
                    Price = createForm.UnitPrice
                };

                using var content = new OrdersContext();

                if (content.Goods.Any(g => g.Name == newGoods.Name))
                {
                    MessageBox.Show("该货物已存在");
                    return;
                }

                content.Goods.Add(newGoods);
                content.SaveChanges();
                RefreshBinding();
            }
        }

        private void ClearStockButton_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedGoods(out var goods) && goods != null)
            {
                if (MessageBox.Show("确认删除该类货物及其库存？", "警告",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using var context = new OrdersContext();
                    var existingGoods = context.Goods
                        .FirstOrDefault(g => g.GoodsId == goods.GoodsId);
                    if (existingGoods != null)
                    {
                        // 修复：使用 Where 方法筛选关联的订单明细
                        var relatedOrderDetails = context.OrderDetails
                            .Where(o => o.GoodsId == existingGoods.GoodsId);
                        context.OrderDetails.RemoveRange(relatedOrderDetails);

                        // 再删除货物
                        context.Goods.Remove(existingGoods); // 必须用当前上下文查到的对象
                        context.SaveChanges(); // 确保更改被保存
                        RefreshBinding();
                    }
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
                    var newGoods = new Goods()
                    {
                        Name = editForm.GoodsName,
                        Price = editForm.UnitPrice
                    };
                    // 获取当前库存量
                    using var content = new OrdersContext();
                    var existingGoods = content.Goods
                        .FirstOrDefault(g => g.GoodsId == goods.GoodsId);
                    if (existingGoods == null) return;
                    // 更新库存信息
                    existingGoods.Name = newGoods.Name;
                    existingGoods.Price = newGoods.Price;
                    existingGoods.StockQuantity = goods.StockQuantity;
                    content.SaveChanges();
                    RefreshBinding();
                }
            }
        }

        // 辅助方法：获取选中货物
        private bool TryGetSelectedGoods(out Goods? goods)
        {
            if (StockGridView.CurrentRow?.Index >= 0)
            {
                using var context = new OrdersContext();
                var idFind = StockGridView.CurrentRow.Cells["goodsIdColumn"].Value;
                goods = context.Goods.
                    FirstOrDefault(g => g.GoodsId == Convert.ToInt32(idFind));
                Debug.Print($"选中货物：{goods}");
                return true;
            }
            MessageBox.Show("请先选择货物");
            goods = null;
            return false;
        }

        private void RefreshBinding()
        {
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