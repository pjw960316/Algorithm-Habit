using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
public class CSharpHabit
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var pArr = new int[48];
        var sArr = new int[48];

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
        
        var arr = new int[48];
        for (int i = 0; i < n; i++)
        {
            arr[i] = i;
        }
        var originArr = arr.Clone() as int[];
        var targetArr = MakeTargetArr();
        
        int count = 0;
        while (true)
        {
            Print();
            
            if (Verify())
            {
                Console.Write(count);
                return;
            }
            arr = Mix();

            count++;
        }

        int[] MakeTargetArr()
        {
            var retArr = new int[48];
            
            for (int idx = 0; idx < n; idx++)
            {
                var targetIdx = pArr[idx] + Make(idx);
                retArr[targetIdx] = originArr[idx];
            }

            return retArr;
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
            for (int idx = 0; idx < n; idx++)
            {
                var cardNum = arr[idx];

                for (int jdx = 0; jdx < n; jdx++)
                {
                    if (targetArr[jdx] == cardNum)
                    {
                        if (idx % 3 != jdx % 3)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        void Print()
        {
            Console.Write($"target : ");
            for (int idx = 0; idx < n; idx++)
            {
                Console.Write($"{targetArr[idx]} ");
            }
            
            Console.Write($"  after : ");
            for (int idx = 0; idx < n; idx++)
            {
                Console.Write($"{arr[idx]} ");
            }

            Console.WriteLine();
        }

        int Measure(int n)
        {
            return 3 * (n / 3);
        }

        int Make(int n)
        {
            return 3 * n / 3;
        }
    }
}