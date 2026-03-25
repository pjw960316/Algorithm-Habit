using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
public class CSharpHabit
{
    static void Main()
    {
        int tcMax = int.Parse(Console.ReadLine());
        
        bool isReadRight;
        string commandStr;
        int arrLen;
        var arr = new int[100002];
        var sb = new StringBuilder();
        
        
        for (int tc = 0; tc < tcMax; tc++)
        {
            commandStr = Console.ReadLine();
            arrLen = int.Parse(Console.ReadLine());
            arr = InitializeArr(arrLen, Console.ReadLine());
            isReadRight = true;

            DoParse();
        }

        Console.Write(sb);
        
        int[] InitializeArr(int arrLen, string str)
        {
            var arr = new int[arrLen + 2];
            if (arrLen == 0)
            {
                return arr;
            }

            str = str.Substring(1, str.Length - 2);

            var strArr = str.Split(',');
            
            int idx = 1;
            foreach (var splitStr in strArr)
            {
                arr[idx] = int.Parse(splitStr);
                idx++;
            }

            return arr;
        }

        void DoParse()
        {
            var commandLen = commandStr.Length;
            
            int startIdx = 1;
            int endIdx = arrLen;
            int curLen = arrLen;

            for (int idx = 0; idx < commandLen; idx++)
            {
                if (commandStr[idx] == 'R')
                {
                    isReadRight = !isReadRight;
                }
                else
                {
                    if (curLen == 0)
                    {
                        sb.AppendLine("error");
                        return;
                    }
                    
                    if (isReadRight)
                    {
                        startIdx++;
                    }
                    else
                    {
                        endIdx--;
                    }

                    curLen--;
                }
            }

            UpdateStringBuilder(startIdx, endIdx);
        }

        void UpdateStringBuilder(int startIdx, int endIdx)
        {
            if (endIdx < startIdx)
            {
                sb.AppendLine("[]");
                return;
            }
            
            sb.Append('[');
            
            if (isReadRight)
            {
                for (int idx = startIdx; idx < endIdx; idx++)
                {
                    sb.Append(arr[idx]);
                    sb.Append(',');
                }
                sb.Append(arr[endIdx]);
            }
            else
            {
                for (int idx = endIdx; idx > startIdx; idx--)
                {
                    sb.Append(arr[idx]);
                    sb.Append(',');
                }
                sb.Append(arr[startIdx]);
            }

            sb.Append(']');
            sb.AppendLine();
        }
    }
}