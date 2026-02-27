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
        int m = Int32.Parse(Console.ReadLine());
        var line = Console.ReadLine().Split();
        var dict = new Dictionary<int,(int,int)>(); //k = 학번
        
        for(int i=0; i<m; i++)
        {
            int studentNum = Int32.Parse(line[i]);           
            
            if(dict.ContainsKey(studentNum))
            {
                var tuple = dict[studentNum];
                
                // 마지막에 다 +1할 거 Item2에
                var newTuple = (tuple.Item1+1, tuple.Item2);
                dict[studentNum] = newTuple;
            }
            else
            {
                if(dict.Count >= n)
                {
                    var key = dict.OrderBy(kv => kv.Value.Item1)
                        .ThenByDescending(kv => kv.Value.Item2)
                        .FirstOrDefault().Key;
                    
                    dict.Remove(key);
                }
                dict[studentNum] = (1,0);
            }

            foreach (var kv in dict)
            {
                dict[kv.Key] = (dict[kv.Key].Item1, dict[kv.Key].Item2 + 1);
            }
            
            /*Console.Write($"{i+1}번째  :  ");
            foreach (var kv in dict)
            {
                Console.Write($"{kv.Key} , {kv.Value}  ||||     ");
            }
            Console.WriteLine();*/
        }

        var sb = new StringBuilder();
        var newList = dict.OrderBy(kv => kv.Key)
            .Select(kv => kv.Key)
            .ToList();

        foreach (var i in newList)
        {
            sb.Append($"{i} ");
        }
        
        Console.WriteLine(sb.ToString());


        // TODO : Console.WriteLine()은 StringBuilder랑 조합해서 출력합니다.
    }
}