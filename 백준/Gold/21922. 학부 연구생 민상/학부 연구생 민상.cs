public class CSharpHabit
{
    private static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()
        var line = Console.ReadLine().Split();
        var maxRow = int.Parse(line[0]);
        var maxCol = int.Parse(line[1]);

        var arr = new int[maxRow + 2, maxCol + 2];
        var airArr = new int[maxRow + 2, maxCol + 2];
        
        var path = new (int,int)[4];
        path[0] = (-1, 0);
        path[1] = (0, 1);
        path[2] = (1, 0);
        path[3] = (0, -1);

        var threePathIdxDict = new Dictionary<int, int>();
        var fourPathIdxDict = new Dictionary<int, int>();

        threePathIdxDict[0] = 1;
        threePathIdxDict[1] = 0;
        threePathIdxDict[2] = 3;
        threePathIdxDict[3] = 2;

        fourPathIdxDict[0] = 3;
        fourPathIdxDict[1] = 2;
        fourPathIdxDict[2] = 1;
        fourPathIdxDict[3] = 0;
        
        for (int r = 0; r <= maxRow + 1; r++)
        {
            for (int c = 0; c <= maxCol + 1; c++)
            {
                arr[r, c] = -1;
            }
        }

        for (int r = 1; r <= maxRow; r++)
        {
            line = Console.ReadLine().Split();
            for (int c = 1; c <= maxCol; c++)
            {
                arr[r, c] = int.Parse(line[c - 1]);
            }
        }
        
        var queue = new Queue<(int, int, int)>();
        for (int r = 1; r <= maxRow; r++)
        {
            for (int c = 1; c <= maxCol; c++)
            {
                if (arr[r, c] == 9)
                {
                    queue.Clear();
                    BFS(r, c);
                }
            }
        }

        //Print();
        Console.Write(GetAnswer());

        void BFS(int r , int c)
        {
            // 에어컨
            airArr[r, c] = 1;
            for (int pathIdx = 0; pathIdx < 4; pathIdx++)
            {
                int newRow = r + path[pathIdx].Item1;
                int newCol = c + path[pathIdx].Item2;

                if (arr[newRow, newCol] != -1)
                {
                    queue.Enqueue((newRow, newCol, pathIdx));
                }
            }
            
            while (true)
            {
                if (queue.Count == 0)
                {
                    return;
                }

                var data = queue.Dequeue();
                
                int row = data.Item1;
                int col = data.Item2;
                int pathIdx = data.Item3;
                var type = arr[row, col];

                airArr[row, col] = 1;

                int newRow = 0;
                int newCol = 0;
                int newPathIdx = 0;
                
                if (type == 0)
                {
                    newPathIdx = pathIdx;
                    newRow = row + path[pathIdx].Item1;
                    newCol = col + path[pathIdx].Item2;
                }
                else if (type == 1)
                {
                    newPathIdx = pathIdx;
                    if (pathIdx % 2 == 0)
                    {
                        newRow = row + path[pathIdx].Item1;
                        newCol = col + path[pathIdx].Item2;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (type == 2)
                {
                    newPathIdx = pathIdx;
                    if (pathIdx % 2 == 1)
                    {
                        newRow = row + path[pathIdx].Item1;
                        newCol = col + path[pathIdx].Item2;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (type == 3)
                {
                    newPathIdx = threePathIdxDict[pathIdx];
                    var newPath = path[newPathIdx];
                    newRow = row + newPath.Item1;
                    newCol = col + newPath.Item2;
                }
                else if (type == 4)
                {
                    newPathIdx = fourPathIdxDict[pathIdx];
                    var newPath = path[newPathIdx];
                    newRow = row + newPath.Item1;
                    newCol = col + newPath.Item2;
                }

                if (arr[newRow, newCol] != -1)
                {
                    queue.Enqueue((newRow, newCol, newPathIdx));
                }
            }
        }

        int GetAnswer()
        {
            int answer = 0;
            for (int r = 1; r <= maxRow; r++)
            {
                for (int c = 1; c <= maxCol; c++)
                {
                    if (airArr[r, c] == 1)
                    {
                        answer++;
                    }
                }
            }

            return answer;
        }

        void Print()
        {
            Console.WriteLine("=======================================");
            for (int r = 1; r <= maxRow; r++)
            {
                for (int c = 1; c <= maxCol; c++)
                {
                    Console.Write($"{airArr[r, c]} ");
                }

                Console.WriteLine();
            }
            Console.WriteLine("=======================================");
        }
    }
}