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
        int maxRow = int.Parse(line[0]);
        int maxCol = int.Parse(line[1]);

        var arr = new char[maxRow + 2, maxCol + 2];
        var newArr = new char[maxRow+1, maxCol+1];

        for (int row = 0; row < maxRow + 2; row++)
        {
            for (int col = 0; col < maxCol + 2; col++)
            {
                arr[row, col] = '.';
            }
        }

        for (int row = 1; row <= maxRow; row++)
        {
            string str = Console.ReadLine();
            for (int col = 1; col <= maxCol; col++)
            {
                arr[row, col] = str[col - 1];
            }
        }

        var path = new (int, int)[4];
        path[0] = (-1, 0);
        path[1] = (1, 0);
        path[2] = (0, -1);
        path[3] = (0, 1);

        int minRangeRow = 123123;
        int minRangeCol = 123123;
        int maxRangeRow = -1;
        int maxRangeCol = -1;
        
        for (int row = 1; row <= maxRow; row++)
        {
            for (int col = 1; col <= maxCol; col++)
            {
                int sum = 0;
                for (int i = 0; i < 4; i++)
                {
                    int newRow = row + path[i].Item1;
                    int newCol = col + path[i].Item2;

                    if (arr[newRow, newCol] == '.')
                    {
                        sum++;
                    }
                }

                if (arr[row, col] == 'X')
                {
                    if (sum >= 3)
                    {
                        newArr[row, col] = '.';
                    }
                    else
                    {
                        newArr[row, col] = 'X';
                    }
                }
                else
                {
                    newArr[row, col] = '.';
                }
            }
        }

        for (int row = 1; row <= maxRow; row++)
        {
            for (int col = 1; col <= maxCol; col++)
            {
                if (newArr[row, col] == 'X')
                {
                    if (maxRangeRow < row)
                    {
                        maxRangeRow = row;
                    }

                    if (maxRangeCol < col)
                    {
                        maxRangeCol = col;
                    }

                    if (row < minRangeRow)
                    {
                        minRangeRow = row;
                    }

                    if (col < minRangeCol)
                    {
                        minRangeCol = col;
                    }
                }
            }
        }

        for (int r = minRangeRow; r <= maxRangeRow; r++)
        {
            for (int c = minRangeCol; c <= maxRangeCol; c++)
            {
                Console.Write(newArr[r, c]);
            }

            Console.WriteLine();
        }
    }
}