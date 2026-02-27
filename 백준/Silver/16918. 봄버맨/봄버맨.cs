using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()

        var lineArr = Console.ReadLine().Split();
        
        int maxRow = int.Parse(lineArr[0]);
        int maxCol = int.Parse(lineArr[1]);
        int gameTime = int.Parse(lineArr[2]);
        
        var arr = new int[maxRow + 2, maxCol + 2];
        
        for (int row = 1; row <= maxRow; row++)
        {
            var line = Console.ReadLine();
            for (int col = 1; col <= maxCol; col++)
            {
                //폭탄
                if (line[col - 1] == 'O')
                {
                    arr[row, col] = 3;
                }
                else
                {
                    arr[row, col] = 0;
                }
            }
        }

        for (int time = 1; time <= gameTime; time++)
        {
            if (time == 1)
            {
                FlowBombTime(maxRow, maxCol, arr);
            }
            else
            {
                // 다 꽉찰 때
                if (time % 2 == 0)
                {
                    FlowBombTime(maxRow, maxCol, arr);
                    FillBomb(maxRow, maxCol, arr);
                }
                
                // 폭탄 터질 때
                else
                {
                    ExplodeBomb(maxRow, maxCol, arr);
                    FlowBombTime(maxRow, maxCol, arr);
                }
            }
        }
        for (int row = 1; row <= maxRow; row++)
        {
            for (int col = 1; col <= maxCol; col++)
            {
                if (arr[row, col] > 0)
                {
                    Console.Write('O');
                }
                else
                {
                    Console.Write('.');
                }
            }
        
            Console.WriteLine();
        }
    }

    static void FlowBombTime(int maxRow, int maxCol, int[,] arr)
    {
        for (int row = 1; row <= maxRow; row++)
        {
            for (int col = 1; col <= maxCol; col++)
            {
                if (arr[row, col] > 0)
                {
                    arr[row, col]--;
                }
            }
        }
    }
    
    static void FillBomb(int maxRow, int maxCol, int[,] arr)
    {
        for (int row = 1; row <= maxRow; row++)
        {
            for (int col = 1; col <= maxCol; col++)
            {
                if (arr[row, col] == 0)
                {
                    arr[row, col] = 3;
                }
            }
        }
    }

    static void ExplodeBomb(int maxRow, int maxCol, int[,] arr)
    {
        var path = new (int, int)[4];
        path[0] = (-1, 0);
        path[1] = (1, 0);
        path[2] = (0, 1);
        path[3] = (0, -1);
        
        for (int row = 1; row <= maxRow; row++)
        {
            for (int col = 1; col <= maxCol; col++)
            {
                if (arr[row, col] == 1)
                {
                    arr[row, col] = 0;
                    for (int idx = 0; idx < 4; idx++)
                    {
                        var newRow = row + path[idx].Item1;
                        var newCol = col + path[idx].Item2;
                    
                        if (arr[newRow, newCol] != 1)
                        {
                            arr[newRow, newCol] = 0;
                        }
                    }
                }
            }
        }
    }
}