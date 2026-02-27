using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Box
{
    public bool hasRobot;
    public int energy;

    public Box(bool a , int b)
    {
        hasRobot = a;
        energy = b;
    }
}
public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()

        var line = Console.ReadLine().Split();
        int n = int.Parse(line[0]);
        int destroyCount = int.Parse(line[1]);
        var beltArr = new Box[2*n + 1];
        
        line = Console.ReadLine().Split();
        var boxCount = 2 * n;
        for (int i = 1; i <= boxCount; i++)
        {
            var energy = int.Parse(line[i - 1]);
            var box = new Box(false, energy);
            beltArr[i] = box;
        }
        
        int time = 0;
        
        while (true)
        {
            //time++;
            RoundBelt(beltArr, boxCount);
            
            /*Console.Write($"{time} : \n");
            for (int idx = 1; idx <= boxCount; idx++)
            {
                Console.Write($"{beltArr[idx].hasRobot} , {beltArr[idx].energy}  /// ");
            }

            Console.WriteLine();*/
            
            MoveRobot(beltArr, boxCount);
            MoveUpRobot(beltArr);

            int energyZeroCount = 0;
            for (int idx = 1; idx <= boxCount; idx++)
            {
                if (beltArr[idx].energy <= 0)
                {
                    energyZeroCount++;
                }
            }
            time++;
            
            //test
            /*Console.Write($"{time} : \n");
            for (int idx = 1; idx <= boxCount; idx++)
            {
                Console.Write($"{beltArr[idx].hasRobot} , {beltArr[idx].energy}  /// ");
            }

            Console.WriteLine();*/
            
            if (energyZeroCount >= destroyCount)
            {
                Console.Write(time);
                return;
            }
        }
    }

    static void RoundBelt(Box[] arr, int len)
    {
        var copiedArr = new Box[len + 1];
        for (int i = 1; i <= len; i++)
        {
            var hasRobot = arr[i].hasRobot;
            var energy = arr[i].energy;
            copiedArr[i] = new Box(hasRobot, energy);
        }
        for (int i = 1; i <= len-1; i++)
        {
            arr[i + 1].energy = copiedArr[i].energy;
            arr[i + 1].hasRobot = copiedArr[i].hasRobot;
        }

        arr[1].energy = copiedArr[len].energy;
        arr[1].hasRobot = copiedArr[len].hasRobot;
    }

    static void MoveRobot(Box[] arr, int len)
    {
        
        // len 은 짝수 보장
        int outIdx = len / 2;
        
        // 하차지역에서는 즉시 하차
        arr[outIdx].hasRobot = false;
        
        // 먼저 올라간 놈이 더 오른쪽임.
        for (int idx = outIdx-1; idx >= 1; idx--)
        {
            if (arr[idx].hasRobot == true && (arr[idx + 1].energy >= 1 && arr[idx+1].hasRobot == false))
            {
                arr[idx + 1].energy--;
                arr[idx + 1].hasRobot = true;
                
                arr[idx].hasRobot = false;
            }
            
            // 하차지역에서는 즉시 하차
            arr[outIdx].hasRobot = false;
        }
    }

    static void MoveUpRobot(Box[] arr)
    {
        if (arr[1].energy >= 1)
        {
            arr[1].hasRobot = true;
            arr[1].energy--;
        }
    }
}