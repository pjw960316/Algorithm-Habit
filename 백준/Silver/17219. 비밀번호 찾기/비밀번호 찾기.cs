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

        var dict = new Dictionary<string, string>();
        for (int i = 0; i < n; i++)
        {
            line = Console.ReadLine().Split();
            dict[line[0]] = line[1];
        }

        var sb = new StringBuilder();
        for (int i = 0; i < m; i++)
        {
            var str = Console.ReadLine();
            sb.AppendLine(dict[str]);
        }

        Console.Write(sb);
    }
}