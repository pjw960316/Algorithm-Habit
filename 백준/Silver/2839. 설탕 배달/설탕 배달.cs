using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        var input = Console.ReadLine();             
        int n = Int32.Parse(input);
        
        int minBags = int.MaxValue;

        for (int i = 0; i <= n / 5; i++)
        {
            for (int j = 0; j <= n / 3; j++)
            {
                if (5 * i + 3 * j == n)
                {
                    minBags = Math.Min(minBags, i + j);
                }
            }
        }

        Console.WriteLine(minBags == int.MaxValue ? -1 : minBags);

        
        
        
	    // TODO : Console.WriteLine()은 StringBuilder랑 조합해서 출력합니다.

    }
}
