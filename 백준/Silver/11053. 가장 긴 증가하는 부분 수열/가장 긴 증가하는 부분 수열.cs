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
        var line = Console.ReadLine().Split();
        var arr = new int[n];
        var dp = new int[n];
        
        for(int i=0; i<n; i++)
        {
            arr[i] = Int32.Parse(line[i]);
            dp[i] = 1;
        }
        
        int max = -1;
        
        for(int i=1; i<n; i++)
        {
            max = -1;
            for(int j=0; j<i; j++)
            {
                if(arr[j] < arr[i] && max < dp[j] + 1)
                {
                    dp[i] = dp[j] + 1;
                    max = dp[i];
                }
            }
        }

        /*foreach (var i in dp)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();*/

        max = -1;
        foreach (var i in dp)
        {
            if (max < i)
            {
                max = i;
            }
            
        }
        
        Console.WriteLine(max);        
    }
}