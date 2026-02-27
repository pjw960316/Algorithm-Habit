using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()
        
        int tcMax = Int32.Parse(Console.ReadLine());
        var phoneList = new List<string>();
        var sb = new StringBuilder();
        
        for(int tc=0; tc<tcMax; tc++)
        {
            int n = Int32.Parse(Console.ReadLine());
            bool isNo = false;
            
            phoneList.Clear();
            
            for(int i=0; i<n; i++)
            {
                phoneList.Add(Console.ReadLine());
            }
            
            phoneList.Sort();
            int len = phoneList.Count;
            
            for(int idx=1; idx<len; idx++)
            {
                var targetStr = phoneList[idx];
                var beforeStr = phoneList[idx-1];
                               
                var beforeStrLen = beforeStr.Length;
                var targetStrLen = targetStr.Length;
                if (targetStrLen < beforeStrLen)
                {
                    continue;
                }
                
                var tmpSb = new StringBuilder();
                for(int jdx=0; jdx<beforeStrLen; jdx++)
                {
                    tmpSb.Append(targetStr[jdx]);
                }
                if(tmpSb.ToString() == beforeStr)
                {
                    sb.AppendLine("NO");
                    isNo = true;
                    break;
                }
            }

            if (!isNo)
            {
                sb.AppendLine("YES");
            }
        }
        
        Console.Write(sb.ToString());
    }
}