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
        int computerCount = Int32.Parse(Console.ReadLine());
        int n = Int32.Parse(Console.ReadLine());
        
        var visitDict = new Dictionary<int,bool>();
        for(int i=1; i<=computerCount; i++)
        {
            visitDict[i] = false;
        }
        
        var connectDict = new Dictionary<int,HashSet<int>>();
        for(int i=1; i<=computerCount; i++)
        {
            connectDict[i] = new HashSet<int>();
        }
        
        for(int i=0; i<n; i++)
        {
            var line = Console.ReadLine().Split();
            int c1 = Int32.Parse(line[0]);
            int c2 = Int32.Parse(line[1]);
            
            connectDict[c1].Add(c2);
            connectDict[c2].Add(c1);
        }
        
        visitDict[1] = true;
        Find(1, connectDict, visitDict);
        
        int answer = 0;
        foreach(var kv in visitDict)
        {
            if(kv.Key > 1 && kv.Value == true)
            {
                answer++;
            }
        }
        
        Console.WriteLine(answer);
        // TODO : Console.WriteLine()은 StringBuilder랑 조합해서 출력합니다.
    }
    
    static void Find(int computerNum, Dictionary<int,HashSet<int>> connectDict, Dictionary<int,bool> visitDict)
    {
        foreach(var i in connectDict[computerNum])
        {
            if(visitDict[i] == false)
            {
                visitDict[i] = true;
                Find(i, connectDict, visitDict);
            }
        }
    }
}