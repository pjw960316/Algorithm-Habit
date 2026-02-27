using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int solution(int n, int w, int num) 
    {
        var arr = new List<int>[n+1]; 
        for(int i=0; i<arr.Length; i++)
        {
            arr[i] = new List<int>();
        }
        
        int idx = 1;
        bool isRight = true;
        
        for(int i=1; i<=n; i++)
        {           
            arr[idx].Add(i);
            
            if(i%w == 0)
            {
                continue;
            }
            if(i%w == 1 && i != 1)
            {
                isRight = !isRight;
            }
            if(isRight)
            {
                idx++;
            }
            else
            {
                idx--;
            }
        }
        
        /*foreach(var i in arr)
        {
            foreach(var j in i)
            {
                Console.Write($"{j} ");
            }
            Console.WriteLine("");
        }*/
        
        int tmp;
        int length = 0;
        
        int answer = 0;
        foreach(var list in arr)
        {
            tmp = 0;
            var len = list.Count;
            foreach(var i in list)
            {
                tmp++;
                if(num == i)
                {
                    answer = len - tmp + 1;
                    return answer;
                }
            }
        }
        return answer;
    }
}