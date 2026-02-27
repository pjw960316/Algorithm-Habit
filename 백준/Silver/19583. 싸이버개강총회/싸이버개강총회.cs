using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()
        
        var line = Console.ReadLine().Split();
       
        var startTime = ConvertTime(line[0]);
        var midTime = ConvertTime(line[1]);
        var endTime = ConvertTime(line[2]);
        
        var frontSet = new HashSet<string>();
        var backSet = new HashSet<string>();
        
        string input = "";
        while ((input = Console.ReadLine()) != null)
        {
            line = input.Split();
            var time = ConvertTime(line[0]);
            var name = line[1];
            
            if(time <= startTime)
            {
                frontSet.Add(name);
            }
            
            if(midTime <= time && time <= endTime)
            {
                backSet.Add(name);
            }
        }
        
        int answer = 0;
        //
        // Console.WriteLine();
        //
        // Console.WriteLine($"############{startTime} , {midTime} , {endTime}");
        //
        // Console.WriteLine();
        
        // foreach (var i in frontSet)
        // {
        //     Console.Write($"{i} , ");
        // }
        // Console.WriteLine();
        //
        // foreach (var i in backSet)
        // {
        //     Console.Write($"{i} , ");
        // }
        
        foreach(var i in frontSet)
        {
            if(backSet.Contains(i))
            {
                answer++;
            }
        }
        Console.Write(answer);
    }
    
    static int ConvertTime(string timeStr)
    {
        var hourStr = timeStr.Substring(0,2);
        var minuteStr = timeStr.Substring(3,2);
        
        int minuteTime = 0;
        
        if(hourStr[0] > '0')
        {
            minuteTime = (hourStr[0] - '0') * 600;
        }
        minuteTime += (hourStr[1] - '0')*60;
        
        if(minuteStr[0] > '0')
        {
            minuteTime += (minuteStr[0] - '0') * 10;
        }
        minuteTime += minuteStr[1] - '0';
        
        return minuteTime;
    }
}
