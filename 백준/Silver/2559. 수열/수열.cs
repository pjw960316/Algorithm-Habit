using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()
        
        var line = Console.ReadLine().Split();
        int n = Int32.Parse(line[0]);
        int k = Int32.Parse(line[1]);
        
        var arr = new int[n+1];
        var dp = new int[n+1];

        line = Console.ReadLine().Split();
        
        for(int i=0; i<n; i++)
        {
            arr[i+1] = Int32.Parse(line[i]);
        }
        
        int sum =0;
        for(int i=1; i<=k; i++)
        {
            sum += arr[i];
        }
        dp[k] = sum;
        
        for(int i=k+1; i<=n; i++)
        {
            dp[i] = dp[i - 1] + arr[i] - arr[i - k];
        }

        int max = -100 * 200000;
        for(int i=k; i<=n; i++)
        {
            max = Math.Max(max,dp[i]);
            //Console.Write($"{dp[i]} ");
        }
        
        //Console.WriteLine();
        Console.WriteLine(max);
    }
}