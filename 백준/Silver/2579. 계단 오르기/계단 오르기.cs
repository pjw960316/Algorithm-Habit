using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
public class CSharpHabit
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var arr = new int[302];
        var dp = new int[302,4];
        
        for (int i = 1; i <= n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        dp[1, 1] = arr[1];
        dp[1, 2] = arr[1]; // 특수케이스
        dp[2, 1] = arr[2];
        dp[2, 2] = arr[1] + arr[2];

        for (int i = 3; i <= n; i++)
        {
            dp[i, 1] = Math.Max(dp[i - 2, 1], dp[i - 2, 2]) + arr[i];
            dp[i, 2] = dp[i - 1, 1] + arr[i];
        }

        Console.Write(Math.Max(dp[n, 1], dp[n, 2]));
    }
}
