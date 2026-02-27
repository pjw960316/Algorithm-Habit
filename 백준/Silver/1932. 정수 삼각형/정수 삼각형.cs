using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()
        int n = Int32.Parse(Console.ReadLine());
        
        var arr = new int[n+1,n+1];
        var dp = new int[n+1,n+1];
        
        for(int i=1; i<=n; i++)
        {
            var line = Console.ReadLine().Split();
            for(int j=1; j<=i; j++)
            {
                arr[i,j] = Int32.Parse(line[j-1]);
            }
        }
        
        for(int i=1; i<=n; i++)
        {
            for(int j=1; j<=i;j++)
            {
                if(j==1)
                {
                    dp[i,1] = dp[i-1,1] + arr[i,1];
                }
                else if(j==i)
                {
                    dp[i,i] = dp[i-1,i-1] + arr[i,i];
                }
                else
                {
                    dp[i,j] = Math.Max(dp[i-1,j-1],dp[i-1,j]) + arr[i,j];
                }
            }
        }
        
        int max = -1;
        for(int i=1; i<=n; i++)
        {
            if(max < dp[n,i])
            {
                max = dp[n,i];
            }
        }
        Console.WriteLine(max);
    }
}
