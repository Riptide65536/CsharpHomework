using OrderManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest
{
    [TestClass]
    public sealed class OrderTest
    {
        
        [TestMethod]
        public void OrderToStringTest()
        {
            Order test = new Order(0);
            test.AddDetail(new Goods("Apple", 0.99m), 10);
            test.AddDetail(new Goods("Pear", 1.05m), 5);
            string s = "Id: 0 Name: \n"
                     + "\tName: Apple, Price: 0.99, Amount: 10\n"
                     + "\tName: Pear, Price: 1.05, Amount: 5\n";
            CollectionAssert.Equals(test.ToString(), s);

        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void OrderAddDetailsTest1()
        {
            Order test = new Order(1);
            test.AddDetail(new Goods("Apple", 0.99m), 10);
            test.AddDetail(new Goods("Apple", 0.99m), 10);
        }
        [TestMethod]
        public void OrderAddDetailsTest2()
        {
            Order test = new Order(1);
            test.AddDetail(new Goods("Apple", 0.99m), 10);
            test.AddDetail(new Goods("Apple", 0.99m), 5);
            CollectionAssert.Equals(test.Details.Count, 2);
        }
        [TestMethod]
        public void OrderRemoveDetailsTest1()
        {
            Order test = new Order(2);
            test.AddDetail(new Goods("Apple", 0.99m), 7);
            test.AddDetail(new Goods("Pear", 1.05m), 5);
            test.AddDetail(new Goods("Banana", 2.25m), 5);
            CollectionAssert.Equals(test.Details.Count, 3);
            test.RemoveDetail(new OrderDetails("Pear", 1.05m, 5));
            CollectionAssert.Equals(test.Details.Count, 2);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void OrderRemoveDetailsTest2()
        {
            Order test = new Order(2);
            test.AddDetail(new Goods("Apple", 0.99m), 7);
            test.AddDetail(new Goods("Pear", 1.05m), 5);
            test.AddDetail(new Goods("Banana", 2.25m), 5);
            CollectionAssert.Equals(test.Details.Count, 3);
            test.RemoveDetail(new OrderDetails("Grapes", 3.3m, 1));
        }
        [TestMethod]
        public void OrderCaculateTotalTest()
        {
            Order test = new Order(2);
            test.AddDetail(new Goods("Apple", 0.99m), 7);
            test.AddDetail(new Goods("Pear", 1.05m), 5);
            test.AddDetail(new Goods("Banana", 2.25m), 5);
            CollectionAssert.Equals(test.CalculateTotal(), 23.43m);
        }
        [TestMethod]
        public void OrderEqualTest()
        {
            Order test = new Order(114);
            test.AddDetail(new Goods("Apple", 0.99m), 7);
            test.AddDetail(new Goods("Pear", 1.05m), 5);
            test.AddDetail(new Goods("Banana", 2.25m), 5);
            Order test2 = new Order(114);
            test2.AddDetail(new Goods("Apple", 0.99m), 7);
            test2.AddDetail(new Goods("Pear", 1.05m), 5);
            test2.AddDetail(new Goods("Banana", 2.25m), 5);
            Order test3 = new Order(514);
            test3.AddDetail(new Goods("Apple", 0.99m), 7);
            test3.AddDetail(new Goods("Pear", 1.05m), 5);
            test3.AddDetail(new Goods("Banana", 2.25m), 5);
            CollectionAssert.Equals(test.Equals(test2), true);
            CollectionAssert.Equals(test.Equals(test3), false);
        }
    }
}
