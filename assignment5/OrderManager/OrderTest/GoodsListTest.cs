using OrderManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest
{
    [TestClass]
    public sealed class GoodsListTest
    {
        Goods apple = new Goods("Apples", 0.99m);
        Goods pear = new Goods("Pears", 1.25m);
        Goods cherry = new Goods("Cherry", 1.12m);
        Goods banana = new Goods("Banana", 0.80m);

        [TestMethod]
        public void AddStockTest()
        {
            GoodsList goodsList = new();
            goodsList.AddStock(apple, 100);
            CollectionAssert.Equals(goodsList.CheckStock(apple), 100);
            goodsList.AddStock(new Goods("Apples", 0.99m), 100);
            goodsList.AddStock(new Goods("Pears", 1.25m), 100);
            CollectionAssert.Equals(goodsList.CheckStock(apple), 200);
            CollectionAssert.Equals(goodsList.CheckStock(pear), 100);
        }

        [TestMethod]
        public void ReduceStockTest1()
        {
            GoodsList goodsList = new();
            goodsList.AddStock(apple, 200);
            goodsList.ReduceStock(apple, 100);
            CollectionAssert.Equals(goodsList.CheckStock(apple), 100);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ReduceStockTest2()
        {
            GoodsList goodsList = new();
            goodsList.AddStock(apple, 200);
            goodsList.ReduceStock(apple, 1000);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ReduceStockTest3()
        {
            GoodsList goodsList = new();
            goodsList.AddStock(apple, 200);
            goodsList.ReduceStock(pear, 100);
        }
        [TestMethod]
        public void CheckStockTest1()
        {
            GoodsList goodsList = new();
            goodsList.AddStock(apple, 150);
            goodsList.AddStock(pear, 250);
            goodsList.AddStock(cherry, 200);
            goodsList.AddStock(banana, 100);

            CollectionAssert.Equals(goodsList.CheckStock(banana), 100);
            CollectionAssert.Equals(goodsList.CheckStock(cherry), 200);
            CollectionAssert.Equals(goodsList.CheckStock(pear), 250);
            CollectionAssert.Equals(goodsList.CheckStock(apple), 150);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CheckStockTest2()
        {
            GoodsList goodsList = new();
            goodsList.AddStock(apple, 150);
            goodsList.AddStock(pear, 250);

            CollectionAssert.Equals(goodsList.CheckStock(banana), 100);
            CollectionAssert.Equals(goodsList.CheckStock(cherry), 200);
        }
    }
}
