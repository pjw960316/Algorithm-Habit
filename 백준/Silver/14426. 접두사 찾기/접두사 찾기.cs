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
        StringBuilder sb = new StringBuilder();
        var hashSet = new HashSet<string>();
        
        for(int idx=0; idx<n; idx++)
        {
            string str = Console.ReadLine();
            int len = str.Length;
            sb.Clear();
            
            for(int i=0; i<len; i++)
            {
                sb.Append(str[i]);
                hashSet.Add(sb.ToString());
            }
        }
        
        int answer = 0;
        for(int idx=0; idx<m; idx++)
        {
            string str = Console.ReadLine();
            if(hashSet.Contains(str))
            {
                answer++;
            }
        }
        
        Console.WriteLine(answer);
        
        
        // TODO : Console.WriteLine()은 StringBuilder랑 조합해서 출력합니다.
    }
}
