using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()

        double n = int.Parse(Console.ReadLine());

        if (n == 0)
        {
            Console.Write(0);
            return;
        }
        
        var list = new List<double>();
        for (var i = 0; i < n; i++)
        {
            var score = double.Parse(Console.ReadLine());
            list.Add(score);
        }
        
        var fifteen = n * (double)15 / (double)100;
        var newFifteen = Math.Round(fifteen,MidpointRounding.AwayFromZero);

        list.Sort();
        int len = list.Count;

        double sum = 0;
        for (int idx = (int)newFifteen; idx < len - (int)newFifteen; idx++)
        {
            sum += list[idx];
        }

        double answer = sum / (double)(n - newFifteen * 2);

        Console.Write(Math.Round(answer,MidpointRounding.AwayFromZero));
    }
}