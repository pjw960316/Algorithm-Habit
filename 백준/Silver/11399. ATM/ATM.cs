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
        var list = new List<int>();

        for (int i = 0; i < n; i++)
        {
            list.Add(int.Parse(line[i]));
        }

        list.Sort();

        int answer = 0;
        int tmp = 0;
        foreach (var val in list)
        {
            tmp += val;
            answer += tmp;
        }

        Console.Write(answer);
    }
}