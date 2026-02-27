using System;
using System.Text;
using System.Collections.Generic;

public class Solution {
    public int solution(string s) 
    {
        int answer = 0;
        int sLen = s.Length;
        StringBuilder sb = new StringBuilder(s);
        
        //1. 원형 검사
        if(Check(s))
        {
            answer++;   
        }
        
        //2. 이동 검사
        for(int i=0; i<sLen-1; i++)
        {
            string tmpStr = sb.ToString();
            sb.Append(tmpStr[0]);
            sb.Remove(0,1);
            
            if(Check(sb.ToString()))
            {
                answer++;
            }
        }
        
        return answer;
    }
    
    public bool Check(string str)
    {
        int cnt = 0;
        int len = str.Length;
        
        if(len % 2 == 1)
        {
            return false;
        }
        
        var stack = new Stack<char>();
        for(int idx = 0; idx < len; idx++)
        {
            if(str[idx] == '[' || str[idx] == '(' || str[idx] == '{')
            {
                stack.Push(str[idx]);
            }
            if(str[idx] == ']' || str[idx] == ')' || str[idx] == '}')
            {
                if(stack.Count == 0)
                {
                    return false;
                }
                var topElement = stack.Pop();
                if(str[idx] == ']' && topElement != '[')
                {
                    return false;
                }
                if(str[idx] == '}' && topElement != '{')
                {
                    return false;
                }
                if(str[idx] == ')' && topElement != '(')
                {
                    return false;
                }
            }
            
        }
        return true;        
    }
}