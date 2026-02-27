using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()

        int inputNum = int.Parse(Console.ReadLine());

        for (int i = 1; i<=1000000; i++)
        {
            var num = i;
            string numStr = num.ToString();

            int sum = num;
            foreach (var word in numStr)
            {
                sum += word - '0';
            }

            if (sum == inputNum)
            {
                Console.Write(num);
                return;
            }
        }

        Console.Write(0);
        
        return;
    }
}