namespace GernericList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> intList = new GenericList<int>();
            Random ran = new();
            for(int x = 0; x < 10; x++)
            {
                intList.Add(ran.Next(0, 100));
            }

            // 逐个打印列表元素：
            intList.ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();

            // 求最大，最小值
            int maxVal = int.MinValue, minVal = int.MaxValue;
            intList.ForEach(x => {
                if(x > maxVal) maxVal = x;
                if(x < minVal) minVal = x;
            });

            Console.WriteLine($"Maxval: {maxVal}, Minval: {minVal}");

            // 求和
            int sum = 0;
            sum = intList.Fold(0, (a, b) => a + b);

            Console.WriteLine($"Sum of the list: {sum}");
        }
    }
}
