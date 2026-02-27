using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] schedules, int[,] timelogs, int startday) 
    {
        int answer = 0;
        for(int i=0; i<timelogs.GetLength(0); i++)
        {
            var ratioTime = schedules[i];
            var ratioHour = ratioTime / 100;
            var ratioMinute = ratioTime - ratioHour*100;
            ratioTime = ratioHour*60 + ratioMinute;
                
            int goodDay = 0;
            int checkDay = 0;
            int day = startday;
            
            for(int j=0; j<timelogs.GetLength(1); j++)
            {
                if(day == 6)
                {
                    day++;
                    continue;
                }
                if(day == 7)
                {
                    day = 1;
                    continue;
                }
                day++;
                checkDay++;
                
                var time = timelogs[i,j];
                int hour = time / 100;
                int minute = time - hour*100;
                time = hour*60 + minute;
                
                if(time <= ratioTime + 10)
                {
                    goodDay++;
                    continue;
                }
            }
            
            if(checkDay == goodDay)
            {
                answer++;
            }
        }
        
        return answer;
    }
}