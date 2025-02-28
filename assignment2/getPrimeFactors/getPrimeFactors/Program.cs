
class Solution
{
    public static List<int> GetPrimeFactors(int num)
    {
        List<int> ans = [];
        if(num <= 1)    // 为了保证健壮性从而防止的
        {
            return ans;
        }

        if(num % 2 == 0)
        {
            ans.Add(2);
            while (num % 2 == 0) num /= 2;
        }
        for(int i=3; i*i<=num; i+=2)
        {
            if(num % i == 0)
            {
                ans.Add(i);
                while (num % i == 0) num /= i;
            }
        }

        if(num > 1)
        {
            ans.Add(num);
        }

        return ans;
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("请输入整数：");
        string? s = Console.ReadLine();

        if(!int.TryParse(s, out _))
        {
            Console.WriteLine("输入错误！");
            return;
        }
        
        int num = int.Parse(s);

        List<int> ans = Solution.GetPrimeFactors(num);

        if(ans.Count == 0)
        {
            Console.WriteLine($"{num}没有质因数。");
            return;
        }
        
        Console.Write($"{num}的质因数有：");
        foreach (int n in ans)
        {
            Console.Write("" + n + " ");
        }
        return;
    }
}