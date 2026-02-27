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
        var arr = new int[n+1,n+1];
        var visit = new bool[n+1,n+1];
        var list = new List<int>();
        
        for(int row=1; row<=n; row++)
        {
            var line = Console.ReadLine();
            for(int col=1; col<=n; col++)
            {
                arr[row, col] = line[col - 1] - '0';
            }
        }
        
        int homeNum = 1;
        for(int row=1; row<=n; row++)
        {
            int homeCount = 0;
            for(int col=1; col<=n; col++)
            {
                if(arr[row,col] != 0 && visit[row,col] == false)
                {                       
                    // 갱신은 Dfs에서 해야 한다.
                    Dfs(row,col, homeNum, ref homeCount, arr,visit, n);

                    // Dfs 될 때 마다
                    list.Add(homeCount);
                    homeCount = 0;
                    homeNum++;
                }
            }
        }

        list.Sort();
        
        Console.WriteLine(homeNum-1);
        foreach (var i in list)
        {
            Console.WriteLine(i);
        }
    }
    
    static void Dfs(int row, int col, int homeNum, ref int homeCount, int[,] arr, bool[,] visit, int n)
    {
        visit[row,col] = true;
        arr[row,col] = homeNum;
        homeCount++;
        
        var pathArr = new (int,int)[4];
        pathArr[0] = (-1,0);
        pathArr[1] = (0,1);
        pathArr[2] = (1,0);
        pathArr[3] = (0,-1);
        
        foreach(var pair in pathArr)
        {
            int newRow = pair.Item1 + row;
            int newCol = pair.Item2 + col;

            if (newRow < 1 || newRow > n || newCol < 1 || newCol > n)
            {
                continue;
            }
            
            if(arr[newRow,newCol] != 0 && visit[newRow,newCol] == false)
            {    
                Dfs(newRow,newCol, homeNum, ref homeCount, arr, visit, n);
            }
        }
    }
}