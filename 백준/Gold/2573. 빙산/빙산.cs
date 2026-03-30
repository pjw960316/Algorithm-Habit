using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 
 public class CSharpHabit
 {
     static void Main()
     {
         var line = Console.ReadLine().Split();
         int rMax = int.Parse(line[0]);
         int cMax = int.Parse(line[1]);
         
         var arr = new int[rMax + 2, cMax + 2];
         var nextArr = new int[rMax + 2, cMax + 2];
         
         var path = new (int, int)[4];
         path[0] = (-1, 0);
         path[1] = (1, 0);
         path[2] = (0, -1);
         path[3] = (0, 1);

         for (int r = 1; r <= rMax; r++)
         {
             line = Console.ReadLine().Split();
             for (int c = 1; c <= cMax; c++)
             {
                 arr[r, c] = int.Parse(line[c - 1]);
             }
         }

         int curYear = 0;
         while (true)
         {
             // todo : 다 안 녹을 수는 없지 않은가?
             if (SumIce() == 0)
             {
                 Console.Write(0);
                 return;
             }

             if (IsSeperated())
             {
                 Console.Write(curYear);
                 return;
             }

             GoYear();
             DeepCopy();
             curYear++;
         }

         void GoYear()
         {
             for (int r = 1; r <= rMax; r++)
             {
                 for (int c = 1; c <= cMax; c++)
                 {
                     int iceSum = 0;
                     for (int idx = 0; idx < 4; idx++)
                     {
                         var tmp = arr[r + path[idx].Item1, c + path[idx].Item2];
                         if (tmp == 0)
                         {
                             iceSum++;
                         }
                     }

                     nextArr[r, c] = Math.Max(0,arr[r, c] - iceSum);
                 }
             }
         }

         void DeepCopy()
         {
             for (int r = 1; r <= rMax; r++)
             {
                 for (int c = 1; c <= cMax; c++)
                 {
                     arr[r, c] = nextArr[r, c];
                 }
             }

             Array.Clear(nextArr);
         }

         bool IsSeperated()
         {
             var queue = new Queue<(int, int)>();
             var visit = new bool[rMax + 2, cMax + 2];
             
             int groupNum = 0;
             
             for (int r = 1; r <= rMax; r++)
             {
                 for (int c = 1; c <= cMax; c++)
                 {
                     if (arr[r, c] > 0 && visit[r,c] == false)
                     {
                         groupNum++;
                         BFS(r,c);
                     }
                 }
             }

             if (groupNum >= 2)
             {
                 return true;
             }
             else
             {
                 return false;                 
             }
             
             void BFS(int r, int c)
             {
                 queue.Enqueue((r, c));
                 visit[r, c] = true;
                 
                 while (true)
                 {
                     if (queue.Count == 0)
                     {
                         break;
                     }

                     var pair = queue.Dequeue();
                     
                     for (int idx = 0; idx < 4; idx++)
                     {
                         var newR = pair.Item1 + path[idx].Item1;
                         var newC = pair.Item2 + path[idx].Item2;

                         if (arr[newR, newC] > 0 && visit[newR,newC] == false)
                         {
                             queue.Enqueue((newR, newC));
                             visit[newR, newC] = true;
                         }
                     }
                 }
             }
         }

         int SumIce()
         {
             int ret = 0;
             for (int r = 1; r <= rMax; r++)
             {
                 for (int c = 1; c <= cMax; c++)
                 {
                     ret += arr[r, c];
                 }
             }

             return ret;
         }
     }
 }