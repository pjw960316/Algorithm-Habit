using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()

        var hashSet = new HashSet<string>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            hashSet.Add(Console.ReadLine());
        }

        var newHashSet = hashSet.OrderBy(str => str.Length)
            .ThenBy(str => str)
            .ToList();

        var sb = new StringBuilder();
        foreach (var str in newHashSet)
        {
            sb.AppendLine(str);
        }

        Console.Write(sb);
    }
}