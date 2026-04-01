using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
public class CSharpHabit
{
    static void Main()
    {
        var line = Console.ReadLine().Split();
        int n = int.Parse(line[0]);
        int endDepth = int.Parse(line[1]);

        var list = new List<int>();
        line = Console.ReadLine().Split();
        for (int i = 0; i < n; i++)
        {
            list.Add(int.Parse(line[i]));
        }

        list.Sort();
        var len = list.Count;
        
        var arr = new int[endDepth + 2];
        var sb = new StringBuilder();
        var visit = new bool[len + 2]; // list의 idx의 방문여부

        DFS(1);
        
        Console.Write(sb);
        
        void DFS(int depth)
        {
            if (depth == endDepth + 1)
            {
                UpdateStringBuilder();
                return;
            }
            
            int prevNum = -1;
            for (int idx = 0; idx < len; idx++)
            {
                var num = list[idx];
               
                if (prevNum != num && visit[idx] == false)
                {
                    prevNum = num;
                    visit[idx] = true;
                    
                    arr[depth] = num;
                    
                    DFS(depth + 1);

                    visit[idx] = false;
                }
            }
        }

        void UpdateStringBuilder()
        {
            for (int idx = 1; idx <= endDepth; idx++)
            {
                sb.Append(arr[idx]);
                sb.Append(' ');
            }

            sb.AppendLine();
        }
    }
}