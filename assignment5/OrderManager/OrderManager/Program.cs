using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace OrderManager
{
    internal class Program
    {
        // 初始化货物列表以及需要的东西
        static Dictionary<Goods, int> inventory = new()
        {
            [new Goods("apple", 0.99m)] = 100,
            [new Goods("banana", 0.85m)] = 200,
            [new Goods("pear", 1.25m)] = 250,
            [new Goods("grape", 1.56m)] = 150,
            [new Goods("cherry", 0.55m)] = 600,
            [new Goods("melon", 3.2m)] = 50
        };
        static GoodsList goodsList = new GoodsList(inventory);

        // 初始化订单处理程序以及清单
        static OrderService orderService = new();
        static int curId = 0;

        static void PrintAllOrders()
        {
            foreach(Order o in orderService.GetAllOrders())
            {
                Console.WriteLine(o.ToString());
            }
        }

        static void PrintAllStock()
        {
            Console.WriteLine(goodsList.ToString());
        }

        static void ViewAllOrders()
        {
            // 页面0：查看全部订单
            Console.Clear();
            if(orderService.Orders.Count == 0)
            {
                Console.WriteLine("还没有任何订单！");
                Console.ReadLine();
                return;
            }
            
            string? oper;
            Console.WriteLine("请选择排序方式：(0): 按照Id  1：按照姓名  2：按照金额倒序");
                
            bool isValid = true;
            do
            {
                oper = Console.ReadLine();
                if (oper == "" || oper == "0" || oper == null)
                {
                    orderService.SortOrders(null);
                    isValid = true;
                }
                else if (oper == "1")
                {
                    orderService.SortOrders(o => o.customer);
                    isValid = true;
                }
                else if (oper == "2")
                {
                    orderService.SortOrders(o => o.CalculateTotal(), true);
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("非法输入！请重新输入！");
                    isValid = false;
                }
            } while (!isValid);

            PrintAllOrders();
            Console.WriteLine("按回车键继续");
            Console.ReadLine();
        }

        static void AddOrders()
        {
            // 页面1：添加订单
            Console.WriteLine("请输入购买者姓名：");
            string? name;
            do
            {
                name = Console.ReadLine();
            } while (name == null);
            Order order = new Order(curId, name); curId++;
            
            // 添加订单明细，最后确认订单
            do
            {
                Console.Clear();
                Console.WriteLine("当前存货：");
                PrintAllStock();
                Console.WriteLine("当前订单信息：");
                Console.WriteLine(order.ToString());
                Console.WriteLine($"\t\ttotalPrice: {order.CalculateTotal()}");

                List<Goods> goods = goodsList.Inventory.Keys.ToList();

                Console.WriteLine("请输入需要添加的货物Id号，或者输入q退出：");
                string? input = Console.ReadLine();
                if (input == "q") break;
                bool success = int.TryParse(input, out int id);
                if (!success || id < 0 || id >= goods.Count)
                {
                    Console.WriteLine("输入不合法！请重新输入！");
                    Console.ReadLine();
                    continue;
                }

                Console.WriteLine($"选择商品：{goods[id].Name}。请输入需要购买的数量：");
                input = Console.ReadLine();
                bool success2 = int.TryParse(input, out int amount);
                if (!success2 || amount <= 0 || amount > goodsList.CheckStock(goods[id]))
                {
                    Console.WriteLine("输入不合法！请重新输入！");
                    Console.ReadLine();
                    continue;
                }

                try
                {
                    order.AddDetail(goods[id], amount);
                    goodsList.ReduceStock(goods[id], amount);
                    Console.WriteLine("添加信息成功！按回车键继续");
                    Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("添加信息失败！！按回车键继续");
                    Console.ReadLine();
                }
            } while (true);

            try
            {
                orderService.AddOrder(order);
                Console.WriteLine("添加订单成功！按回车键退出");
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("添加信息失败！！按回车键退出");
                Console.ReadLine();
            }
        }

        static void EditOrders()
        {
            // 页面2：编辑订单（查询，修改，删除）
            // 查询部分
            Console.Clear();
            
            string? oper;
            Console.WriteLine("请选择需要查询的订单：0: 按Id  1：按名称  2：按金额");
            List<Order>? searchResult = new();

            string? input;
            bool isValid;
            do
            {
                oper = Console.ReadLine();
                if (oper == null || oper == "0")
                {
                    Console.WriteLine("请输入需要查找的Id：");
                    input = Console.ReadLine();
                    isValid = int.TryParse(input, out int i);
                    if(!isValid)
                    {
                        Console.WriteLine("非法输入！请重新输入！");
                        Console.ReadLine();
                        continue;
                    }
                    searchResult = orderService
                            .SearchOrders(o => o.Id == i)
                            .ToList();
                }
                else if (oper == "1")
                {
                    Console.WriteLine("请输入需要查找的姓名：");
                    input = Console.ReadLine();
                    searchResult = orderService
                        .SearchOrders(o => o.customer == input)
                        .ToList();
                    isValid = true;
                }
                else if (oper == "2")
                {
                    Console.WriteLine("请输入大于（0）还是小于（1）：");
                    input = Console.ReadLine();
                    isValid = int.TryParse(input, out int op);
                    if (!isValid || (op != 0 && op != 1))
                    {
                        Console.WriteLine("非法输入！请重新输入！");
                        continue;
                    }

                    isValid = int.TryParse(input, out int bound);
                    if (!isValid)
                    {
                        Console.WriteLine("非法输入！请重新输入！");
                        continue;
                    }

                    if (op==0)
                    {
                        searchResult = orderService.
                            SearchOrders(o => o.CalculateTotal() > bound)
                            .ToList();
                    }
                    else
                    {
                        searchResult = orderService.
                            SearchOrders(o => o.CalculateTotal() < bound)
                            .ToList();
                    }
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("非法输入！请重新输入！");
                    isValid = false;
                }
            } while (!isValid);

            // 输出结果
            
            if(searchResult.Count == 0)
            {
                Console.WriteLine("尚未找到任何订单！请按回车键继续");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("寻找到订单信息如下：");
            searchResult.ForEach(o => Console.WriteLine(o.ToString()));

            // 询问进一步操作（修改，删除等操作）
            Console.WriteLine("请选择需要执行的操作：（0）:退出  1：修改指定订单  2：删除指定订单");
            List<string> options = ["", "0", "1", "2"];
            do
            {
                input = Console.ReadLine();
                if(input == null || !options.Contains(input))
                {
                    Console.WriteLine("非法输入！请重新输入！"); 
                    Console.ReadLine();
                    continue;
                }

                if (input == "" || input == "0") break;

                Console.WriteLine("请输入需要操作的订单Id号：");
                input = Console.ReadLine();
                isValid = int.TryParse(input, out int id);
                if (!isValid)
                {
                    Console.WriteLine("非法输入！请重新输入！");
                    Console.ReadLine();
                    continue;
                }
                Order? target = searchResult.Find(o => o.Id == id);
                if(target == null)
                {
                    Console.WriteLine("抱歉，订单号不存在！请重新操作！");
                    Console.ReadLine();
                    continue;
                }

                if(input == "2")
                {
                    orderService.RemoveOrder(id);
                    Console.WriteLine("订单删除成功！");
                    Console.ReadLine();
                    break;
                }

                orderService.UpdateOrder(id, ModifyOrder(target));
                Console.WriteLine("订单修改成功！");
                Console.ReadLine();
                break;


            } while (true);
        }

        static Order ModifyOrder(Order order)
        {
            List<string> options = ["", "q", "1", "2"];
            string? input;
            do
            {
                Console.Clear();
                Console.WriteLine(order.ToString());

                // 选择操作（(q)退出，1：添加明细，2：删除明细）
                Console.WriteLine("请选择操作，(q)退出，1：添加明细，2：删除明细：");
                input = Console.ReadLine();
                if(input == null || !options.Contains(input))
                {
                    Console.WriteLine("非法输入！请重新输入！");
                    Console.ReadLine();
                    continue;
                }

                if (input == "" || input == "q") break;

                if(input == "2")
                {
                    Console.WriteLine("请选择需要删除的明细行：");
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out int line) || line < 0 || line >= order.Details.Count)
                    {
                        Console.WriteLine("输入不合法！请重新输入！");
                        Console.ReadLine();
                        continue;
                    }

                    order.RemoveDetail(order.Details[line]);
                    Console.WriteLine("删除明细成功！");
                    Console.ReadLine();
                    continue;
                }
                
                List<Goods> goods = goodsList.Inventory.Keys.ToList();
                PrintAllStock();
                Console.WriteLine("请输入需要添加的货物Id号：");
                input = Console.ReadLine();
                bool success = int.TryParse(input, out int id);
                if (!success || id < 0 || id >= goods.Count)
                {
                    Console.WriteLine("输入不合法！请重新输入！");
                    Console.ReadLine();
                    continue;
                }

                Console.WriteLine($"选择商品：{goods[id].Name}。请输入购买数量：");
                input = Console.ReadLine();
                bool success2 = int.TryParse(input, out int amount);
                if (!success2 || amount <= 0)
                {
                    Console.WriteLine("输入不合法！请重新输入！");
                    Console.ReadLine();
                    continue;
                }

                try
                {
                    order.AddDetail(goods[id], amount);
                    Console.WriteLine("添加信息成功！按回车键继续");
                    Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("添加信息失败！！按回车键继续");
                    Console.ReadLine();
                }
            } while (input != "q");

            return order;
        }

        static void ModifyInventory()
        {
            // 页面3：修改存货
            // 选择操作（进货，出货，添加货物种类）
            List<string> options = ["", "q", "1", "2", "3"];
            string? input;
            List<Goods> goods = goodsList.Inventory.Keys.ToList();
            do
            {
                Console.Clear();
                PrintAllStock();

                // 选择操作（(q)退出，1：添加明细，2：删除明细）
                Console.WriteLine("请选择操作，(q)退出，1：进货，2：出货，3：添加货物种类");
                input = Console.ReadLine();
                if (input == null || !options.Contains(input))
                {
                    Console.WriteLine("非法输入！请重新输入！");
                    Console.ReadLine();
                    continue;
                }

                if (input == "" || input == "q") break;

                if (input == "1" || input == "2")
                {
                    Console.WriteLine("请输入需要添加的货物Id号，或者输入q退出：");
                    string? input2 = Console.ReadLine();

                    if (input2 == "q") break;
                    if (!int.TryParse(input2, out int res) || res < 0 || res >= goods.Count)
                    {
                        Console.WriteLine("输入不合法！请重新输入！");
                        Console.ReadLine();
                        continue;
                    }

                    Console.WriteLine($"选择商品：{goods[res].Name}。请输入改变量：");
                    input2 = Console.ReadLine();
                    bool success2 = int.TryParse(input2, out int amount);
                    if (!success2 || amount < 0)
                    {
                        Console.WriteLine("输入不合法！请重新输入！");
                        Console.ReadLine();
                        continue;
                    }

                    try
                    {
                        if(input == "1")
                        {
                            goodsList.AddStock(goods[res], amount);
                            Console.WriteLine("进货成功！");
                        }
                        else
                        {
                            goodsList.ReduceStock(goods[res], amount);
                            Console.WriteLine("出货成功！");
                        }

                        Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("发生错误！请重试！");
                        Console.ReadLine();
                    }

                    continue;
                }

                try
                {
                    string? inputn;
                    Console.WriteLine("请依次输入名字，单价和存入量，每个按回车切换：");
                    inputn = Console.ReadLine();
                    if (inputn == null)
                    {
                        Console.WriteLine("非法输入！请重新输入！");
                        continue;
                    }
                    string name = inputn;

                    inputn = Console.ReadLine(); 
                    if(inputn == null) {
                        Console.WriteLine("非法输入！请重新输入！");
                        continue;
                    }
                    decimal unitPrice = decimal.Parse(inputn);

                    inputn = Console.ReadLine();
                    if (inputn == null)
                    {
                        Console.WriteLine("非法输入！请重新输入！");
                        continue;
                    }
                    int startAmount = int.Parse(inputn);

                    Goods g = new Goods(name, unitPrice);
                    goodsList.AddStock(g, startAmount);

                    Console.WriteLine("添加种类成功！");
                    Console.ReadLine();
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("发生错误！请重试！");
                    Console.ReadLine();
                }
                

            } while (!(input == "" || input == "q"));
        
        }

        static void Main(string[] args)
        {
            var menu = new ConsoleMenu("欢迎使用订单处理程序（管理员）")
                    .AddOption("0", "查看全部订单", ViewAllOrders)
                    .AddOption("1", "添加订单", AddOrders)
                    .AddOption("2", "编辑订单", EditOrders)
                    .AddOption("3", "修改存货", ModifyInventory);
            menu.AddOption("q", "退出程序", menu.turnOff);
            menu.turnOn();

            menu.Show();

            Console.WriteLine("感谢您的使用。");
            return;
        }
    }
}
