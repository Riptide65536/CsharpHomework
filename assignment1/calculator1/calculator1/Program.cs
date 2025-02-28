// See https://aka.ms/new-console-template for more information

namespace project
{
    class Program
    {
        static double GetNum(string prompt)
        {
            string? input;
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if(input == null)
                {
                    Console.WriteLine("输入不可为空！");
                }
                else if(!double.TryParse(input, out _))
                {
                    Console.WriteLine("输入不合法！");
                }
                else
                {
                    double num = double.Parse(input);
                    return num;
                }
            }
        }

        static char GetOper(string prompt)
        {
            string? input;
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("输入不可为空！");
                }
                else if (input.Length != 1 || !"+-*/".Contains(input[0]))
                {
                    Console.WriteLine("输入不合法！");
                }
                else
                {
                    return input[0];
                }
            }
        }

        static void Main(string[] args)
        {
            double num1, num2;
            char oper;

            num1 = GetNum("请输入第1个数：");
            oper = GetOper("请输入运算符（+，-，*，/）：");
            num2 = GetNum("请输入第2个数：");

            double result;
            switch (oper)
            {
                case '+': result = num1 + num2; break;
                case '-': result = num1 - num2; break;
                case '*': result = num1 * num2; break;
                case '/': 
                    if(num2 == 0)
                    {
                        Console.WriteLine("错误：不能除以0！");
                        return;
                    }
                    else
                    {
                        result = num1 / num2;
                    }
                    break;
                default:
                    Console.WriteLine("错误：计算符不合法！");
                    return;
            }

            Console.WriteLine($"{num1} {oper} {num2} = {result}");
            return;
        }
    }
}