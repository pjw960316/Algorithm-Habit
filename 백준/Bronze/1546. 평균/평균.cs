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
        double max = double.MinValue;
        
        var line = Console.ReadLine().Split();
        var arr = new double[1001];
        
        for (int i = 0; i < n; i++)
        {
            var num = double.Parse(line[i]);
            
            max = Math.Max(max,num);
            arr[i] = num;
        }


        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            arr[i] = arr[i] / max * 100;
            sum += arr[i];
        }

        Console.Write(sum / n);
    }
}