using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()
        // TODO : Parse input
        int tc = Int32.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();
        
        List<(int,int)> pathList = new List<(int,int)>();
        pathList.Add((-1,0));
        pathList.Add((1,0));
        pathList.Add((0,-1));
        pathList.Add((0,1));
        
        for(int testCase = 0 ; testCase < tc; testCase++)
        {
            string[] line = Console.ReadLine().Split();
            
            int row = Int32.Parse(line[1]); 
            int col = Int32.Parse(line[0]);
            int k = Int32.Parse(line[2]);
            
            int[,] arr = new int[row,col];
            bool[,] visit = new bool[row,col];
            
            for(int i=0; i<row; i++)
            {
                for(int j=0; j<col; j++)
                {
                    arr[i,j] = 0;
                    visit[i,j] = false;
                }
            }
            
            for(int i=0; i<k; i++)
            {
                line = Console.ReadLine().Split();
                int targetRow = Int32.Parse(line[1]);
                int targetCol = Int32.Parse(line[0]);
                arr[targetRow,targetCol] = 1;
            }
            
            int answer = 0;
            for(int i=0; i<row; i++)
            {
                for(int j=0; j<col; j++)
                {
                    if(visit[i,j] == false && arr[i,j] == 1)
                    {
                        visit[i,j] = true;
                        answer++;
                        
                        DFS(i,j, arr, visit, pathList,row-1,col-1);
                    }
                }
            }
            
            sb.AppendLine(answer.ToString());
        }
        
        Console.WriteLine(sb.ToString());
        
        
        
        // TODO : Console.WriteLine()은 StringBuilder랑 조합해서 출력합니다.
    }
    
    static void DFS(int inputRow, int inputCol, int[,] arr, bool[,] visit, List<(int,int)> pathList, int maxRow, int maxCol)
    {
        foreach(var tup in pathList)
        {
            int row = inputRow + tup.Item1;
            int col = inputCol + tup.Item2;
            if (row < 0 || maxRow < row)
            {
                continue;
            }

            if (col < 0 || maxCol < col)
            {
                continue;
            }
            
            if(arr[row,col] == 1 && visit[row,col] == false)
            {
                visit[row,col] = true;
                DFS(row, col, arr, visit, pathList, maxRow , maxCol);
            }
        }
    }
}
