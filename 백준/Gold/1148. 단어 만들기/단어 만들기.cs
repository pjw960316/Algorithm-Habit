using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        bool isMeetDash = false;
        var list = new List<Dictionary<char, int>>();
        var puzzleDict = new Dictionary<char, int>();
        var answerDict = new Dictionary<char, int>();
        
        while (true)
        {
            var line = Console.ReadLine();
            if (line == "-")
            {
                isMeetDash = true;
                continue;
            }

            if (line == "#")
            {
                return;
            }
            
            if (!isMeetDash)
            {
                var dict = new Dictionary<char, int>();
                
                foreach (var word in line)
                {
                    if (dict.ContainsKey(word))
                        dict[word]++;
                    else
                        dict[word] = 1;
                }

                list.Add(dict);
            }
            else
            {
                var len = line.Length;
                var bookLen = list.Count;
                
                puzzleDict.Clear();
                answerDict.Clear();
                
                for (int idx = 0; idx < len; idx++)
                {
                    var word = line[idx];
                    if (puzzleDict.ContainsKey(word))
                    {
                        puzzleDict[word]++;
                    }
                    else
                    {
                        puzzleDict[word] = 1;
                        answerDict[word] = 0;
                    }
                }

                for (int idx = 0; idx < bookLen; idx++)
                {
                    var bookDict = list[idx];
                    bool canSum = true;
                    
                    foreach (var kv in bookDict)
                    {
                        var word = kv.Key;
                        var count = kv.Value;

                        if (!puzzleDict.ContainsKey(word) || puzzleDict[word] < count)
                        {
                            canSum = false;
                            break;
                        }
                    }

                    if (canSum)
                    {
                        foreach (var kv in answerDict)
                        {
                            if (bookDict.ContainsKey(kv.Key))
                                answerDict[kv.Key]++;
                        }
                    }
                }

                int min = int.MaxValue;
                int max = int.MinValue;

                foreach (var kv in answerDict)
                {
                    var count = kv.Value;
                    if (count < min) min = count;
                    if (count > max) max = count;
                }

                var sbMin = new List<char>();
                var sbMax = new List<char>();

                foreach (var kv in answerDict)
                {
                    if (kv.Value == min) sbMin.Add(kv.Key);
                    if (kv.Value == max) sbMax.Add(kv.Key);
                }

                sbMin.Sort();
                sbMax.Sort();

                foreach (var c in sbMin) Console.Write(c);
                Console.Write($" {min} ");
                foreach (var c in sbMax) Console.Write(c);
                Console.WriteLine($" {max}");
            }
        }
    }
}
