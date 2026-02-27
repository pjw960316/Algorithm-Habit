using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()

        int n = int.Parse(Console.ReadLine());
        var arr = new string[n];
        var dict = new Dictionary<string, Dictionary<char, int>>();
        
        for (int i = 0; i < n; i++)
        {
            var key = Console.ReadLine();
            arr[i] = key;
            dict[key] = new Dictionary<char, int>();

            var nestedDict = dict[key];
            int len = key.Length;

            for (char tmp = 'A'; tmp <= 'Z'; tmp++)
            {
                nestedDict[tmp] = 0;
            }
            for (int idx = 0; idx < len; idx++)
            {
                var data = key[idx];
                nestedDict[data]++;
            }
        }

        string frontStr = "";
        string backStr = "";
        int answer = 0;
        
        // 문제 잘못읽어서 이렇게 수정
        for (int i = 0; i < 1; i++)
        {
            frontStr = arr[i];
            var frontStrLen = frontStr.Length;
            var frontDict = dict[frontStr];
            
            for (int j = i + 1; j < n; j++)
            {
                backStr = arr[j];
                var backStrLen = backStr.Length;
                var backDict = dict[backStr];
                
                //1. 같을 때
                if (frontStrLen == backStrLen)
                {
                    if (IsSameOne(frontDict,backDict))
                    {
                        //Console.WriteLine($"log : {frontStr} , {backStr}");
                        answer++;
                        continue;
                    }
                }
                
                //2. 1차이
                if (Math.Abs(frontStrLen - backStrLen) == 1)
                {
                    if (IsSameTwo(frontDict,backDict))
                    {
                        //Console.WriteLine($"log : {frontStr} , {backStr}");
                        answer++;
                        continue;
                    }
                }
            }
        }

        Console.Write(answer);
    }

    static bool IsSameOne(Dictionary<char, int> frontDict, Dictionary<char, int> backDict)
    {
        int diffCnt = 0;

        for (char word = 'A'; word <= 'Z'; word++)
        {
            if (Math.Abs(frontDict[word] - backDict[word]) == 0)
            {
                continue;
            }
            else if(Math.Abs(frontDict[word] - backDict[word]) == 1)
            {
                diffCnt++;
            }
            else
            {
                return false;
            }
        }

        if (diffCnt == 0 || diffCnt == 2)
        {
            return true;
        }
        return false;
    }

    static bool IsSameTwo(Dictionary<char, int> frontDict, Dictionary<char, int> backDict)
    {
        int diffCnt = 0;

        for (char word = 'A'; word <= 'Z'; word++)
        {
            if (Math.Abs(frontDict[word] - backDict[word]) == 0)
            {
                continue;
            }
            else if(Math.Abs(frontDict[word] - backDict[word]) == 1)
            {
                diffCnt++;
            }
            else
            {
                return false;
            }
        }

        if (diffCnt == 1)
        {
            return true;
        }

        return false;
    }
}