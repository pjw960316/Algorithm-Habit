using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public struct DTO
{
    public int row;
    public int col;
    public int day;
            
    public DTO(int a, int b , int c)
    {
        row = a;
        col = b;
        day = c;
    }
}
public class CSharpHabit
{
    static void Main()
    {
        
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()
        var line = Console.ReadLine().Split();
        int rowMax = Int32.Parse(line[1]);
        int colMax = Int32.Parse(line[0]);
        
        var arr = new int[rowMax+2,colMax+2];
        var visit = new bool[rowMax+2,colMax+2];
        
        for(int row = 0; row<= rowMax+1; row++)
        {
            for(int col = 0; col <= colMax+1; col++)
            {
                arr[row,col] = -1;                
            }
        }

        bool isAnswerZero = true;
        int day = 1;
        var queue = new Queue<DTO>();
        for(int row = 1; row<= rowMax; row++)
        {
            line = Console.ReadLine().Split();
            for(int col = 1; col <= colMax; col++)
            {
                string str = line[col-1];
                if(str == "0")
                {
                    arr[row,col] = 0;
                    isAnswerZero = false;
                }
                else if(str == "1")
                {
                    arr[row,col] = 1;       
                    
                    queue.Enqueue(new(row,col,day));
                    visit[row,col] = true;
                }
                else
                {
                    arr[row,col] = -1;
                }                
            }
        }    
        
        if(isAnswerZero)
        {
            Console.Write(0);
            return;
        }
        
        var path = new (int,int)[4];
        path[0] = (-1,0);
        path[1] = (1,0);
        path[2] = (0,-1);
        path[3] = (0,1);
        
        //bfs
        int max = -1;
        while(0 < queue.Count)
        {
            // class -> ref
            var data = queue.Peek();
            for(int i=0; i<4; i++)
            {
                int newRow = data.row + path[i].Item1;
                int newCol = data.col + path[i].Item2;
                int myDay = data.day;
                
                // 어차피 최초의 1이었던 놈은 이미 검사를 했고, 걔는 day가 더 작으니 무시
                if(arr[newRow,newCol] == 0 && visit[newRow,newCol] == false)
                {
                    arr[newRow,newCol] = 1;
                    visit[newRow,newCol] = true;
                    
                    queue.Enqueue(new(newRow,newCol,myDay+1));
                    
                    if(max < myDay + 1)
                    {
                        max = myDay+1;
                    }
                }
            }
            queue.Dequeue();           
        }   
        
        for(int row = 1; row<= rowMax; row++)
        {
            for(int col = 1; col <= colMax; col++)
            {          
                if(arr[row,col] == 0)
                {
                    Console.Write(-1);
                    return;
                }
            }
        }
        
        Console.Write(max-1);
    }
}
