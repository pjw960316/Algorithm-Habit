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
        var list = new List<int>();
        
        for (int i = 0; i < n; i++)
        {
            list.Add(int.Parse(Console.ReadLine()));
        }
        list.Sort();
        
        var sb = new StringBuilder();
        foreach (var num in list)
        {
            sb.Append(num);
            sb.Append('\n');
        }

        Console.Write(sb);
    }
}