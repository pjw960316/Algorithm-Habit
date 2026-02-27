using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()
        int n = Int32.Parse(Console.ReadLine());
        var arr = new int[n+3,n+3];
        var pathArr = new char[10001];
                
        for(int i=0; i<=n+2; i++)
        {
            for(int j=0; j<=n+2; j++)
            {
                arr[i,j] = -1;
            }
        }
        
        for(int i=1; i<=n; i++)
        {
            for(int j=1; j<=n; j++)
            {
                arr[i,j] = 0;
            }
        }
        
        int appleCount = Int32.Parse(Console.ReadLine());;
        for(int i=0; i<appleCount; i++)
        {
            var line = Console.ReadLine().Split();
            
            // 사과 있음
            arr[Int32.Parse(line[0]) , Int32.Parse(line[1])] = 1; 
        }
        
        int pathCount = Int32.Parse(Console.ReadLine());
        for(int i=0; i<pathCount; i++)
        {
            var line = Console.ReadLine().Split();
            char word = line[1][0];
            pathArr[Int32.Parse(line[0])] = word;
        }
        
        var path = new (int,int)[4];
        path[0] = (0,1);
        path[1] = (1,0);
        path[2] = (0,-1);
        path[3] = (-1,0);
        
        var snakeQueue = new Queue<(int,int)>();
        snakeQueue.Enqueue((1,1));
        int time = 1;
        int curPathIdx = 0; // 동쪽
        
        while(0 < snakeQueue.Count)
        {
            var headPair = snakeQueue.LastOrDefault();
            var newRow = headPair.Item1 + path[curPathIdx].Item1;
            var newCol = headPair.Item2 + path[curPathIdx].Item2;

            // 자신과 만나는 지 검사
            foreach(var pair in snakeQueue)
            {
                if(pair.Item1 == newRow && pair.Item2 == newCol)
                {
                    Console.Write(time);
                    return;
                }
            }
                                   
            // 벽 박치기
            if(arr[newRow,newCol] == -1)
            {
                Console.Write(time);
                return;
            }
                
            snakeQueue.Enqueue((newRow,newCol));
            //사과 없음
            if(arr[newRow,newCol] == 0)
            {
                snakeQueue.Dequeue();
            }
            else
            {
                arr[newRow, newCol] = 0;
            }
            if(pathArr[time] == 'L')
            {
                if(curPathIdx == 0)
                {
                    curPathIdx = 3;
                }
                else
                {
                    curPathIdx -= 1;
                }               
            }
            
            // 다 움직이고 돌려
            if(pathArr[time] == 'D')
            {
                if(curPathIdx == 3)
                {
                    curPathIdx = 0;
                }
                else
                {
                    curPathIdx += 1;
                }
            }
            
            /*Console.Write($"{time}초 : ");
            foreach (var pair in snakeQueue)
            {
                Console.Write($"[{pair.Item1} , {pair.Item2}] ");
            }
            Console.WriteLine();*/
            time++;
        }
        
    }
}
