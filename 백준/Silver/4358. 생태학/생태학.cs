using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
public class CSharpHabit
{
     static void Main()
     {
          var dict = new Dictionary<string, double>();
          double treeCount = 0;
          
          while (true)
          {
               var line = Console.ReadLine();
               if (line == null)
               {
                    Print();
                    
                    return;
               }

               treeCount++;
               if (dict.ContainsKey(line))
               {
                    dict[line] += 1.0;
               }
               else
               {
                    dict[line] = 1.0;
               }
          }

          void Print()
          {
               var sb = new StringBuilder();
               foreach (var pair in dict.OrderBy(kv => kv.Key))
               {
                    sb.Append(pair.Key);
                    sb.Append(' ');
                    sb.Append(Measure(pair.Value));
                    sb.AppendLine();
               }

               Console.Write(sb);
          }
         
          string Measure(double targetTreeCount)
          {
               double val = targetTreeCount / treeCount * 100.0;

               return val.ToString("F4");
          }
     }
}