using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
public class CSharpHabit
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var pArr = new int[48]; //카드 넘버 -> 위치
        var sArr = new int[48]; //위치 -> 카드 넘버

        var line = Console.ReadLine().Split();
        for (int idx = 0; idx < n; idx++)
        {
            pArr[idx] = int.Parse(line[idx]);
        }
        
        line = Console.ReadLine().Split();
        for (int idx = 0; idx < n; idx++)
        {
            sArr[idx] = int.Parse(line[idx]);
        }
        
        var arr = new int[48]; //위치 -> 카드 넘버
        for (int i = 0; i < n; i++)
        {
            arr[i] = i;
        }

        var hashSet = new HashSet<string>();
        
        int count = 0;
        while (true)
        {
            if (IsDuplicate())
            {
                Console.Write(-1);
                return;
            }
            
            if (Verify())
            {
                Console.Write(count);
                return;
            }
            
            arr = Mix();
            count++;
        }
        
        int[] Mix()
        {
            var retArr = new int[48];
            retArr = arr.Clone() as int[];

            for (int idx = 0; idx < n; idx++)
            {
                var targetIdx = sArr[idx];
                retArr[targetIdx] = arr[idx];
            }

            return retArr;
        }

        bool Verify()
        {
            for (int cardNum = 0; cardNum < n; cardNum++)
            {
                for (int idx = 0; idx < n; idx++)
                {
                    if (arr[idx] == cardNum)
                    {
                        if (idx % 3 != pArr[cardNum] % 3)
                        {
                            return false;
                        }

                        break;
                    }
                }
            }

            return true;
        }

        bool IsDuplicate()
        {
            var sb = new StringBuilder();
            for (int idx = 0; idx < n; idx++)
            {
                sb.Append(arr[idx]);
            }

            var str = sb.ToString();
            
            if (hashSet.Contains(str))
            {
                return true;
            }
            else
            {
                hashSet.Add(str);
                return false;
            }
        }
    }
}