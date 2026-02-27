using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()

        var line = Console.ReadLine().Split();
        var maxRow = int.Parse(line[0]);
        var maxCol = int.Parse(line[1]);
        var arr = new char[maxRow, maxCol];
        
        line = Console.ReadLine().Split();
        var startRow = int.Parse(line[0]);
        var startCol = int.Parse(line[1]);
        var pathIdx = int.Parse(line[2]);

        for (int r = 0; r < maxRow; r++)
        {
            line = Console.ReadLine().Split();
            for (int c = 0; c < maxCol; c++)
            {
                arr[r, c] = line[c][0];
            }
        }

        var path = new (int, int)[4];
        path[0] = (-1, 0);
        path[1] = (0, 1);
        path[2] = (1, 0);
        path[3] = (0,-1);

        // 탐색 시작
        int answer = 0;
        int row = startRow;
        int col = startCol;
        while (true)
        {
            // 1. 현재 칸 청소
            if (arr[row, col] == '0')
            {
                arr[row, col] = '2';
                answer++;
            }
            bool canCleanUp = false;
            
            for (int i = 0; i < 4; i++)
            {
                var newRow = row + path[i].Item1;
                var newCol = col + path[i].Item2;

                if (arr[newRow, newCol] == '0')
                {
                    canCleanUp = true;
                    break;
                }
            }
            
            //2. 청소 불가
            if (canCleanUp == false)
            {
                var backPathIdx = 0;
                if (pathIdx == 0)
                {
                    backPathIdx = 2;
                }
                else if (pathIdx == 1)
                {
                    backPathIdx = 3;
                }
                else if (pathIdx == 2)
                {
                    backPathIdx = 0;
                }
                else if (pathIdx == 3)
                {
                    backPathIdx = 1;
                }
                var newRow = row + path[backPathIdx].Item1;
                var newCol = col + path[backPathIdx].Item2;

                if (arr[newRow, newCol] == '1')
                {
                    /*Console.WriteLine($"최종 타겟 : {row} , {col}");
                    for (int ii = 0; ii < maxRow; ii++)
                    {
                        for (int jj = 0; jj < maxCol; jj++)
                        {
                            Console.Write($"{arr[ii, jj]} ");
                        }
                        Console.WriteLine();
                    }*/
                    Console.Write(answer);
                    return;
                }
                else
                {
                    row = newRow;
                    col = newCol;
                }
            }
            //3. 청소 가능
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (pathIdx == 0)
                    {
                        pathIdx = 3;
                    }
                    else
                    {
                        pathIdx--;
                    }
                    
                    var newRow = row + path[pathIdx].Item1;
                    var newCol = col + path[pathIdx].Item2;

                    if (arr[newRow, newCol] == '0')
                    {
                        row = newRow;
                        col = newCol;
                        
                        break;
                    }
                }
            }
        }
    }
}