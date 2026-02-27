using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()

        var arr = new char[5, 8];
        var moveArr = new int[5];

        for (int topniIdx = 1; topniIdx <= 4; topniIdx++)
        {
            var line = Console.ReadLine();
            for (int i = 0; i < 8; i++)
            {
                arr[topniIdx, i] = line[i];
            }
        }

        int n = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < n; i++)
        {
            var line = Console.ReadLine().Split();
            int moveTopniIdx = int.Parse(line[0]);
            int path = int.Parse(line[1]);

            for (int j = 0; j < 5; j++)
            {
                moveArr[j] = 0;
            }
            moveArr[moveTopniIdx] = path;
            
            if (moveTopniIdx <= 2)
            {
                UpdatePathArr(1, 2, arr, moveArr);
                UpdatePathArr(2, 3, arr, moveArr);
                UpdatePathArr(3, 4, arr, moveArr);
            }
            else if (moveTopniIdx >= 3)
            {
                UpdatePathArr(3, 4, arr, moveArr);
                UpdatePathArr(2, 3, arr, moveArr);
                UpdatePathArr(1, 2, arr, moveArr);
            }
            
            UpdateTopni(arr, moveArr);
        }
        
        double answer = 0;
        int tmp = 1;
        for (int idx = 1; idx <= 4; idx++)
        {
            if (arr[idx, 0] == '1')
            {
                answer += tmp;
            }
            tmp *= 2;
        }

        Console.Write(answer);
        return;
    }
    
    static void UpdatePathArr(int leftIdx, int rightIdx, char[,] arr, int[] moveArr)
    {
        // 같으면 무시
        if (arr[leftIdx,2] == arr[rightIdx,6])
        {
            return;
        }

        if (moveArr[rightIdx] == 1)
        {
            moveArr[leftIdx] = -1;
        }
        if (moveArr[rightIdx] == -1)
        {
            moveArr[leftIdx] = 1;
        }
        if (moveArr[leftIdx] == -1)
        {
            moveArr[rightIdx] = 1;
        }
        if (moveArr[leftIdx] == 1)
        {
            moveArr[rightIdx] = -1;
        }
    }

    static void UpdateTopni(char[,] arr, int[] moveArr)
    {
        for (int idx = 1; idx <= 4; idx++)
        {
            // 시계
            if (moveArr[idx] == 1)
            {
                MoveClock(arr, idx);
            }
            
            // 반시계
            else if(moveArr[idx] == -1)
            {
                MoveOppositeClock(arr, idx);
            }
        }
    }

    static void MoveClock(char[,] arr, int topniIdx)
    {
        var copiedArr = new char[5, 8];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                copiedArr[i, j] = arr[i,j];
            }
        }

        arr[topniIdx, 0] = copiedArr[topniIdx, 7];
        for (int col = 1; col <= 7; col++)
        {
            arr[topniIdx, col] = copiedArr[topniIdx, col - 1];
        }
    }
    
    static void MoveOppositeClock(char[,] arr, int topniIdx)
    {
        var copiedArr = new char[5, 8];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                copiedArr[i, j] = arr[i,j];
            }
        }
        arr[topniIdx, 7] = copiedArr[topniIdx, 0];
        for (int col = 0; col <= 6; col++)
        {
            arr[topniIdx, col] = copiedArr[topniIdx, col+1];
        }
    }
}