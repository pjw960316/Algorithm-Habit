using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        var input = Console.ReadLine().Split();      
        // TODO : Parse input
        
        int n = Int32.Parse(input[0]);
        int m = Int32.Parse(input[1]);
        Dictionary<string,int> dict = new Dictionary<string,int>();
        Dictionary<int,string> dict2 = new Dictionary<int,string>();
        
        for(int key=1; key<=n; key++)
        {
            var monStr = Console.ReadLine();
            dict[monStr] = key;
            dict2[key] = monStr;
        }
        
        var sb = new StringBuilder();
        for(int i=0; i<m ;i++)
        {
            var str = Console.ReadLine();
            if('1' <= str[0] && str[0] <='9')
            {
                
                sb.AppendLine(dict2[Int32.Parse(str)]);
            }
            else
            {
                sb.AppendLine(dict[str].ToString());
            }
        }
        
        Console.WriteLine(sb.ToString());
        
        
        // TODO : Console.WriteLine()은 StringBuilder랑 조합해서 출력합니다.
    }
}