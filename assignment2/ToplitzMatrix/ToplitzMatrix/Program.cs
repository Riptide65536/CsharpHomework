using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

class Solution
{
    public static bool IsToplitzMatrix(int[,] arr)
    {
        // 判断是否为托普利茨矩阵
        int n = arr.GetLength(0);
        int m = arr.GetLength(1);
        int temp, x, y;

        // 判断右上三角形
        for (int i = 0; i < m; i++)
        {
            temp = arr[0, i];
            x = 0; y = i;
            while(x < n && y < m)
            {
                if (arr[x, y] != temp)
                    return false;
                x++; y++;
            }
        }

        // 判断左下三角形
        for (int i = 1; i < n; i++)
        {
            temp = arr[i, 0];
            x = i; y = 0;
            while (x < n && y < m)
            {
                if (arr[x, y] != temp)
                    return false;
                x++; y++;
            }
        }

        return true;
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
            if (!int.TryParse(input, out _))
            {
                Console.WriteLine("输入不合法！请重新输入！");
                continue;
            }
            int num = int.Parse(input);
            if (positive && num <= 0)
            {
                Console.WriteLine("输入必须为正！请重新输入！");
                continue;
            }
            return num;
        }
    }

    static void Main(string[] args)
    {
        int n = getInt("请输入矩阵行数：", true);
        int m = getInt("请输入矩阵列数：", true);
        int [,]arr = new int[n, m];
        Console.Write("请输入矩阵的项：");
        for(int i=0; i<n; i++)
        {
            for(int j=0; j<m; j++)
            {
                arr[i, j] = getInt("");
            }
        }

        bool res = Solution.IsToplitzMatrix(arr);
        Console.WriteLine("这个矩阵" + (res ? "是" : "不是") + "托普利茨矩阵。");
    }
}

