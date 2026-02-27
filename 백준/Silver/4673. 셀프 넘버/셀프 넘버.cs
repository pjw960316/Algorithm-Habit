using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()

        var mySet = new HashSet<int>();
        
        for (int num = 1; num <= 10000; num++)
        {
            int tmp = num;
            var strNum = num.ToString();
            var len = strNum.Length;

            for (int idx = 0; idx < len; idx++)
            {
                tmp += strNum[idx] - '0';
            }

            mySet.Add(tmp);
        }

        var sb = new StringBuilder();
        for (int num = 1; num <= 10000; num++)
        {
            if (!mySet.Contains(num))
            {
                sb.Append(num).Append('\n');
            }
        }

        Console.Write(sb.ToString());
    }
}