using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()

        var tcMax = int.Parse(Console.ReadLine());
        var sb = new StringBuilder();
        
        for (int tc = 0; tc < tcMax; tc++)
        {
            var line = Console.ReadLine().Split();
            
            int n = int.Parse(line[0]);
            string str = line[1];
            int len = str.Length;
            
            
            for (int idx = 0; idx < len; idx++)
            {
                var word = str[idx];
                for (int i = 0; i < n; i++)
                {
                    sb.Append(word);
                }
            }
            sb.AppendLine();
        }

        Console.Write(sb);

    }
}