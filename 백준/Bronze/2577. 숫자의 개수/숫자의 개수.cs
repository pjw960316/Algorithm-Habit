using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()

        int val = 1;
        var line = Console.ReadLine();
        val *= int.Parse(line);

        line = Console.ReadLine();
        val *= int.Parse(line);
        
        line = Console.ReadLine();
        val *= int.Parse(line);

        var str = val.ToString();
        var dict = new Dictionary<char, int>();
        for (char word = '0'; word <= '9'; word++)
        {
            dict[word] = 0;
        }

        foreach (var word in str)
        {
            dict[word]++;
        }
        
        for (char word = '0'; word <= '9'; word++)
        {
            Console.WriteLine(dict[word]);
        }
    }
}