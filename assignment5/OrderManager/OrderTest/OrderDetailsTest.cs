using OrderManager;

namespace OrderTest;

[TestClass]
public class OrderDetailsTest
{
    [TestMethod]
    public void OrderDetailsToStringTest()
    {
        OrderDetails od1 = new OrderDetails("Book", 300m, 2);
        Goods g = new Goods("Apple", 1.99m);
        OrderDetails od2 = new OrderDetails(g, 5);

        string s1 = od1.ToString();
        string t1 = "Name: Book, Price: 300, Amount: 2";
        CollectionAssert.Equals(s1, t1);

        string s2 = od2.ToString();
        string t2 = "Name: Apple, Price: 1.99, Amount: 5";
        CollectionAssert.Equals(s2, t2);
    }
    [TestMethod]
    public void OrderDetailsEqualsTest()
    {
        OrderDetails od1 = new OrderDetails("Book", 300m, 2);
        OrderDetails od2 = new OrderDetails("Book", 300m, 2);
        OrderDetails od3 = new OrderDetails("Apples", 0.99m, 5);
        OrderDetails od4 = new OrderDetails("Refigrators", 300m, 3);
        OrderDetails od5 = new OrderDetails("Book", 300m, 2);

        CollectionAssert.Equals(od1.Equals(od2), true);
        CollectionAssert.Equals(od1.Equals(od3), false);
        CollectionAssert.Equals(od1.Equals(od4), true);
        CollectionAssert.Equals(od1.Equals(od5), true);
        Assert.IsTrue(od1.Equals(od2));
    }
}
