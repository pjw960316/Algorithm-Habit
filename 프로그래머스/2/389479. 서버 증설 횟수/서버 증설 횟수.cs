using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution {
    public int solution(int[] players, int m, int k) 
    {
        int answer = 0;
        
        var list = new List<int>(); 
        
        for(int t=1; t<=24; t++)
        {
            var playerCount = players[t-1];
                        
            list = list.Where(x => x != t).ToList();
            
            var currentServerCount = list.Count;
            var needServerCount = playerCount / m;
            
            if(currentServerCount < needServerCount)
            {
                var addServerCount = needServerCount - currentServerCount;
                answer += addServerCount;
                
                for(int i=0; i<addServerCount; i++)
                {
                    list.Add(t+k);
                }
            }
            
        }
        
        return answer;
    }
}