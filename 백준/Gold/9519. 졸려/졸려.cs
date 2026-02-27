using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()

        int n = int.Parse(Console.ReadLine());

        string str = Console.ReadLine();
        string originStr = str;

        var len = str.Length;
        var arr = new string[6 * len];

        arr[0] = str;
        int dupTime = 0;
        
        for (int idx = 1; idx < 3 * len; idx++)
        {
            str = MoveEye(str);
            arr[idx] = str;

            //Console.Write($"{arr[idx]}  ");
        }
        
        for (int idx = 1; idx < 3 * len; idx++)
        {
            if (arr[0] == arr[idx])
            {
                dupTime = idx;
                break;
            }
        }

        //Console.WriteLine(dupTime);
        
        for (int idx = len; idx < 2 * len; idx++)
        {
            if (arr[idx] == originStr)
            {
                //Console.WriteLine($"{idx} {n} {dupTime}");
                Console.Write(arr[idx - (n%dupTime)]);
                return;
            }
        }
    }

    static string MoveEye(string str)
    {
        var sb = new StringBuilder();
        
        int len = str.Length;
        int frontIdx = 0;
        int backIdx = len - 1;
        int half = len / 2;
        
        for (int i = 0; i < half; i++)
        {
            sb.Append(str[frontIdx]);
            sb.Append(str[backIdx]);
            
            frontIdx++;
            backIdx--;
        }

        if (len % 2 == 1)
        {
            sb.Append(str[half]);
        }

        return sb.ToString();
    }
}