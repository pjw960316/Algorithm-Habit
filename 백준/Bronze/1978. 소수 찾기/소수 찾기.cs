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

        var hashSet = new HashSet<int>();
        hashSet.Add(1);
        
        for (int i = 2; i <= 1000; i++)
        {
            for (int j = 2; j <= 500; j++)
            {
                var val = i * j;
                if (1000 < val)
                {
                    break;
                }
                hashSet.Add(val);
            }
        }

        int answer = 0;
        var line = Console.ReadLine().Split();
        
        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(line[i]);
            if (!hashSet.Contains(num))
            {
                answer++;
            }
        }

        Console.Write(answer);
    }
}