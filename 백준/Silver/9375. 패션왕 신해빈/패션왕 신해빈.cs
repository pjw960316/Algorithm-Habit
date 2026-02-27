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
        int n = Int32.Parse(Console.ReadLine());
        
        var dict = new Dictionary<string,int>();
        StringBuilder sb = new StringBuilder();
        
        for(int i=0; i<n; i++)
        {
            int m = Int32.Parse(Console.ReadLine());
            
            dict.Clear();
            int answer = 1;
            string cloth = "";
            string body = "";
            
            for(int j=0; j<m; j++)
            {
                string[] line = Console.ReadLine().Split();
                
                cloth = line[0];
                body = line[1];
                
                if(dict.ContainsKey(body))
                {
                    dict[body]++;
                }
                else
                {
                    dict[body] = 2;
                }
            }
            int cnt = dict.Count;
            if(cnt == 0)
            {
                answer = 0;
            }
            else if(cnt == 1)
            {
                answer = dict[body] - 1;
            }
            else
            {
                foreach(var kv in dict)
                {
                    var val = kv.Value;
                    answer *= val;
                }
                answer -= 1;
            }
            sb.AppendLine(answer.ToString());
        }
        
        Console.WriteLine(sb.ToString());
        
        
        // TODO : Console.WriteLine()은 StringBuilder랑 조합해서 출력합니다.
    }
}
