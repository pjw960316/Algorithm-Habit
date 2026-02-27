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
        int fullLen = Int32.Parse(line[0]);
        int subLen = Int32.Parse(line[1]);
        
        string str = Console.ReadLine();
        line = Console.ReadLine().Split();
        int a = Int32.Parse(line[0]);
        int c = Int32.Parse(line[1]);
        int g = Int32.Parse(line[2]);
        int t = Int32.Parse(line[3]);
        
        var dict = new Dictionary<char,int>();
        dict['A'] = 0;
        dict['C'] = 0;
        dict['G'] = 0;
        dict['T'] = 0;
        int answer = 0;
        
        var initStr = str.Substring(0,subLen);
        for(int idx=0; idx<initStr.Length; idx++)
        {
            dict[str[idx]]++;
        }
        if(Check(dict, a,c,g,t))
        {
            answer++;
        }

        var count = fullLen - subLen;
        for(int idx = 1; idx<= count; idx++)
        {
            dict[str[idx-1]]--;
            dict[str[idx-1+subLen]]++;
            
            if(Check(dict, a,c,g,t))
            {
                answer++;
            }
        }
        Console.WriteLine(answer);
        
        
        // TODO : Console.WriteLine()은 StringBuilder랑 조합해서 출력합니다.
    }
    
    static bool Check(Dictionary<char,int> dict, int a, int c, int g, int t)
    {
        if(dict['A'] < a)
        {
            return false;
        }
        if(dict['C'] < c)
        {
            return false;
        }
        if(dict['G'] < g)
        {
            return false;
        }
        if(dict['T'] < t)
        {
            return false;
        }
        return true;
    }
}