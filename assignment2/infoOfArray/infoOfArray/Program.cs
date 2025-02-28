using System.Collections.Specialized;

class Solution
{
    public static int MaxOfArray(int[] arr)
    {
        if (arr.Length == 0)
        {
            throw new Exception("The value does not exist!");
        }
        int ans = arr[0];
        foreach(int i in arr)
        {
            ans = Math.Max(ans, i);
        }
        return ans;
    }

    public static int MinOfArray(int[] arr)
    {
        if(arr.Length == 0)
        {
            throw new Exception("The value does not exist!");
        }
        int ans = arr[0];
        foreach (int i in arr)
        {
            ans = Math.Min(ans, i);
        }
        return ans;
    }

    public static int SumOfArray(int[] arr)
    {
        int ans = 0;
        foreach (int i in arr)
        {
            ans += i;
        }
        return ans;
    }

    public static double AverageOfArray(int[] arr)
    {
        if (arr.Length == 0)
        {
            throw new Exception("The value does not exist!");
        }
        int n = arr.Length;
        return (double)SumOfArray(arr) / n;
    }
}



internal class Program
{
    static int GetNum(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();
            if(!int.TryParse(input, out _))
            {
                Console.WriteLine("输入错误！请重新输入！");
                continue;
            }

            int num = int.Parse(input);
            return num;
        }
    }
    static void Main(string[] args)
    {
        int n = GetNum("请输入数组大小：");
        if (n < 0)
        {
            Console.WriteLine("数组大小不能为负！");
            return;
        }
        int []arr = new int[n];
        if(n > 0) 
            Console.WriteLine("请输入数组元素（换行以切换下一元素）：");
        
        for (int i=0; i<n; i++)
        {
            int element = GetNum("");
            arr[i] = element;
        }

        try
        {
            int maxVal = Solution.MaxOfArray(arr);
            Console.WriteLine($"最大值：{maxVal}");
        }
        catch (Exception)
        {
            Console.WriteLine("最大值：不存在");
        }

        try
        {
            int minVal = Solution.MinOfArray(arr);
            Console.WriteLine($"最小值：{minVal}");
        }
        catch (Exception)
        {
            Console.WriteLine("最小值：不存在");
        }

        try
        {
            double average = Solution.AverageOfArray(arr);
            Console.WriteLine($"平均值：{average}");
        }
        catch (Exception)
        {
            Console.WriteLine("平均值：不存在");
        }

        int sum = Solution.SumOfArray(arr);
        Console.WriteLine($"数组元素和：{sum}");

    }
}