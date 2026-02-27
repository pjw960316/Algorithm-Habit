using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var sr = new StreamReader(Console.OpenStandardInput());
        var sw = new StringBuilder();

        var input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        var dict = new Dictionary<string, int>(n);

        for (int i = 0; i < n; i++)
        {
            var str = sr.ReadLine();
            if (str.Length < m) continue;

            if (dict.TryGetValue(str, out int cnt))
                dict[str] = cnt + 1;
            else
                dict[str] = 1;
        }

        var result = dict
            .OrderByDescending(kv => kv.Value)
            .ThenByDescending(kv => kv.Key.Length)
            .ThenBy(kv => kv.Key);

        foreach (var kv in result)
            sw.AppendLine(kv.Key);

        Console.Write(sw.ToString());
    }
}