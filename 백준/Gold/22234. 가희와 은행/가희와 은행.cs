using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
public class CSharpHabit
{
    static void Main()
    {
        var queue = new Queue<(int, int, int)>(); // id, workTime , entryTime 
        var afterMemberList = new List<(int, int, int)>();
        var afterQueue = new Queue<(int, int, int)>();
        
        var line = Console.ReadLine().Split();

        var beforeMemberCnt = int.Parse(line[0]);
        var workMaxTime = int.Parse(line[1]);
        var endTime = int.Parse(line[2]);

        for (int i = 0; i < beforeMemberCnt; i++)
        {
            line = Console.ReadLine().Split();
            var id = int.Parse(line[0]);
            var workTime = int.Parse(line[1]);
            var entryTime = 0;
            
            queue.Enqueue((id, workTime,entryTime));
        }
        
        var afterMemberCnt = int.Parse(Console.ReadLine());
        for (int i = 0; i < afterMemberCnt; i++)
        {
            line = Console.ReadLine().Split();
            var id = int.Parse(line[0]);
            var workTime = int.Parse(line[1]);
            var entryTime = int.Parse(line[2]);
            
            afterMemberList.Add((id, workTime, entryTime));
        }

        var afterMembers = afterMemberList
            .OrderBy(tuple => tuple.Item3);

        foreach (var tuple in afterMembers)
        {
            afterQueue.Enqueue(tuple);
        }
        
        //Print();
        
        DoBankWork();

        return;
        
        void DoBankWork()
        {
            var sb = new StringBuilder();
            var curTime = 0;
            
            while(true)
            {
                if (endTime == curTime)
                {
                    Console.Write(sb);
                    return;
                }
                
                // todo : 값 복사 조심
                // todo : long 필요한 지 고민
                var member = queue.Peek();
                
                var id = member.Item1;
                var workTime = member.Item2;
                var entryTime = member.Item3;

                CheckAfterQueue(curTime);
                
                if (entryTime <= curTime)
                {
                    queue.Dequeue();

                    var realWorkTime = Math.Min(workTime, workMaxTime);
                    for (int i = 0; i < realWorkTime; i++)
                    {
                        curTime++;
                        
                        CheckAfterQueue(curTime);
                        
                        sb.Append(id);
                        sb.AppendLine();
                        
                        if (endTime == curTime)
                        {
                            Console.Write(sb);
                            return;
                        }
                    }
                    
                    if (workMaxTime < workTime)
                    {
                        queue.Enqueue((id, workTime - workMaxTime, entryTime));
                    }
                }
                else
                {
                    curTime++;
                    continue;
                }
            }
        }

        void Print()
        {
            foreach (var tuple in queue)
            {
                Console.WriteLine($"ID : {tuple.Item1} , 일처리 시간 : {tuple.Item2} , 입장 시간 : {tuple.Item3}");
            }
        }

        void CheckAfterQueue(int curTime)
        {
            if (afterQueue.Count == 0)
            {
                return;
            }
            
            var curAfterMember = afterQueue.Peek();
            var entryTime = curAfterMember.Item3;
            
            if (curTime == entryTime)
            {
                queue.Enqueue(afterQueue.Dequeue());
            }
        }
    }
}