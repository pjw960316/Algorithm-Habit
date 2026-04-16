using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public class Solution 
{
    public string solution(string s) 
    {
        var sb = new StringBuilder();

        var smallList = new List<char>();
        var bigList = new List<char>();
        
        foreach (var word in s)
        {
            if ('A' <= word && word <= 'Z')
            {
                bigList.Add(word);
            }
            else
            {
                smallList.Add(word);
            }
        }

        var bigs = bigList.OrderByDescending(x => x);
        var smalls = smallList.OrderByDescending(x => x);

        foreach (var i in smalls)
        {
            sb.Append(i);
        }

        foreach (var i in bigs)
        {
            sb.Append(i);
        }

        return sb.ToString();
    }
}