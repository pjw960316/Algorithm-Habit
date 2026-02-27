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
        var list = new List<string>();
        for(int i=0; i<n; i++)
        {
            list.Add(Console.ReadLine());
        }
        var dict = new Dictionary<string,int>(); // int = 문자열 길이
        var targetDict = new Dictionary<string,int>(); // int = 문자열 길이
        int max = -1;
        
        foreach(var str in list)
        {
            int len = str.Length;
            var spanStr = str.AsSpan();
            for(int spanLen = 1; spanLen<=len; spanLen++)
            {
                //var targetStr = spanStr.Slice(0,spanLen).ToString();
                var targetStr = str.Substring(0, spanLen);
                if(dict.ContainsKey(targetStr))
                {
                    max = Math.Max(max, spanLen);
                    targetDict[targetStr] = spanLen;
                }
                else
                {
                    dict[targetStr] = spanLen;
                }
            }
        }
        
        //Console.WriteLine(max);
        var maxSet = new HashSet<string>();
        foreach(var kv in targetDict)
        {
            if(kv.Value == max)
            {
                maxSet.Add(kv.Key);
            }
        }
        
        var isFindS = false;
        var finalStr = "";
        
        foreach(var str in list)
        {
            if (str.Length < max)
            {
                continue;
            }
            var spanStr = str.AsSpan();
            var targetStr = spanStr.Slice(0,max).ToString();
            
            if (maxSet.Contains(targetStr))
            {
                // 최초 S 찾기
                if (isFindS == false)
                {
                    finalStr = targetStr;
                    Console.WriteLine(str);
                }
                else
                {
                    if (targetStr == finalStr)
                    {
                        Console.WriteLine(str);
                        return;
                    }
                }
                isFindS = true;
            }
        }
    }
}
