using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()

        var inningCnt = int.Parse(Console.ReadLine());

        var inputArr = new int[10][];
        for (int i = 0; i < 9; i++)
        {
            inputArr[i + 1] = new int[51];
        }

        for (int i = 1; i<=inningCnt; i++)
        {
            var line = Console.ReadLine().Split();
            for (int j = 1; j <= 9; j++)
            {
                inputArr[j][i] = int.Parse(line[j-1]);
            }
        }

        var arr = new int[10][];
        arr[4] = inputArr[1];
        
        var visit = new bool[10];
        visit[1] = true; // 1번 input이 true라는 의미.

        int max = -1;
        DFS(1);

        Console.Write(max);
        
        return;
        
        // order가 n번 타자
        void DFS(int order)
        {
            if (order > 9)
            {
                max = Math.Max(max,PlayGame());
                /*Console.WriteLine("====================================");
                for (int i = 1; i <= 9; i++)
                {
                    for (int j = 1; j <= inningCnt; j++)
                    {
                        Console.Write($"{arr[i][j]} ");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("====================================");*/
                return;
            }

            if (order == 4)
            {
                DFS(order + 1);
            }
            
            else
            {
                for (int i = 1; i <= 9; i++) // input
                {
                    if (visit[i] == false)
                    {
                        arr[order] = inputArr[i];
                        visit[i] = true;

                        DFS(order + 1);
                        
                        visit[i] = false; 
                    }
                }
            }
        }

        int PlayGame()
        {
            int inning = 1;
            int order = 1;
            int outCnt = 0;
            int score = 0;
            var baseArr = new bool[4];
                
            while (true)
            {
                if (inning > inningCnt)
                {
                    return score;
                }

                // 점수 계산 시작
                var getBase = arr[order][inning];
                
                // 1. 주자
                for (int idx = 3; idx >= 1; idx--)
                {
                    if (baseArr[idx] == false)
                    {
                        continue;
                    }
                    
                    baseArr[idx] = false;
                    var newBaseIdx = idx + getBase;
                    if (newBaseIdx > 3)
                    {
                        score++;
                    }
                    else
                    {
                        baseArr[newBaseIdx] = true;
                    }
                }
                
                // 2. 타자
                if (getBase == 0)
                {
                    outCnt++;
                    
                    // 이닝 종료
                    if (outCnt == 3)
                    {
                        inning++;
                        outCnt = 0;

                        baseArr[1] = false;
                        baseArr[2] = false;
                        baseArr[3] = false;
                    }
                }
                else if (getBase == 4)
                {
                    score++;
                }
                else
                {
                    baseArr[getBase] = true;
                }

                // 타순
                order++;
                if (order == 10)
                {
                    order = 1;
                }
            }

            return -1;
        }
    }
}