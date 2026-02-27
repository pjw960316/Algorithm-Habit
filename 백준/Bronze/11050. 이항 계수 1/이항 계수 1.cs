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
        
        int n = int.Parse(line[0]);
        int k = int.Parse(line[1]);

        int answer = Factorial(n) / (Factorial(n - k) * Factorial(k));
        
        Console.Write(answer);
    }

    static int Factorial(int num)
    {
        int answer = 1;
        while (num >= 2)
        {
            answer *= num;
            num--;
        }

        return answer;
    }
}