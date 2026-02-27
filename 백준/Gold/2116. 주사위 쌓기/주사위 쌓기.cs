using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()
        int n = Int32.Parse(Console.ReadLine());
              
        var dice = new int[10001,7];
        var idxArr = new int[7];
        idxArr[1] = 6;
        idxArr[2] = 4;
        idxArr[3] = 5;
        idxArr[4] = 2;
        idxArr[5] = 3;
        idxArr[6] = 1;
                                
        for(int i=1; i<=n; i++)
        {
            var line = Console.ReadLine().Split();
            for(int j=1; j<=6; j++)
            {
                dice[i,j] = Int32.Parse(line[j-1]); 
            }
        }
        
        int maxAnswer = -1;
        
        // 1번 다이스 기준 6개
        for(int i = 1; i<=6; i++)
        {
            int downIdx = i;
            int upIdx = idxArr[i];
            
            int downValue = dice[1,downIdx];
            int upValue = dice[1,upIdx];     
            
            int answer = GetMax(downValue, upValue);
            for(int j=2; j<= n; j++)
            {
                var targetDice = new int[7];
                for (int k = 1; k <= 6; k++)
                {
                    targetDice[k] = dice[j, k];
                }
                
                // 타겟 주사위의 밑면 인덱스
                for(int idx = 1; idx<=6; idx++)
                {
                    if(targetDice[idx] == upValue)
                    {
                        downIdx = idx;
                        break;
                    }
                }
                
                upIdx = idxArr[downIdx];
                
                downValue = dice[j,downIdx];
                upValue = dice[j,upIdx];
                
                answer += GetMax(downValue,upValue);                
            }
            
            if(maxAnswer < answer)
            {
                maxAnswer = answer;
            }
        }
        
        Console.Write(maxAnswer);
    }
    
    static int GetMax(int a, int b)
    {
        var arr = new int[6];
        for(int i=0; i<6; i++)
        {
            arr[i] = i+1;
        }
        
        int max = -1;
        foreach(var i in arr)
        {
            if(i != a && i != b)
            {
                if(max < i)
                {
                    max = i;
                }
            }
        }
        
        return max;
    }
}
