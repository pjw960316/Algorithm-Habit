using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Card
{
    public string a;
    public string b;
    public string c;

    public Card(string aa, string bb, string cc)
    {
        a = aa;
        b = bb;
        c = cc;
    }
}
public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()

        var hashSet = new HashSet<(int, int, int)>();
        var dict = new Dictionary<int, Card>();
        string[] line;
        
        for (int i = 1; i <= 9; i++)
        {
            line = Console.ReadLine().Split();
            var card = new Card(line[0], line[1], line[2]);

            dict[i] = card;
        }
        
        for (int i = 1; i <= 7; i++)
        {
            for (int j = i + 1; j <= 8; j++)
            {
                for (int k = j + 1; k <= 9; k++)
                {
                    var cardOne = dict[i];
                    var cardTwo = dict[j];
                    var cardThree = dict[k];
                    if (IsHab(cardOne, cardTwo, cardThree))
                    {
                        hashSet.Add((i, j, k));
                    }
                }
            }
        }

        /*Console.WriteLine($"\n\n hey : zzzzzzzzzzzz {hashSet.Count} ");
        foreach (var tuple in hashSet)
        {
            Console.WriteLine($"{tuple.Item1} {tuple.Item2} {tuple.Item3}");
        }*/

        int answer = 0;
        int n = int.Parse(Console.ReadLine());
        bool isUsedG = false;
        
        for (int i = 0; i < n; i++)
        {
            line = Console.ReadLine().Split();

            if (line[0] == "H")
            {
                //hashSet 0인지
                var num1 = int.Parse(line[1]);
                var num2 = int.Parse(line[2]);
                var num3 = int.Parse(line[3]);

                var list = new List<int>();
                list.Add(num1);
                list.Add(num2);
                list.Add(num3);
                list.Sort();
                num1 = list[0];
                num2 = list[1];
                num3 = list[2];
                
                if (hashSet.Contains((num1, num2, num3)))
                {
                    answer += 1;
                    hashSet.Remove((num1, num2, num3));
                }
                else
                {
                    answer -= 1;
                }

            }
            else if (line[0] == "G")
            {
                if (hashSet.Count == 0 && isUsedG == false)
                {
                    answer += 3;
                    isUsedG = true;
                }
                else
                {
                    answer -= 1;
                }
                
            }
        }

        Console.Write(answer);
    }

    // TODO : 실수 검토
    static bool IsHab(Card c1, Card c2, Card c3)
    {
        if (IsNestedHab(c1.a, c2.a, c3.a) == false)
        {
            return false;
        }

        if (IsNestedHab(c1.b, c2.b, c3.b) == false)
        {
            return false;
        }

        if (IsNestedHab(c1.c, c2.c, c3.c) == false)
        {
            return false;
        }

        return true;
    }

    static bool IsNestedHab(string str1, string str2, string str3)
    {
        bool p1 = ((str1 == str2) && (str2 == str3));
        bool p2 = ((str1 != str2) && (str2 != str3) && (str1 != str3));
        bool ret = ((p1 == true) && (p2 == false) || (p1 == false) && (p2 == true));

        return ret;
    }
}