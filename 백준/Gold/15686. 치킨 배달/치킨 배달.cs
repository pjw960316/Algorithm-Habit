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
        int maxChickenCount = int.Parse(line[1]);

        var arr = new int[n + 2, n + 2];

        for (int r = 1; r <= n; r++)
        {
            line = Console.ReadLine().Split();
            for (int c = 1; c <= n; c++)
            {
                arr[r, c] = int.Parse(line[c - 1]);
            }
        }

        var homePairList = new List<(int, int)>();
        var chickenPairList = new List<(int, int)>();
        
        for (int r = 1; r <= n; r++)
        {
            for (int c = 1; c <= n; c++)
            {
                var target = arr[r, c];
                
                if (target == 1)
                {
                    homePairList.Add((r, c));
                    continue;
                }
                if (target == 2)
                {
                    chickenPairList.Add((r, c));
                    continue;
                }
            }
        }
        var homeCnt = homePairList.Count;
        var chickenLen = chickenPairList.Count;
        
        var visitChickenArr = new bool[14]; 
        var chickenHouseArr = new (int,int)[14]; // index 1부터
        
        int answer = Int32.MaxValue;
        
        MakeChickenDFS(1, 0);

        Console.Write(answer);
        return;
        
        void MakeChickenDFS(int chickenHouseNum, int startIdx)
        {
            if (chickenHouseNum > maxChickenCount)
            {
                answer = Math.Min(answer,MeasureChickenDistance());
                
                return;
            }
            
            for (int idx = startIdx; idx < chickenLen; idx++)
            {
                if (visitChickenArr[idx] == false)
                {
                    chickenHouseArr[chickenHouseNum] = chickenPairList[idx];
                    visitChickenArr[idx] = true;
                    
                    // 조합이니까.
                    MakeChickenDFS(chickenHouseNum + 1, idx + 1);
                    
                    visitChickenArr[idx] = false;
                }
            }
        }

        int MeasureChickenDistance()
        {
            var retSumVal = 0;
            
            for (int idx = 0; idx < homeCnt; idx++) // 100
            {
                var homePair = homePairList[idx];
                var dis = Int32.MaxValue;
                
                for (int j = 1; j <= maxChickenCount; j++) // 14
                {
                    var chickenPair = chickenHouseArr[j];
                    var tmp = Math.Abs(homePair.Item1 - chickenPair.Item1) +
                              Math.Abs(homePair.Item2 - chickenPair.Item2);

                    dis = Math.Min(dis, tmp);
                }

                retSumVal += dis;
            }

            return retSumVal;
        }
    }
}