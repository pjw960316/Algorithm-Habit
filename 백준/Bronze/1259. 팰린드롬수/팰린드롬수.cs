using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()
        var sb = new StringBuilder();
        
        while (true)
        {
            var str = Console.ReadLine();
            if (str == "0")
            {
                Console.Write(sb.ToString());
                return;
            }
            
            int startIdx = 0;
            int endIdx = str.Length-1;
            bool isPel = true;
            
            while (true)
            {
                if (startIdx == endIdx)
                {
                    break;
                }
                
                if (endIdx - startIdx == 1)
                {
                    if (str[startIdx] != str[endIdx])
                    {
                        isPel = false;
                    }
                    break;
                }

                if (str[startIdx] != str[endIdx])
                {
                    isPel = false;
                }

                startIdx++;
                endIdx--;
            }

            if (isPel)
            {
                sb.AppendLine("yes");
            }
            else
            {
                sb.AppendLine("no");
            }
        }
    }
}