using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()
        // TODO : Parse input
        
        var line = Console.ReadLine().Split();
        
        int truck = Int32.Parse(line[0]);
        int bridgeLen = Int32.Parse(line[1]);
        int maxWeight = Int32.Parse(line[2]);

        var list = new List<(int, int)>();
        
        line = Console.ReadLine().Split();
        for(int i=0; i<truck; i++)
        {
            int truckWeight = Int32.Parse(line[i]);
            list.Add((bridgeLen+1+i , truckWeight));
        }
        
        int entryIdx = bridgeLen + 1;
        int answer = 0;
        
        while(list.Count > 0)
        {
            answer++;
            bool isStop = true;
            int prevTruckIdx = -1;

            for (int idx = 0; idx < list.Count; idx++)
            {
                if (list[idx].Item1 < entryIdx)
                {
                    list[idx] = (list[idx].Item1 - 1 , list[idx].Item2);
                    if (list[idx].Item1 == 0)
                    {
                        list.RemoveAt(0);
                        idx = -1;
                    }
                }
                else if (list[idx].Item1 == entryIdx)
                {
                    int inBridgeWeight = 0;
                    foreach (var i in list)
                    {
                        if (i.Item1 < entryIdx)
                        {
                            inBridgeWeight += i.Item2;
                        }
                        else
                        {
                            break;
                        }
                        //Console.WriteLine($"\n {inBridgeWeight}");
                    }

                    if (list[idx].Item2 + inBridgeWeight <= maxWeight)
                    {
                        list[idx] = (list[idx].Item1 - 1 , list[idx].Item2);
                        isStop = false;
                    }
                }
                else
                {
                    if (isStop == false)
                    {
                        list[idx] = (list[idx].Item1 - 1 , list[idx].Item2);
                    }
                }
                
                if (list.Count == 0)
                {
                    Console.WriteLine(answer);
                    return;
                }
            }
            
            // 출력
            /*foreach (var i in list)
            {
                Console.Write($"트럭 인덱스 : {i.Item1} , ");
            }
            Console.WriteLine();*/
            
        }
        
        Console.WriteLine(answer);
        
        // TODO : Console.WriteLine()은 StringBuilder랑 조합해서 출력합니다.
    }
}
