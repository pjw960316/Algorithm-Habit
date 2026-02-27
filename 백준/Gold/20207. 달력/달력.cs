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
        var list = new List<(int, int)>();
        
        for (int i = 0; i < n; i++)
        {
            var line = Console.ReadLine().Split();
            list.Add((int.Parse(line[0]), int.Parse(line[1])));
        }

        list = list.OrderBy(pair => pair.Item1)
            .ThenByDescending(pair => pair.Item2 - pair.Item1)
            .ToList();
        
        var arr = new bool[n+1, 367]; // 1-indexing & col이 날짜
        var len = list.Count;

        //1. 빨간색 그리기
        for (int i = 0; i < len; i++)
        {
            var startDay = list[i].Item1;
            var endDay = list[i].Item2;

            for (int row = 1; row <= n; row++)
            {
                if (arr[row, startDay] == false)
                {
                    for(int col = startDay; col<=endDay; col++)
                    {
                        arr[row, col] = true;
                    }
                    break;
                }
            }
        }
        
        //2. 영역 그리기
        int maxRow = int.MinValue;
        int state = 0; 
        int colLen = 0;
        int answer = 0;

        /*for (int row = 1; row <= n; row++)
        {
            Console.Write($"{arr[row, 2]}");
        }*/
        
        for (int col = 1; col <= 365; col++)
        {
            bool hasSchedule = false;
            for (int row = 1; row <= n; row++)
            {
                if (arr[row, col])
                {
                    hasSchedule = true;
                    break;
                }
            }
            
            if (hasSchedule)
            {
                state = 1;
                colLen++;
                int targetRow = 1;
                for (int row = 1; row <= n; row++)
                {
                    if (row == n)
                    {
                        targetRow = n;
                    }
                    if (arr[row, col] == false)
                    {
                        targetRow = row - 1;
                        break;
                    }
                }

                /*if (col == 2)
                {
                    Console.WriteLine($"target : {targetRow}");
                }*/
                //todo : check
                maxRow = Math.Max(maxRow, targetRow);
            }
            else
            {
                if (state == 1)
                {
                    answer += colLen * maxRow;

                    //Console.WriteLine($"{col} , {rowLen} , {maxRow}");
                    
                    state = 0;
                    colLen = 0;
                    maxRow = int.MinValue;
                }
            }

            if (col == 365)
            {
                //Console.WriteLine($"366 : {col} , {colLen} , {maxRow}");
                answer += colLen * maxRow;
            }
        }

        Console.Write(answer);
    }
}