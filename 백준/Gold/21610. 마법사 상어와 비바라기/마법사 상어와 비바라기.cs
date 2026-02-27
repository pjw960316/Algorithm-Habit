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
        int m = int.Parse(line[1]);
        
        var pathDict = new Dictionary<int, (int, int)>();
        pathDict[1] = (0,-1);
        pathDict[2] = (-1,-1);
        pathDict[3] = (-1,0);
        pathDict[4] = (-1,1);
        pathDict[5] = (0,1);
        pathDict[6] = (1,1);
        pathDict[7] = (1,0);
        pathDict[8] = (1,-1);

        var waterArr = new int[n + 2, n + 2];
        for (int r = 1; r <= n; r++)
        {
            line = Console.ReadLine().Split();
            for (int c = 1; c <= n; c++)
            {
                string str = line[c - 1];
                waterArr[r, c] = int.Parse(str);
            }
        }

        var cloudArr = new bool[n + 2, n + 2];
        cloudArr[n, 1] = true;
        cloudArr[n, 2] = true;
        cloudArr[n-1, 1] = true;
        cloudArr[n-1, 2] = true;

        var hashSet= new HashSet<(int, int)>(); 
        for (int i = 0; i < m; i++)
        {
            line = Console.ReadLine().Split();
            int dKey = int.Parse(line[0]);
            int distance = int.Parse(line[1]);

            //1. 구름 이동
            cloudArr = MoveCloud(pathDict[dKey], distance % n, cloudArr , n);
            
            //2. 물 채우기 & 구름 사라지기
            hashSet.Clear();
            for (int r = 1; r <= n; r++)
            {
                for (int c = 1; c <= n; c++)
                {
                    if (cloudArr[r, c])
                    {
                        //Console.WriteLine($"cloud{r} , {c}");
                        waterArr[r, c] += 1;
                        hashSet.Add((r, c));
                    }
                    cloudArr[r, c] = false;
                }
            }
            
            //3. 물 복사
            CopyWater(pathDict, hashSet, waterArr, n);
            
            //4. 구름 생성
            for (int r = 1; r <= n; r++)
            {
                for (int c = 1; c <= n; c++)
                {
                    if (waterArr[r, c] >= 2 && hashSet.Contains((r,c)) == false)
                    {
                        cloudArr[r, c] = true;
                        waterArr[r, c] -= 2;
                    }
                }
            }
            //Print(waterArr,cloudArr,n);
        }
        int answer = 0;
        for (int r = 1; r <= n; r++)
        {
            for (int c = 1; c <= n; c++)
            {
                answer += waterArr[r, c];
            }
        }
        Console.Write(answer);
        return;
    }

    static bool[,] MoveCloud((int,int) pathPair, int distance, bool[,] cloudArr, int n)
    {
        var newCloudArr = new bool[n + 2, n + 2];
        for (int r = 1; r <= n; r++)
        {
            for (int c = 1; c <= n; c++)
            {
                if (cloudArr[r, c])
                {
                    int newRow = r + pathPair.Item1 * distance;
                    int newCol = c + pathPair.Item2 * distance;

                    while (newRow <= 0)
                    {
                        newRow += n;
                    }
                    while (newRow > n)
                    {
                        newRow -= n;
                    }

                    while (newCol <= 0)
                    {
                        newCol += n;
                    }
                    while (newCol > n)
                    {
                        newCol -= n;
                    }

                    newCloudArr[newRow, newCol] = true;
                }
            }
        }

        return newCloudArr;
    }

    static void CopyWater(Dictionary<int, (int, int)> pathDict, HashSet<(int, int)> hashSet, int[,]waterArr, int n)
    {
        foreach (var pair in hashSet)
        {
            var r = pair.Item1;
            var c = pair.Item2;

            int count = 0;
            for (int i = 2; i <= 8; i += 2)
            {
                var newRow = r + pathDict[i].Item1;
                var newCol = c + pathDict[i].Item2;

                if (1 <= newRow && newRow <= n && 
                    1 <= newCol && newCol <= n &&
                    waterArr[newRow,newCol] > 0)
                {
                    count++;
                }
            }
            waterArr[r, c] += count;
            //Console.WriteLine($"{r} {c} {count}");
        }
    }

    public static void Print(int[,] arr, bool[,] arr2, int n)
    {
        Console.WriteLine("==========================================");
        for (int r = 1; r <= n; r++)
        {
            for (int c = 1; c <= n; c++)
            {
                Console.Write($"{arr[r, c]} ");
            }

            Console.WriteLine();
        }
        
        Console.WriteLine();
        for (int r = 1; r <= n; r++)
        {
            for (int c = 1; c <= n; c++)
            {
                Console.Write($"{arr2[r, c]} ");
            }

            Console.WriteLine();
        }
        Console.WriteLine("==========================================");
    }
}