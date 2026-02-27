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
        var list = new List<int>();
        var minMaxList = new List<int>();

        for (int i = 0; i < 1001; i++)
        {
            list.Add(0);
        }
        for(int i=0; i<n; i++)
        {
            var line = Console.ReadLine().Split();
            int index = Int32.Parse(line[0]);
            int height = Int32.Parse(line[1]);
            
            minMaxList.Add(index);
            list[index] = height;
        }

        minMaxList.Sort();
        
        int answer = 0;
        int startIndex = minMaxList[0];
        int endIndex = minMaxList[n-1];
        
        for(int idx = startIndex; idx<=endIndex; idx++)
        {
            int leftMaxHeight = list[idx];
            int rightMaxHeight = leftMaxHeight;
            
            for(int frontIdx= startIndex; frontIdx<=idx; frontIdx++)
            {
                if(leftMaxHeight < list[frontIdx])
                {
                    leftMaxHeight = list[frontIdx];
                }
            }
            for(int backIdx= endIndex; backIdx>=idx; backIdx--)
            {
                if(rightMaxHeight < list[backIdx])
                {
                    rightMaxHeight = list[backIdx];
                }
            }
            answer += Math.Min(leftMaxHeight, rightMaxHeight);
        }
      
        Console.WriteLine(answer);
    }
}