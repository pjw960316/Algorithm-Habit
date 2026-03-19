using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
public class CSharpHabit
{
    static void Main()
    {
        var dp = new int[1002];
        dp[1] = 1;
        dp[2] = 2;
        dp[3] = 3;
        dp[4] = 5;

        for (int i = 5; i <= 1000; i++)
        {
            dp[i] = (dp[i - 2]  + dp[i - 1]) % 10007;
        }

        int n = int.Parse(Console.ReadLine());

        Console.Write(dp[n]);
    }
}