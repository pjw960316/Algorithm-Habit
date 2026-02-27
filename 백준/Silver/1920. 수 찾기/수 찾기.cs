using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    private static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()

        int n = int.Parse(Console.ReadLine());
        var hashSet = new HashSet<int>();
        var line = Console.ReadLine().Split();

        for (int i = 0; i < n; i++)
        {
            hashSet.Add(int.Parse(line[i]));
        }
        
        n = int.Parse(Console.ReadLine());
        line = Console.ReadLine().Split();
        var sb = new StringBuilder();
        
        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(line[i]);
            if (hashSet.Contains(num))
            {
                sb.AppendLine("1");
            }
            else
            {
                sb.AppendLine("0");
            }
        }

        Console.Write(sb);
    }
}