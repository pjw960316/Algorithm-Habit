using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int answer = 0;
        
        var input = Console.ReadLine().Split( );
        int n = Int32.Parse(input[0]);
        int m = Int32.Parse(input[1]);
        
        var str1 = new List<string>();
        for(int i=0; i<n; i++)
        {
            str1.Add(Console.ReadLine());
        }
        
        var str2 = new List<string>();
        for(int i=0; i<m; i++)
        {
            str2.Add(Console.ReadLine());
        }
        
        var nSet = new HashSet<string>();
        foreach(var i in str1)
        {
            nSet.Add(i);
        }        
        foreach(var i in str2)
        {
            if(nSet.Contains(i))
            {
                answer++;
            }
        }
        
        Console.WriteLine(answer);
    }
}