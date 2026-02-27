using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()
        
        var sb = new StringBuilder();
        
        while(true)
        {
            var line = Console.ReadLine().Split();
            var list = new List<int>();
            
            int a = Int32.Parse(line[0]);
            int b = Int32.Parse(line[1]);
            int c = Int32.Parse(line[2]);
            
            if(a==0 && b==0 && c==0)
            {
                Console.Write(sb.ToString());
                return;
            }
            
            list.Add(a);
            list.Add(b);
            list.Add(c);
            
            list.Sort();
            
            if(list[0]*list[0] + list[1] * list[1] == list[2] * list[2])
            {
                sb.AppendLine("right");
            }
            else
            {
                sb.AppendLine("wrong");
            }
        }
        
    }
}