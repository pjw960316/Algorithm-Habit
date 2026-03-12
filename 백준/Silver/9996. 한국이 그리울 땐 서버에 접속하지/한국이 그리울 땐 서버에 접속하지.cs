using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
public class CSharpHabit
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var str = Console.ReadLine();
        var len = str.Length;

        var frontSb = new StringBuilder();
        var backSb = new StringBuilder();

        for (int idx = 0; idx < len; idx++)
        {
            var word = str[idx];
            if (word != '*')
            {
                frontSb.Append(word);
            }
            else
            {
                break;
            }
        }

        for (int idx = len - 1; idx >= 0; idx--)
        {
            var word = str[idx];
            if (word != '*')
            {
                backSb.Append(word);
            }
            else
            {
                break;
            }
        }

        //Print();

        var frontLen = frontSb.Length;
        var backLen = backSb.Length;

        var sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            sb.AppendLine(Check());
        }

        Console.Write(sb);

        return;
        
        string Check()
        {
            var line = Console.ReadLine();
            var lineLen = line.Length;

            if (lineLen < frontLen + backLen)
            {
                return "NE";
            }
                
            for (int idx = 0; idx < frontLen; idx++)
            {
                if (line[idx] != frontSb[idx])
                {
                    return "NE";
                }
            }

            for (int idx = 0; idx < backLen; idx++)
            {
                if (line[lineLen -1 -idx] != backSb[idx])
                {
                    return "NE";
                }
            }

            return "DA";
        }

        void Print()
        {
            Console.WriteLine("===================");

            Console.Write(frontSb);
            Console.WriteLine();
            Console.Write(backSb);
            Console.WriteLine();
            
            Console.WriteLine("===================");
        }
    }
}