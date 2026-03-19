using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 
 public class CSharpHabit
 {
     static void Main()
     {
         int tcMax = int.Parse(Console.ReadLine());
         var dp = new int[12];
         
         MakeDP();

         var sb = new StringBuilder();
         for (int tc = 0; tc < tcMax; tc++)
         {
             var num = int.Parse(Console.ReadLine());
             
             sb.Append(dp[num]);
             sb.AppendLine();
         }

         Console.Write(sb);

         void MakeDP()
         {
             dp[1] = 1;
             dp[2] = 2;
             dp[3] = 4;
             
             for (int i = 4; i <= 10; i++)
             {
                 dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];
             }
         }
     }
 }