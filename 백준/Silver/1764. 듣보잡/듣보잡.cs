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
        int n = Int32.Parse(line[0]);
        int m = Int32.Parse(line[1]);
        
        var mySet_1 = new HashSet<string>();
        var mySet_2 = new HashSet<string>();
        
        for(int i=0; i<n; i++)
        {
            mySet_1.Add(Console.ReadLine());
        }
        
        for(int i=0; i<m; i++)
        {
            mySet_2.Add(Console.ReadLine());           
        }
        
        int answer = 0;
        List<string> nameList = new List<string>();
        StringBuilder sb = new StringBuilder();
        
        foreach(var name in mySet_1)
        {
            if(mySet_2.Contains(name))
            {
                answer++;
                nameList.Add(name);
            }
        }

        nameList.Sort();
        foreach (var name in nameList)
        {
            sb.AppendLine(name);
        }
        
        Console.WriteLine(answer);
        Console.WriteLine(sb.ToString());       
        // TODO : Console.WriteLine()은 StringBuilder랑 조합해서 출력합니다.
    }
}