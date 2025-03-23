using OrderManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest
{
    [TestClass]
    public sealed class GoodsTest
    {
        [TestMethod]
        public void ToStringTest()
        {
            Goods g1 = new Goods("Apple", 1.88m);
            Goods g2 = new Goods("Pear", 0.99m);

            string s1 = g1.ToString();
            string t1 = "Name: Apple, Price: 1.88";
            CollectionAssert.Equals(s1, t1);

            string s2 = g2.ToString();
            string t2 = "Name: Pear, Price: 0.99";
            CollectionAssert.Equals(s2, t2);
        }
        [TestMethod]
        public void EqualsTest()
        {
            Goods g1 = new Goods("Apple", 1.88m);
            Goods g1_1 = g1;
            Goods g2 = new Goods("Apple", 1.88m);
            Goods g3 = new Goods("Pears", 1.88m);
            Goods g4 = new Goods("Apple", 0.5m); // 降价后的苹果

            CollectionAssert.Equals(g1.Equals(g1_1), true);
            CollectionAssert.Equals(g1.Equals(g2), true);
            CollectionAssert.Equals(g1.Equals(g3), false);
            CollectionAssert.Equals(g1.Equals(g4), false);
        }
    }
}
