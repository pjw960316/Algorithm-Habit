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
        int n = int.Parse(line[0]);
        int left = int.Parse(line[1]);
        int right = int.Parse(line[2]);

        var arr = new int[n + 2, n + 2];
        var visit = new bool[n + 2, n + 2];
        var hashSet = new HashSet<(int, int)>();
        var path = new (int, int)[4];
        path[0] = (-1, 0);
        path[1] = (1, 0);
        path[2] = (0, -1);
        path[3] = (0, 1);

        for (int i = 0; i <= n + 1; i++)
        {
            for (int j = 0; j <= n + 1; j++)
            {
                arr[i, j] = 10000;
            }
        }
        
        for (int row = 1; row<=n; row++)
        {
            line = Console.ReadLine().Split();
            for (int col = 1; col <= n; col++)
            {
                arr[row, col] = int.Parse(line[col - 1]);
            }
        }

        int answer = 0;
        while (true)
        {
            bool isMove = false;
            // 방문 초기화
            for (int r = 1; r <= n; r++)
            {
                for (int c = 1; c <= n; c++)
                {
                    visit[r, c] = false;
                }
            }
            
            for (int r = 1; r <= n; r++)
            {
                for (int c = 1; c <= n; c++)
                {
                    int countrySum = 0;
                    int countryPersonSum = 0;

                    hashSet.Clear();
                    
                    if (visit[r, c] == false)
                    {
                        DFS(r, c, ref isMove, ref countrySum, ref countryPersonSum);
                        var value = countryPersonSum / countrySum;
                        
                        foreach (var pair in hashSet)
                        {
                            int targetRow = pair.Item1;
                            int targetCol = pair.Item2;
                            
                            arr[targetRow, targetCol] = value;
                        }
                    }
                }
            }
            
            if (isMove == false)
            {
                Console.Write(answer);
                return;
            }
            
            answer++;
        }
        void DFS(int r, int c, ref bool isMove, ref int countrySum, ref int countryPersonSum)
        {
            var myPerson = arr[r, c];
        
            visit[r, c] = true;
            hashSet.Add((r, c));
            countrySum++;
            countryPersonSum += myPerson;

            for (int idx = 0; idx < 4; idx++)
            {
                var newRow = r + path[idx].Item1;
                var newCol = c + path[idx].Item2;

                if (visit[newRow, newCol])
                {
                    continue;
                }

                if (newRow < 1 || n < newRow || newCol < 1 || n < newCol)
                {
                    continue;
                }
            
                var otherPerson = arr[newRow, newCol];
                var diff = Math.Abs(myPerson - otherPerson);

                if (left <= diff && diff <= right)
                {
                    isMove = true;
                    DFS(newRow, newCol, ref isMove, ref countrySum, ref countryPersonSum);
                }
            }
        }
    }
}