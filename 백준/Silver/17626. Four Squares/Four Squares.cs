using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
public class CSharpHabit
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var dp = new int[50002];
        var hashSet = new HashSet<int>();
        
        for (int i = 1; i <= 50000; i++)
        {
            if (i * i > 50000)
            {
                break;
            }

            hashSet.Add(i * i);
        }
        for (int idx = 0; idx <= 50000; idx++)
        {
            if (hashSet.Contains(idx))
            {
                dp[idx] = 1;
            }
            else
            {
                dp[idx] = 10;
            }
        }
        
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j * j <= i; j++)
            {
                dp[i] = Math.Min(dp[i], dp[i-j*j] + 1);
            }
        }

        
        Console.Write(dp[n]);
    }
}

