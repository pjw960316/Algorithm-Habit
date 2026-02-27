using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        var input = Console.ReadLine().Split();      
        // TODO : Parse input
        int n = Int32.Parse(input[0]);
        string game = input[1];
        
        HashSet<string> nameSet = new HashSet<string>();
        
        for(int i=0; i<n; i++)
        {
            nameSet.Add(Console.ReadLine());
        }
        int count = nameSet.Count;
        int answer = 0;
        if(game == "Y")
        {            
            answer = count; 
        }
        else if(game == "F")
        {
            answer = count / 2;
        }
        else if(game == "O")
        {
            answer = count / 3;
        }
        
        Console.WriteLine(answer);
        
        
        // TODO : Console.WriteLine()은 StringBuilder랑 조합해서 출력합니다.
    }
}
