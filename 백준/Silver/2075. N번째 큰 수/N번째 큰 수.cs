using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
public class CSharpHabit
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var pq = new PriorityQueue<int, int>();
        
        for (int r = 1; r <= n; r++)
        {
            var line = Console.ReadLine().Split();
            for (int c = 1; c <= n; c++)
            {
                int num = int.Parse(line[c - 1]);
                pq.Enqueue(num, num);

                if (pq.Count > n)
                {
                    pq.Dequeue();
                }
            }
        }

        Console.Write(pq.Dequeue());
        
        //Print();

        void Print()
        {
            while (true)
            {
                if (pq.Count == 0)
                {
                    return;
                }
                Console.Write($"{pq.Dequeue()} ");
            }
        }
    }
}