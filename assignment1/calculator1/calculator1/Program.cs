// See https://aka.ms/new-console-template for more information

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            char oper;
            string? s;

            Console.Write("Please input number 1: ");
            s = Console.ReadLine();
            num1 = Int32.Parse(s);
            Console.Write("Please input operation(+, -, *, /): ");
            s = Console.ReadLine();
            oper = Char.Parse(s);
            Console.Write("Please input number 2: ");
            s = Console.ReadLine();
            num2 = Int32.Parse(s);

            int result;
            switch (oper)
            {
                case '+': result = num1 + num2; break;
                case '-': result = num1 - num2; break;
                case '*': result = num1 * num2; break;
                case '/': 
                    if(num2 == 0)
                    {
                        Console.WriteLine("Error: the divisor can't be zero");
                        return;
                    }
                    else
                    {
                        result = num1 / num2;
                    }
                    break;
                default:
                    Console.WriteLine("Error: invalid operator");
                    return;
            }

            Console.WriteLine("The result is " + result);
            return;
        }
    }
}