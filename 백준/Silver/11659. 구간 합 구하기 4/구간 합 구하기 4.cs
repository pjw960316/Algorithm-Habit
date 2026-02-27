using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        var line = Console.ReadLine().Split();      
        // TODO : Parse input
        
        int n = Int32.Parse(line[0]);
        int m = Int32.Parse(line[1]);
        List<int> list = new List<int>();  
        list.Add(0);
        
        line = Console.ReadLine().Split();

        for (int i = 0; i < line.Length; i++)
        {
            list.Add(Int32.Parse(line[i]));
        }
        
        
        List<int> sumList = new List<int>();
        sumList.Add(0);
        for(int i=1; i<=list.Count-1; i++)
        {
            sumList.Add(sumList[i-1] + list[i]);
        }
        
        StringBuilder sb = new StringBuilder();
        for(int ii =0; ii<m; ii++)
        {
            line = Console.ReadLine().Split();
            int i = Int32.Parse(line[0]);
            int j = Int32.Parse(line[1]);
            int ret = sumList[j] - sumList[i] + list[i];
            sb.AppendLine(ret.ToString());
        }

        Console.WriteLine(sb.ToString());
    }
}