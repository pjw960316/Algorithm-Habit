using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        var input = Console.ReadLine();      
        // TODO : Parse input
        
        int n = Int32.Parse(input);
        HashSet<int> mySet = new HashSet<int>();
        string setKey = "";
        int num = 0;
        StringBuilder sb = new StringBuilder();
        
        for(int i=0; i<n; i++)
        {
            string[] str = Console.ReadLine().Split();
            setKey = str[0];
            
            if(setKey == "add")
            {
                num = Int32.Parse(str[1]);
                mySet.Add(num);                
            }
            else if(setKey == "remove")
            {
                num = Int32.Parse(str[1]);
                mySet.Remove(num);
            }
            else if(setKey == "check")
            {
                num = Int32.Parse(str[1]);
                if(mySet.Contains(num))
                {
                    sb.AppendLine("1");
                }
                else
                {
                    sb.AppendLine("0");
                }
                   
            }
            else if(setKey == "toggle")
            {
                num = Int32.Parse(str[1]);
                if(mySet.Contains(num))
                {
                    mySet.Remove(num);
                }
                else
                {
                    mySet.Add(num);
                }
            }
            else if(setKey == "all")
            {
                mySet.Clear();
                for(int j=1; j<=20; j++)
                {
                    mySet.Add(j);
                }
            }
            else if(setKey == "empty")
            {
                mySet.Clear();
            }
        }
        
        Console.WriteLine(sb.ToString());
        
        
        // TODO : Console.WriteLine()은 StringBuilder랑 조합해서 출력합니다.
    }
}