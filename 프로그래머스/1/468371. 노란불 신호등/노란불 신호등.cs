using System;

public class Solution 
{
    public int solution(int[,] signals) 
    {
        int answer = 0;

        int rowMax = signals.GetLength(0);
        int colMax = 3;

        for (int t = 1; t <= 5000000; t++)
        {
            int yellowCnt = 0;

            for (int r = 0; r < rowMax; r++)
            {
                if (IsYellow(signals[r, 0], signals[r, 1], signals[r, 2], t))
                {
                    yellowCnt++;
                }
            }

            if (yellowCnt == rowMax)
            {
                answer = t;
                return answer;
            }
        }
        
        return -1;
    }

    private bool IsYellow(int green, int yellow, int red, int time)
    {
        int sum = green + yellow + red;
        int start = green + 1;
        int end = green + yellow;

        int val = time % sum;

        return (start <= val && val <= end);
    }
}