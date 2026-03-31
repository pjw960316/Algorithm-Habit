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
        int endDepth = int.Parse(line[1]) + 1;

        var visit = new bool[10]; // 숫자
        var arr = new int[10];
        var sb = new StringBuilder();

        DFS(1);

        Console.Write(sb);
        
        void DFS(int depth)
        {
            if (depth == endDepth)
            {
                UpdateStringBuilder();
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (visit[i] == false && arr[depth-1] < i)
                {
                    arr[depth] = i;
                    visit[i] = true;

                    DFS(depth + 1);

                    visit[i] = false;
                }
            }
        }

        void UpdateStringBuilder()
        {
            for (int depth = 1; depth < endDepth; depth++)
            {
                sb.Append(arr[depth]);
                sb.Append(' ');
            }

            sb.AppendLine();
        }
    }
}