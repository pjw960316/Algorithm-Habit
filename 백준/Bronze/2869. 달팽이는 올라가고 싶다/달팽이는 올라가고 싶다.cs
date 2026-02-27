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
        int a = int.Parse(line[0]);
        int b= int.Parse(line[1]);
        int v = int.Parse(line[2]);

        if (a == v)
        {
            Console.Write(1);
            return;
        }
        
        double val = (double)(v - a) / (double)(a - b);
        var tmp = Math.Ceiling(val);

        Console.Write(tmp + 1);
    }
}