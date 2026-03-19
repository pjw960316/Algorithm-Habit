using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
public class CSharpHabit
{
    static void Main()
    {
        var dp = new long[102];
        dp[1] = 1;
        dp[2] = 1;
        dp[3] = 1;
        dp[4] = 2;

        for (int i = 5; i <= 100; i++)
        {
            dp[i] = dp[i - 3] + dp[i - 2];
        }

        
        int tcMax = int.Parse(Console.ReadLine());
        var sb = new StringBuilder();
        
        for (int tc = 0; tc < tcMax; tc++)
        {
            int n = int.Parse(Console.ReadLine());
            
            sb.Append(dp[n]);
            sb.AppendLine();
        }
        
        Console.Write(sb);
    }
}