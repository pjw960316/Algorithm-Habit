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
        var maxFor = n * n;
        
        var dict = new Dictionary<int, HashSet<int>>();
        var orderArr = new int[maxFor + 1];
        
        var path = new (int, int)[4];
        path[0] = (-1, 0);
        path[1] = (1, 0);
        path[2] = (0, -1);
        path[3] = (0, 1);

        
        for (int i = 1; i <= maxFor; i++)
        {
            dict[i] = new HashSet<int>();
        }
        
        for (int i = 1; i <= maxFor; i++)
        {
            var line = Console.ReadLine().Split();
            var key = int.Parse(line[0]);
            var hashSet = dict[key];
            
            orderArr[i] = key;
            
            for (int j = 1; j <= 4; j++)
            {
                hashSet.Add(int.Parse(line[j]));
            }
        }

        var arr = new int[n + 2, n + 2];
        for (int r = 0; r <= n + 1; r++)
        {
            for (int c = 0; c <= n + 1; c++)
            {
                arr[r, c] = -1;
            }
        }

        for (int r = 1; r <= n; r++)
        {
            for (int c = 1; c <= n; c++)
            {
                arr[r, c] = 0;
            }
        }

        for (int idx = 1; idx <= maxFor; idx++)
        {
            int targetStudentNum = orderArr[idx];
            var placePair = GetBestPlace(targetStudentNum);
            
            arr[placePair.Item1, placePair.Item2] = targetStudentNum;
        }

        Console.Write(GetAnswer());

        return;

        (int,int) GetBestPlace(int targetStudentNum)
        {
            int maxFriendCount = int.MinValue;
            int maxSpaceCount = int.MinValue;
            var rcPair = (-1, -1);
            
            for (int r = 1; r <= n; r++)
            {
                for (int c = 1; c <= n; c++)
                {
                    if (arr[r, c] == 0)
                    {
                        var pair = CountFriends(r, c, targetStudentNum);
                        var friendCount = pair.Item1;
                        var spaceCount = pair.Item2;

                        if (maxFriendCount < friendCount)
                        {
                            maxFriendCount = friendCount;
                            maxSpaceCount = spaceCount;
                            
                            rcPair.Item1 = r;
                            rcPair.Item2 = c;
                        }
                        
                        if (maxFriendCount == friendCount && maxSpaceCount < spaceCount)
                        {
                            maxSpaceCount = spaceCount;
                            
                            rcPair.Item1 = r;
                            rcPair.Item2 = c;
                            
                            continue;
                        }
                    }
                }
            }

            return rcPair;
        }

        (int,int) CountFriends(int row, int col, int targetStudentNum)
        {
            int friendCount = 0;
            int spaceCount = 0;
            
            for (int idx = 0; idx < 4; idx++)
            {
                var newRow = row + path[idx].Item1;
                var newCol = col + path[idx].Item2;
                var neighborStudentNum = arr[newRow, newCol];

                if (neighborStudentNum == -1)
                {
                    continue;
                }
                if (neighborStudentNum == 0)
                {
                    spaceCount++;
                    continue;
                }

                if (neighborStudentNum >= 1 && dict[targetStudentNum].Contains(neighborStudentNum))
                {
                    friendCount++;
                }
            }

            return (friendCount, spaceCount);
        }

        int GetAnswer()
        {
            int answer = 0;
            
            for (int r = 1; r <= n; r++)
            {
                for (int c = 1; c <= n; c++)
                {
                    var target = arr[r, c];
                    int friendCount = 0;
                    
                    for (int idx = 0; idx < 4; idx++)
                    {
                        int newRow = r + path[idx].Item1;
                        int newCol = c + path[idx].Item2;

                        var neightbor = arr[newRow, newCol];
                        if (dict[target].Contains(neightbor))
                        {
                            friendCount++;
                        }
                    }

                    answer += GetScore(friendCount);
                }
            }

            return answer;
        }

        int GetScore(int friendCount)
        {
            if (friendCount == 0)
            {
                return 0;
            }
            
            var score = 1;
            for (int i = 1; i < friendCount; i++)
            {
                score *= 10;
            }

            return score;
        }
    }
}