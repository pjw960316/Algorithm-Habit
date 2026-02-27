using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()
        
        int n = Int32.Parse(Console.ReadLine());
        var line = Console.ReadLine().Split();
        
        var arr = new int[6];
        for(int i=0; i<6; i++)
        {
            arr[i] = Int32.Parse(line[i]);
        }
        
        line = Console.ReadLine().Split();
        int tShirt = Int32.Parse(line[0]);
        int pen = Int32.Parse(line[1]);
        
        int tShirtSum = 0;
        for(int i=0; i<6; i++)
        {
            if(arr[i] % tShirt == 0)
            {
                tShirtSum += arr[i] / tShirt;
            }
            else
            {
                tShirtSum += arr[i] / tShirt + 1;
            }
        }
        Console.WriteLine(tShirtSum);
        Console.Write($"{n/pen} {n%pen}");
    }
}