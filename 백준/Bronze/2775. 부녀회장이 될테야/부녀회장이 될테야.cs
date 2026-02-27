using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()
        var maxTc = int.Parse(Console.ReadLine());

        for (int tc = 0; tc < maxTc; tc++)
        {
            int inputFloor = int.Parse(Console.ReadLine());
            int inputHo = int.Parse(Console.ReadLine());
            
            var arr = new int[15, 15];
            for (int i = 0; i < 15; i++)
            {
                arr[0,i] = i;
            }

            for (int floor = 1; floor <= 14; floor++)
            {
                for (int ho = 1; ho <= 14; ho++)
                {
                    int sum = 0;
                    for (var downHo = 1; downHo <= ho; downHo++)
                    {
                        sum += arr[floor - 1, downHo];
                    }

                    arr[floor, ho] = sum;
                }
            }
            Console.WriteLine($"{arr[inputFloor, inputHo]}");
        }
    }
}