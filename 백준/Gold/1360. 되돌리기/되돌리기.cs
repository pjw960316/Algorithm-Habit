using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 
 public class CSharpHabit
 {
     static void Main()
     {
         int n = int.Parse(Console.ReadLine());
         var dict = new Dictionary<int, string>();

         for (int i = 0; i < n; i++)
         {
             var line = Console.ReadLine().Split();
             var commandName = line[0];
             var time = int.Parse(line[2]);

             if (commandName == "type")
             {
                 var word = line[1][0];
                 MakeTypeCommand(word,time);
             }
             else
             {
                 var undoTime = int.Parse(line[1]);
                 MakeUndoCommand(undoTime, time);
             }
         }

         //Print();

         var answer = dict
             .OrderBy(kv => kv.Key)
             .LastOrDefault()
             .Value;

         Console.Write(answer);
        
         void MakeTypeCommand(char word, int time)
         {
             var curString = dict
                 .OrderBy(kv => kv.Key)
                 .LastOrDefault()
                 .Value;
             
             var newStr = curString + word.ToString();
             
             dict[time] = newStr;
         }

         void MakeUndoCommand(int undoTime, int time)
         {
             var pastTime = time - undoTime - 1;
             
             var curString = dict
                 .OrderBy(kv => kv.Key)
                 .LastOrDefault(kv => kv.Key <= pastTime)
                 .Value;

             dict[time] = curString;
         }

         void Print()
         {
             Console.WriteLine($"=================================");
             foreach (var kv in dict.OrderBy(kv => kv.Key))
             {
                 Console.WriteLine($"{kv.Key}초 : {kv.Value}");
             }
             
             Console.WriteLine($"=================================");
         }
     }
 }