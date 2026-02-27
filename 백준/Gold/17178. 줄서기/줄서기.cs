using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var list = new List<(char, int, string)>();
        var dict = new Dictionary<string, int>();
        var stack = new Stack<string>();
        var queue = new Queue<string>();
        
        for (int i = 0; i < n; i++)
        {
            var line = Console.ReadLine().Split();

            for (int j = 0; j < 5; j++)
            {
                var ticketStr = line[j];
                var ticketStrLen = ticketStr.Length;
                int numStr = int.Parse(ticketStr.Substring(2, ticketStrLen - 2));

                queue.Enqueue(ticketStr);
                list.Add((ticketStr[0], numStr, ticketStr));
                dict[ticketStr] = 0; //초기화
            }
        }

        list = list.OrderBy(pair => pair.Item1)
            .ThenBy(pair => pair.Item2)
            .ToList();

        var listLen = list.Count;
        for (int idx = 0; idx < listLen; idx++)
        {
            var order = idx + 1;
            var ticketFullStr = list[idx].Item3;
            
            dict[ticketFullStr] = order;
        }

        /*foreach (var kv in dict)
        {
            Console.WriteLine($"{kv.Key} , {kv.Value}");
        }*/
        
        int curOrder = 1;
        
        while (true)
        {
            if (queue.Count == 0)
            {
                if (stack.Count == 0)
                {
                    Console.Write("GOOD");
                    return;
                }
                
                if (curOrder != dict[stack.Peek()]) 
                {
                    Console.Write("BAD");
                    return;
                }
            }
            // 1. 일반 줄에 타겟 있으면
            if (0 < queue.Count && dict[queue.Peek()] == curOrder)
            {
                queue.Dequeue();
                curOrder++;
                
                continue;
            }
            
            // 2. 대기 줄에 타겟 있으면
            if (0 < stack.Count && dict[stack.Peek()] == curOrder)
            {
                stack.Pop();
                curOrder++;

                continue;
            }
            
            // 3. 둘다 없으면
            stack.Push(queue.Peek());
            queue.Dequeue();
        }
    }
}