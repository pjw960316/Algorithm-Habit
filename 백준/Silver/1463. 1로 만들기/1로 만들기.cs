using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()

        int n = int.Parse(Console.ReadLine());
        var dp = new int[1000002];

        dp[1] = 0;
        dp[2] = 1;
        dp[3] = 1;

        for (int i = 4; i <= n; i++)
        {
            if (i % 6 == 0)
            {
                int tmp = Math.Min(dp[i / 3], dp[i / 2]);
                dp[i] = Math.Min(tmp, dp[i - 1]) + 1;

                continue;
            }
            if (i % 3 == 0)
            {
                dp[i] = Math.Min(dp[i / 3], dp[i - 1]) + 1;
                continue;
            }

            if (i % 2 == 0)
            {
                dp[i] = Math.Min(dp[i / 2], dp[i - 1]) + 1;
                continue;
            }
            else
            {
                dp[i] = dp[i - 1] + 1;
            }
        }

        //Print();
        
        Console.Write(dp[n]);

        void Print()
        {
            for (int i = 1; i <= n; i++)
            {
                Console.Write($"{dp[i]} ");
            }
        }
    }
}