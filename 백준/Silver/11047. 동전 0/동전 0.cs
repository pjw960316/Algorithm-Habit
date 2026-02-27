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
        
        string[] line = Console.ReadLine().Split();
        int n = Int32.Parse(line[0]);
        int sum = Int32.Parse(line[1]);
        
        List<int> list = new List<int>();
        for(int i=0; i<n; i++)
        {
            list.Add(Int32.Parse(Console.ReadLine()));
        }
        
        int answer = 0;
        int count = list.Count;
        for(int i=count-1; i>=0; i--)
        {
            if(sum <= 0)
            {
                Console.WriteLine(answer);
                return;
            }
            
            int val = list[i];
            int tmpCount = sum / val;
            if(tmpCount != 0)
            {
                answer += tmpCount;
                sum -= val * tmpCount;
            }
        }
        
        Console.WriteLine(answer);
        // TODO : Console.WriteLine()은 StringBuilder랑 조합해서 출력합니다.
    }
}
