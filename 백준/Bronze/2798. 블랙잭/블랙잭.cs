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
        int n = int.Parse(line[0]);
        int m = int.Parse(line[1]);
        
        var arr = new int[n + 1];
        line = Console.ReadLine().Split();
        
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(line[i]);
        }

        int answer = 0;
        for (int i = 0; i < n-2; i++)
        {
            for (int j = i + 1; j < n-1; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    var sum = arr[i] + arr[j] + arr[k];
                    var newVal = m - sum;
                    
                    if (newVal < 0)
                    {
                        continue;
                    }
                    
                    if (newVal < m - answer)
                    {
                        answer = sum;
                    }
                }
            }
        }

        Console.Write(answer);
    }
}