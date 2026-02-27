using System;
using System.Collections.Generic;

public class Solution 
{
    public string solution(string video_len, string pos, string op_start, string op_end, string[] commands) 
    {
        string answer = "";
        
        int videoLen = ConvertTime(video_len);
        int posTime = ConvertTime(pos);
        int opStartTime = ConvertTime (op_start);
        int opEndTime = ConvertTime(op_end);
        
        foreach(var command in commands)
        {
            // 1.check opening
            if(opStartTime <= posTime && posTime <= opEndTime)
            {
                posTime = opEndTime;
            }
            // 2.command
            if(command == "next")
            {
                posTime += 10;
                if(posTime >= videoLen)
                {
                    posTime = videoLen;
                }
            }
            else if(command == "prev")
            {
                posTime -= 10;
                if(posTime <= 0)
                {
                    posTime = 0;
                }
            }
            
            // 3.check opening
            if(opStartTime <= posTime && posTime <= opEndTime)
            {
                posTime = opEndTime;
            }
        }
        
        answer = ConvertTime2(posTime);
        
        return answer;
    }
    
    public int ConvertTime(string str)
    {
        int hour = Int32.Parse(str.Substring(0,2));
        int minute = Int32.Parse(str.Substring(3,2));
        
        return hour*60 + minute;
    }
    
    public string ConvertTime2(int time)
    {
        string hour = "";
        string minute = "";
        
        int hourInt = (time / 60);
        hour = hourInt.ToString();
        
        int minuteInt = time - hourInt*60;
        minute = minuteInt.ToString();
        
        //Console.WriteLine(hour + " : "+  minute);
        
        string ret = "";
        
        if(hourInt < 10)
        {
            ret += "0";
        }
        ret += hour;
        ret += ":";
        
        if(minuteInt < 10)
        {
            ret += "0";
        }
        ret += minute;
        
        //Console.WriteLine($"answer : {ret}");
        return ret;
    }
}