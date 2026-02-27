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
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);

            if (a % 10 == 0)
            {
                sb.Append(10);
                sb.AppendLine();
                
                continue;
            }
            else
            {
                a = a % 10;
            }
            
            var arr = new int[11];
            arr[1] = a;
            
            int tmp = a;
            int idx = 2;
            int cnt = 1;
            while (true)
            {
                tmp *= a;
                tmp = tmp % 10;
                if (tmp != a)
                {
                    arr[idx] = tmp;
                    cnt = idx;
                }
                else
                {
                    break;
                }
                idx++;
            }

            var targetIdx = b % cnt;
            if (targetIdx == 0)
            {
                targetIdx = cnt;
            }

            sb.Append(arr[targetIdx]);
            sb.AppendLine();
        }

        Console.Write(sb);
    }
}