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
        int b = int.Parse(line[1]);

        var aList = new List<int>();
        var bList = new List<int>();
        
        for (int i = 1; i <= a; i++)
        {
            if (a % i == 0)
            {
                aList.Add(i);
            }
        }
        
        for (int i = 1; i <= b; i++)
        {
            if (b % i == 0)
            {
                bList.Add(i);
            }
        }

        aList.Sort();
        bList.Sort();

        /*foreach (var i in aList)
        {
            Console.Write($"{i} ");
        }

        Console.WriteLine();
        foreach (var i in bList)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();*/
        
        var minAns = 1;
        foreach (var num in aList)
        {
            foreach (var num2 in bList)
            {
                if (num == num2)
                {
                    minAns = num;
                    break;
                }
            }
        }

        var maxAns = minAns * (a / minAns) * (b / minAns);
        
        Console.WriteLine(minAns);
        Console.WriteLine(maxAns);
    }
}