using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
public class CSharpHabit
{
    static void Main()
    {
        var line = Console.ReadLine().Split();
        var hashSet = new HashSet<int>();
        
        int gameCount = int.Parse(line[0]);
        int winCount = int.Parse(line[1]);

        long pastPercent = (long)winCount * 100 / (long)gameCount;

        if (99 <= pastPercent)
        {
            Console.Write(-1);
            return;
        }
        
        int answer = 0;
        PlayGame(1, 1000000000);

        Console.Write(answer);
        
        void PlayGame(int left, int right)
        {
            //Console.WriteLine($"{left}  /  {right}");

            if (right <= left)
            {
                answer = right;
                return;
            }
            
            answer = (left + right) / 2;
            
            long curPercent = MeasurePercent(answer);
            if (pastPercent == curPercent)
            {
                left = answer+1;
            }
            else
            {
                right = answer;
            }
            PlayGame(left, right);
        }

        long MeasurePercent(int playGameSum)
        {
            int newGameCount = gameCount + playGameSum;
            int newWinCount = winCount + playGameSum;

            return (long)newWinCount * 100 / (long)newGameCount;
        }
    }
}