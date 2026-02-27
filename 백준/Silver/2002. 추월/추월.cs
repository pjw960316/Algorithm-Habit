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
        
        if(n==1)
        {
            Console.WriteLine(0);
            return;
        }
        
        string str = "";
        
        var list = new List<string>();        
        var frontDict = new Dictionary<string,HashSet<string>>();
        var backDict = new Dictionary<string,HashSet<string>>();
        
        for(int i=0; i<n; i++)
        {
            str = Console.ReadLine();
            list.Add(str);
            
            var tmpHashSet = new HashSet<string>();
            
            for(int j=0; j<i; j++)
            {
                tmpHashSet.Add(list[j]);
            }
            frontDict[str] = tmpHashSet;
        }
        
        list.Clear();
        for(int i=0; i<n; i++)
        {
            str = Console.ReadLine();
            list.Add(str);
        }
        
        var len = list.Count;
        for(int i=0; i<n; i++)
        {
            var tmpHashSet = new HashSet<string>();
            
            for(int j=len-1; j>=0; j--)
            {
                if (i == j)
                {
                    break;
                }
                tmpHashSet.Add(list[j]);
            }
            backDict[list[i]] = tmpHashSet;
        }
        
        int answer = 0;
        
        //Console.WriteLine("\n");
        foreach(var kv in frontDict)
        {
            var frontSet = frontDict[kv.Key];
            var backSet = backDict[kv.Key];
            
            // log
            /*Console.WriteLine($"{kv.Key} 의 결과 : ");
            foreach (var a in frontSet)
            {
                Console.Write($"{a}  ");
            }
            Console.WriteLine();
            foreach (var b in backSet)
            {
                Console.Write($"{b}  ");
            }
            Console.WriteLine("\n");*/
            
            
            foreach(var element in frontSet)
            {
                if(backSet.Contains(element))
                {
                    answer++;
                    break;
                }
            }
        }
        
        Console.WriteLine(answer);
        
        // TODO : Console.WriteLine()은 StringBuilder랑 조합해서 출력합니다.
    }
}