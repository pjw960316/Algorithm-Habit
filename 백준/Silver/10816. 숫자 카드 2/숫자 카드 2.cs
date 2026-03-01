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
        var line = Console.ReadLine().Split();
        var dict = new Dictionary<int, int>();
        
        for (int i = 0; i < n; i++)
        {
            var num = int.Parse(line[i]);
            if (dict.ContainsKey(num))
            {
                dict[num]++;
            }
            else
            {
                dict[num] = 1;
            }
        }
        
        n = int.Parse(Console.ReadLine());

        line = Console.ReadLine().Split();
        var sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            var num = int.Parse(line[i]);

            if (dict.ContainsKey(num) == false)
            {
                sb.Append(0);
            }
            else
            {
                sb.Append(dict[num]);
            }
            sb.Append(' ');
        }

        Console.Write(sb);
    }
}