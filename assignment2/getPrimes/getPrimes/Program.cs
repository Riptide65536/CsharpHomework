using System.Text;

class Solution
{
    public static List<int> GetPrimes(int n)
    {
        // 埃氏筛获取从1~n的质数
        bool[] isNotPrime = new bool[n+1];
        for(int i=0; i<=n; i++)
        {
            isNotPrime[i] = false;
        }
        List<int> primes = [];
        isNotPrime[0] = true;
        isNotPrime[1] = true;
        if (n <= 1) return primes;

        for(int i=2; i<=n; i++)
        {
            if (!isNotPrime[i])
            {
                primes.Add(i);
            }
            for (int j = i * i; j <= n; j += i)
            {
                isNotPrime[j] = true;
            }
        }

        return primes;
    }

    public static List<int> GetPrimes2(int n)
    {
        // 欧拉筛获取从1~n的质数
        bool[] isNotPrime = new bool[n + 1];
        for (int i = 0; i <= n; i++)
        {
            isNotPrime[i] = false;
        }
        List<int> primes = [];
        isNotPrime[0] = true;
        isNotPrime[1] = true;
        if (n <= 1) return primes;

        for (int i = 2; i <= n; i++)
        {
            if (!isNotPrime[i])
            {
                primes.Add(i);
            }
            for (int j = 0; j < primes.Count && i * primes[j] <= n; j++)
            {
                isNotPrime[i * primes[j]] = true;
                if (i % primes[j] == 0) break;
            }
        }

        return primes;
    }
}



internal class Program
{
    static int getInt(string prompt, bool positive = false)
    {
        // 从输入流中保证输入整数
        // 若positive为true，则保证输入正数
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();
            if(!int.TryParse(input, out _))
            {
                Console.WriteLine("输入不合法！请重新输入！");
                continue;
            }
            int num = int.Parse(input);
            if(positive && num <= 0)
            {
                Console.WriteLine("输入必须为正！请重新输入！");
                continue;
            }
            return num;
        }
        

    }
    static void Main(string[] args)
    {
        int n = getInt("请输入一个正整数", true);
        List<int> list1 = Solution.GetPrimes(n);
        List<int> list2 = Solution.GetPrimes2(n);

        Console.WriteLine($"方案1：从1~{n}的质数有：");
        foreach(int prime in list1)
        {
            Console.Write("" + prime + " ");
        }
        Console.WriteLine();
        Console.WriteLine($"方案2：从1~{n}的质数有：");
        foreach (int prime in list2)
        {
            Console.Write("" + prime + " ");
        }
    }
}

