using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
public class CSharpHabit
{
    static void Main()
    {
        int n,tc;
        int tcMax = int.Parse(Console.ReadLine());
        var arr = new char[3];
        arr[0] = ' ';
        arr[1] = '+';
        arr[2] = '-';

        var answerSb = new StringBuilder();
        var list = new List<string>();
        for (tc = 0; tc < tcMax; tc++)
        {
            n = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();
            
            DFS(1,sb);
            
            //list.Sort();
                
            foreach (var str in list)
            {
                answerSb.AppendLine(str);
            }

            answerSb.AppendLine();
            list.Clear();
        }

        Console.Write(answerSb);

        void DFS(int num, StringBuilder sb)
        {
            sb.Append(IntToChar(num));
            
            if (num == n)
            {
                //Console.WriteLine(sb);
                if (MeasureStatement(sb) == 0)
                {
                    list.Add(sb.ToString());
                }
                
                return;
            }
            
            for (int i = 0; i < 3; i++)
            {
                sb.Append(arr[i]);
                DFS(num + 1, sb);

                var len = sb.Length;
                sb.Remove(len - 2, 2);
            }
        }

        char IntToChar(int num)
        {
            var str = num.ToString();
            return str[0];
        }

        int MeasureStatement(StringBuilder sb)
        {
            int ret = 0;
            int len = sb.Length;
            char curGiho = '+';
            
            var tmpSb = new StringBuilder();
            
            for (int idx = 0; idx < len; idx++)
            {
                char word = sb[idx];
                if ('1' <= word && word <= '9')
                {
                    tmpSb.Append(word); 

                    //마지막
                    if (idx == len - 1)
                    {
                        if (curGiho == '+')
                        {
                            //Console.WriteLine($"{curGiho} : {tmpSb.ToString()}");
                            ret += int.Parse(tmpSb.ToString());
                        }
                        else
                        {
                            //Console.WriteLine($"{curGiho} : {tmpSb.ToString()}");
                            ret -= int.Parse(tmpSb.ToString());
                        }
                        
                        /*if (sb.ToString() == "1-2+3+4-5+6 7")
                        {
                            Console.WriteLine($"answer : {idx} , {len}, {tmpSb} , {answer}");
                        }*/

                        return ret;
                    }
                }
                else if (word == ' ')
                {
                    
                }
                else
                {
                    if (curGiho == '+')
                    {
                        //Console.WriteLine($"{curGiho} : {tmpSb.ToString()}");
                        ret += int.Parse(tmpSb.ToString());
                    }
                    else
                    {
                        //Console.WriteLine($"{curGiho} : {tmpSb.ToString()}");
                        ret -= int.Parse(tmpSb.ToString());
                    }
                    
                    curGiho = word;
                    tmpSb.Clear();
                }
            }

            return -1;
        }
    }
}