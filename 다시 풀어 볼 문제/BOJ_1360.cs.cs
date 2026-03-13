using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 
 public class CSharpHabit
 {
     static void Main()
     {
         int n = int.Parse(Console.ReadLine());
         var dict = new Dictionary<int, List<(char, char)>>();

         for (int i = 0; i < n; i++)
         {
             var line = Console.ReadLine().Split();
             var commandName = line[0];
             var time = int.Parse(line[2]);

             dict[time] = new List<(char, char)>();
             
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

         Print();
         
         Console.Write(TranslateCommandDict());

         void MakeTypeCommand(char word, int time)
         {
             dict[time].Add(('+', word));
         }

         void MakeUndoCommand(int undoTime, int time)
         {
             var listList = FindUndoMembers(undoTime, time);

             foreach (var nestedList in listList.Reverse())
             {
                 var nestedListLen = nestedList.Count;
                 for (int idx = nestedListLen - 1; idx >= 0; idx--)
                 {
                     var plusMinus = nestedList[idx].Item1;
                     var word = nestedList[idx].Item2;
                     if (plusMinus == '+')
                     {
                         dict[time].Add(('-', word));
                     }
                     else
                     {
                         dict[time].Add(('+', word));
                     }
                 }
             }
         }

         /*IEnumerable<List<(char,char)>> FindUndoMembers(int undoTime, int time)
         {
             var startTime = time - undoTime;
             var endTime = time;

             var list = dict
                 .Where(pair => startTime <= pair.Key && pair.Key < endTime)
                 .OrderByDescending(pair => pair.Key)
                 .Select(pair => pair.Value);
                 //.ToList();

             return list;
         }*/
         
         IEnumerable<List<(char,char)>> FindUndoMembers(int undoTime, int time)
         {
             var startTime = time - undoTime;

             foreach (var pair in dict)
             {
                 if (startTime <= pair.Key && pair.Key < time)
                 {
                     yield return pair.Value;
                 }
             }
         }

         StringBuilder TranslateCommandDict()
         {
             var stack = new Stack<char>();
             
             foreach (var pair1 in dict.OrderBy(kv => kv.Key))
             {
                 var list = pair1.Value;
                 foreach (var pair2 in list)
                 {
                     var plusMinus = pair2.Item1;
                     var word = pair2.Item2;

                     if (plusMinus == '+')
                     {
                         stack.Push(word);
                     }
                     else
                     {
                         stack.Pop();
                     }
                 }
             }

             var sb = new StringBuilder();
             foreach (var i in stack)
             {
                 sb.Append(i);
             }

             var len = sb.Length;
             var retSb = new StringBuilder();
             for (int idx = len - 1; idx >= 0; idx--)
             {
                 retSb.Append(sb[idx]);
             }

             return retSb;
         }

         void Print()
         {
             Console.WriteLine($"=================================");
             foreach (var pair1 in dict)
             {
                 var list = pair1.Value;
                 foreach (var pair2 in list)
                 {
                     Console.Write($"{pair2.Item1} , {pair2.Item2}  // ");
                 }

                 Console.WriteLine();
             }
             Console.WriteLine($"=================================");
         }
     }
 }