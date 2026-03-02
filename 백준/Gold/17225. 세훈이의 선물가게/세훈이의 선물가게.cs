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
        int bTime = int.Parse(line[0]);
        int rTime = int.Parse(line[1]);
        int m = int.Parse(line[2]);

        var bWorkDict = new Dictionary<int,int>();
        var rWorkDict = new Dictionary<int,int>();

        var bWorkList = new List<int>();
        var rWorkList = new List<int>();
        var bEndList = new List<int>();
        var rEndList = new List<int>();

        for (int i = 1; i <= 86401; i++)
        {
            bWorkDict[i] = 0;
            rWorkDict[i] = 0;
        }
        
        int giftNum = 1;
        for (int i = 0; i < m; i++)
        {
            line = Console.ReadLine().Split();
            var startTime = int.Parse(line[0]);
            var giftCount = int.Parse(line[2]);
            char giftTarget = line[1][0];

            if (giftTarget == 'B')
            {
                bWorkDict[startTime] = giftCount;
            }
            else
            {
                rWorkDict[startTime] = giftCount;
            }
        }

        for (int time = 1; time <= 86400; time++)
        {
            //1. 작업 추가
            AddWork(bWorkDict, bWorkList, time, bTime);
            AddWork(rWorkDict, rWorkList, time, rTime);
            
            //2. 작업 완료처리
            Work(rWorkList, rEndList);
            Work(bWorkList, bEndList);
        }
        
        var sb = new StringBuilder();
        
        Print(bEndList);
        sb.AppendLine();
        Print(rEndList);

        Console.Write(sb);
        return;

        void AddWork(Dictionary<int,int> workDict, List<int> workList, int time, int workTime)
        {
            var giftCount = workDict[time];
            if (giftCount != 0)
            {
                for (int i = 0; i < giftCount; i++)
                {
                    workList.Add(workTime);
                }
            }
        }

        void Work(List<int> workList, List<int> endList)
        {
            while (true)
            {
                if (workList.Count == 0)
                {
                    return;
                }
                
                if (workList[0] != 0)
                {
                    workList[0] -= 1;
                    return;
                }

                endList.Add(giftNum);
                giftNum++;
                workList.RemoveAt(0);
            }
        }

        void Print(List<int> endList)
        {
            var len = endList.Count;
            
            sb.Append(len);
            sb.AppendLine();

            for (int idx = 0; idx < len; idx++)
            {
                sb.Append(endList[idx]);
                sb.Append(' ');
            }
        }
    }
}