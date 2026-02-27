using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        
        // TODO : Parse input
        int n = Int32.Parse(input);
        var list = new List<int>();
        
        for(int i=0; i<n; i++)
        {
            list.Add(Int32.Parse(Console.ReadLine()));
        }
        list.Sort();
        
        StringBuilder sb = new StringBuilder();
        foreach(var i in list)
        {
            sb.AppendLine(i.ToString());
        }
        
        Console.WriteLine(sb.ToString());
    }
}