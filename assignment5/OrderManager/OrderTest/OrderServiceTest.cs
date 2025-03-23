using OrderManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest
{
    [TestClass]
    public sealed class OrderServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddOrderTest1()
        {
            OrderService orderService = new OrderService();
            Order order1 = new Order(1);
            order1.AddDetail(new Goods("Apple", 0.99m), 10);
            order1.AddDetail(new Goods("Pear", 1.05m), 5);
            orderService.AddOrder(order1);

            Order order2 = new Order(1);
            order2.AddDetail(new Goods("Apple", 0.99m), 10);
            order2.AddDetail(new Goods("Pear", 1.05m), 5);
            orderService.AddOrder(order2);
        }
        [TestMethod]
        public void AddOrderTest2()
        {
            OrderService orderService = new OrderService();
            Order order1 = new Order(1);
            order1.AddDetail(new Goods("Apple", 0.99m), 10);
            order1.AddDetail(new Goods("Pear", 1.05m), 5);
            orderService.AddOrder(order1);

            Order order2 = new Order(2);
            order2.AddDetail(new Goods("Apple", 0.99m), 10);
            order2.AddDetail(new Goods("Pear", 1.05m), 5);
            orderService.AddOrder(order2);

            CollectionAssert.Equals(orderService.Orders.Count, 2);
        }
        [TestMethod]
        public void RemoveOrderTest()
        {
            OrderService orderService = new OrderService();
            Order order1 = new Order(1);
            order1.AddDetail(new Goods("Apple", 0.99m), 10);
            order1.AddDetail(new Goods("Pear", 1.05m), 5);
            orderService.AddOrder(order1);

            Order order2 = new Order(2);
            order2.AddDetail(new Goods("Apple", 0.99m), 10);
            order2.AddDetail(new Goods("Pear", 1.05m), 5);
            orderService.AddOrder(order2);

            orderService.RemoveOrder(1);
            CollectionAssert.Equals(orderService.Orders[0].Id, 2);
        }
        [TestMethod]
        public void UpdateTest()
        {
            OrderService orderService = new OrderService();
            Order order1 = new Order(1);
            order1.AddDetail(new Goods("Apple", 0.99m), 10);
            order1.AddDetail(new Goods("Pear", 1.05m), 5);
            orderService.AddOrder(order1);

            Order order2 = new Order(2);
            order2.AddDetail(new Goods("Apple", 0.99m), 10);
            order2.AddDetail(new Goods("Pear", 1.05m), 5);
            orderService.AddOrder(order2);

            Order order3 = new Order(2);
            order3.AddDetail(new Goods("Grapes", 1.25m), 3);
            order3.AddDetail(new Goods("Pineapple", 6.6m), 1);

            orderService.UpdateOrder(2, order3);
            CollectionAssert.Equals(orderService.Orders[1], order3);
        }
        [TestMethod]
        public void SearchOrdersTest()
        {
            OrderService orderService = new OrderService();
            Order order1 = new Order(1);
            order1.AddDetail(new Goods("Apple", 0.99m), 10);
            order1.AddDetail(new Goods("Pear", 1.05m), 5);
            orderService.AddOrder(order1);

            Order order2 = new Order(2);
            order2.AddDetail(new Goods("Apple", 0.99m), 10);
            order2.AddDetail(new Goods("Pear", 1.05m), 5);
            orderService.AddOrder(order2);

            Order order3 = new Order(3);
            order3.AddDetail(new Goods("Grapes", 1.25m), 3);
            order3.AddDetail(new Goods("Pineapple", 6.6m), 1);
            orderService.AddOrder(order3);

            var sel = orderService.SearchOrders(x => x.Id == 2).ToList();
            CollectionAssert.Equals(new List<Order> { order2 }, sel);

        }
        [TestMethod]
        public void SortOrdersTest1()
        {
            OrderService orderService = new OrderService();
            Order order1 = new Order(5);
            order1.AddDetail(new Goods("1", 125m), 10);
            orderService.AddOrder(order1);

            Order order2 = new Order(2);
            order2.AddDetail(new Goods("2", 99m), 5);
            orderService.AddOrder(order2);

            Order order3 = new Order(1);
            order3.AddDetail(new Goods("3", 33m), 100);
            orderService.AddOrder(order3);

            Order order4 = new Order(3);
            order4.AddDetail(new Goods("4", 100m), 3);
            orderService.AddOrder(order3);

            orderService.SortOrders(null);
            var t = from o in orderService.GetAllOrders() 
                    select o.Details[0].Item.Name;
            var res = t.ToList();

            CollectionAssert.Equals(res, new List<string>{ "3", "2", "1", "4" });
        }
        [TestMethod]
        public void SortOrdersTest2()
        {
            OrderService orderService = new OrderService();
            Order order1 = new Order(5);
            order1.AddDetail(new Goods("1", 125m), 10);
            orderService.AddOrder(order1);

            Order order2 = new Order(2);
            order2.AddDetail(new Goods("2", 99m), 5);
            orderService.AddOrder(order2);

            Order order3 = new Order(1);
            order3.AddDetail(new Goods("3", 33m), 100);
            orderService.AddOrder(order3);

            Order order4 = new Order(3);
            order4.AddDetail(new Goods("4", 100m), 3);
            orderService.AddOrder(order3);

            var res = from o in orderService.GetAllOrders()
                      orderby o.Details[0].Item.Price
                      select o.Details[0].Item.Name
                      .ToList();

            CollectionAssert.Equals(res, new List<string> { "3", "2", "4", "1" });
        }
    }
}
