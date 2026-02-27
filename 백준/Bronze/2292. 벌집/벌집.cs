using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()
        // 1 7 19 37 61
        // 6*0 + 1, 6*+1 + 1, 6*3 + 1, 6*6 + 1, 6*10 + 1

        var inputNum = double.Parse(Console.ReadLine());
        
        var list = new List<double>();
        list.Add(0);
        
        int idx = 1;
        int sum = 0;
        while (true)
        {
            list.Add(6 * sum + 1);

            if (list[idx - 1] < inputNum && inputNum <= list[idx])
            {
                Console.Write(idx);
                return;
            }
            
            sum += idx;
            idx++;
        }
    }
}