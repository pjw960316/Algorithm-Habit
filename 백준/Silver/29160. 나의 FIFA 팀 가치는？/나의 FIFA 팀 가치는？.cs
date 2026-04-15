using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ComparePower : IComparer<int>
{
    public int Compare(int a, int b)
    {
        if (a < b)
        {
            return 1;
        }
        else if (a > b)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}
public class CSharpHabit
{
    static void Main()
    {
        var line = Console.ReadLine().Split();
        int n = int.Parse(line[0]);
        int k = int.Parse(line[1]);

        var pqArr = new PriorityQueue<int,int>[12];
        var comparePower = new ComparePower();
        
        for (int idx = 1; idx <= 11; idx++)
        {
            var pq = new PriorityQueue<int, int>(comparePower);
            pqArr[idx] = pq;
        }

        for (int i = 0; i < n; i++)
        {
            line = Console.ReadLine().Split();
            int posNum = int.Parse(line[0]);
            int power = int.Parse(line[1]);

            pqArr[posNum].Enqueue(power, power);
        }

        int answer = 0;
        
        for (int year = 1; year <= k; year++)
        {
            DoMarchToOctober();
            answer = DoNovember();
        }

        Console.Write(answer);
        return;
        
        //Print();

        void DoMarchToOctober()
        {
            for (int idx = 1; idx <= 11; idx++)
            {
                if (pqArr[idx].Count == 0)
                {
                    continue;
                }

                var power = pqArr[idx].Dequeue();
                if (power >= 1)
                {
                    power -= 1;
                }

                pqArr[idx].Enqueue(power, power);
            }
        }
        
        int DoNovember()
        {
            int ret = 0;
            
            for (int idx = 1; idx <= 11; idx++)
            {
                if (pqArr[idx].Count == 0)
                {
                    continue;
                }

                ret += pqArr[idx].Peek();
            }

            return ret;
        }
        
        // priorityQueue는 순회시에 원소가 변하므로 Print 조심
        void Print()
        {
            for (int idx = 1; idx <= 11; idx++)
            {
                Console.WriteLine();
                Console.WriteLine($"{idx}번 선수 Queue");

                while (true)
                {
                    if (pqArr[idx].Count == 0)
                    {
                        break;
                    }

                    Console.Write(pqArr[idx].Dequeue());
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}