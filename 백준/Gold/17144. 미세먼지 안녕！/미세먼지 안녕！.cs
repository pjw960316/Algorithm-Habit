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
        int time = int.Parse(line[2]);

        var arr = new int[maxRow + 2, maxCol + 2];
        var path = new (int, int)[4];
        path[0] = (-1, 0);
        path[1] = (1, 0);
        path[2] = (0, -1);
        path[3] = (0, 1);

        var upCleanerRow = 0;
        
        for (int r = 0; r <= maxRow + 1; r++)
        {
            for (int c = 0; c <= maxCol + 1; c++)
            {
                arr[r, c] = int.MinValue/2;
            }
        }
        for (int r = 1; r <= maxRow; r++)
        {
            line = Console.ReadLine().Split();
            for (int c = 1; c <= maxCol; c++)
            {
                arr[r, c] = int.Parse(line[c - 1]);

                if (arr[r, c] == -1 && upCleanerRow == 0)
                {
                    upCleanerRow = r;
                }
            }
        }

        for (int t = 1; t <= time; t++)
        {
            arr = GetMoveAfterArr();

            //Print();

            arr = GetAfterCleanArr();

            //Print();
        }

        Console.Write(GetAnswer());

        int[,] GetMoveAfterArr()
        {
            var retArr = arr.Clone() as int[,];
            
            // 2500
            for (int r = 0; r <= maxRow+1; r++)
            {
                for (int c = 0; c <= maxCol+1; c++)
                {
                    retArr[r, c] = arr[r, c];
                }
            }
            
            for (int r = 1; r <= maxRow; r++)
            {
                for (int c = 1; c <= maxCol; c++)
                {
                    int moveCount = 0;
                    
                    if (1 <= arr[r, c])
                    {
                        var addDirt = GetAddDirt(arr[r, c]);
                        
                        for (int idx = 0; idx < 4; idx++)
                        {
                            int newRow = r + path[idx].Item1;
                            int newCol = c + path[idx].Item2;

                            if (0 <= arr[newRow, newCol])
                            {
                                retArr[newRow, newCol] += addDirt;
                                moveCount++;
                            }
                        }

                        var removeDirt = addDirt * moveCount;
                        
                        retArr[r, c] -= removeDirt;
                        retArr[r, c] = Math.Max(retArr[r, c], 0);
                    }
                }
            }

            return retArr;
        }

        int[,] GetAfterCleanArr()
        {
            var retArr = arr.Clone() as int[,];
            
            // 2500
            for (int r = 0; r <= maxRow+1; r++)
            {
                for (int c = 0; c <= maxCol+1; c++)
                {
                    retArr[r, c] = arr[r, c];
                }
            }
            
            int up = upCleanerRow;
            int down = up + 1;
            int mr = maxRow;
            int mc = maxCol;

            CleanUp();
            CleanDown();
            
            return retArr;
            
            void CleanUp()
            {
                retArr[up, 2] = 0;
                for (int c = 3; c <= mc; c++)
                {
                    retArr[up, c] = arr[up, c - 1];
                }

                for (int r = 1; r <= up - 1; r++)
                {
                    retArr[r, mc] = arr[r + 1, mc];
                }
                
                for (int c = 1; c <= mc-1; c++)
                {
                    retArr[1, c] = arr[1, c + 1];
                }

                for (int r = 2; r <= up - 1; r++)
                {
                    retArr[r, 1] = arr[r - 1, 1];
                }
            }

            void CleanDown()
            {
                for (int c = 3; c <= mc; c++)
                {
                    retArr[down, c] = arr[down, c - 1];
                }

                retArr[down, 2] = 0;

                for (int r = down + 1; r <= mr; r++)
                {
                    retArr[r, mc] = arr[r - 1, mc];
                }

                for (int c = 1; c <= mc - 1; c++)
                {
                    retArr[mr, c] = arr[mr, c + 1];
                }

                for (int r = down + 1; r <= mr - 1; r++)
                {
                    retArr[r, 1] = arr[r + 1, 1];
                }
            }
        }

        

        int GetAnswer()
        {
            int answer = 0;

            for (int r = 1; r <= maxRow; r++)
            {
                for (int c = 1; c <= maxCol; c++)
                {
                    if (arr[r, c] != -1)
                    {
                        answer += arr[r, c];
                    }
                }
            }
            return answer;
        }

        int GetAddDirt(int dirt)
        {
            double val = (double)dirt / 5.0;

            return (int)val;
        }
        
        void Print()
        {
            Console.WriteLine($"===============================================");
            for (int r = 1; r <= maxRow; r++)
            {
                for (int c = 1; c <= maxCol; c++)
                {
                    Console.Write($"{arr[r, c]} ");
                }

                Console.WriteLine();
            }
            Console.WriteLine($"===============================================");
        }
    }
}