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
        int joka = Int32.Parse(line[0]);
        int snack = Int32.Parse(line[1]);
        var list = new List<int>();
        
        line = Console.ReadLine().Split();
        
        for(int i=0; i<snack; i++)
        {
            list.Add(Int32.Parse(line[i]));
        }
        
        list.Sort();
        
        int left = 1;
        int right = list[list.Count-1];      
        
        DoBinarySearch(left, right, joka, list);
                
    }
    
    static void DoBinarySearch(int left, int right, int joka, List<int> list)
    {
        if(right < left)
        {
            Console.WriteLine(right);
            return;
        }
        
        int mid = (left+right) / 2;
        int snackCount = 0;
        
        foreach(var i in list)
        {
            if (mid <= i)
            {
                snackCount += i / mid;
            }
        }
        
        //Console.WriteLine($"{left} , {right} , {mid} , {snackCount} , {joka}");
        if(snackCount < joka)
        {
            DoBinarySearch(left, mid-1, joka, list);
        }
        else if(snackCount >= joka)
        {
            DoBinarySearch(mid+1, right, joka, list);
        }
                
    }
}