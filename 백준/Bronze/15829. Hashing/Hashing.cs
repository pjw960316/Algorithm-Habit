using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()

        var dict = new Dictionary<char, int>();
        int val = 1;
        
        for (char word = 'a'; word <= 'z'; word++)
        {
            dict[word] = val;
            val++;
        }

        int n = int.Parse(Console.ReadLine());
        var line = Console.ReadLine();

        var arr = new long[52];
        arr[0] = 1;
        arr[1] = 1;
        
        for (int i = 2; i <= 51; i++)
        {
            arr[i] = (arr[i-1] * 31) % 1234567891;
        }

        long answer = 0;
        for (int i = 0; i < n; i++)
        {
            answer += dict[line[i]] * arr[i + 1];
            answer = answer % 1234567891;
        }

        Console.Write(answer);
    }
}