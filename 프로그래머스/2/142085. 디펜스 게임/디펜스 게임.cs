public class Solution
{
    private int[] _enemyArr;
    private int _skipCount;
    private int _curSoldier;
    
    private PriorityQueue<int, int> _pq = new PriorityQueue<int, int>();
    
    public int solution(int n, int k, int[] enemy)
    {
        var answer = 0;

        _curSoldier = n;
        _skipCount = k;
        _enemyArr = new int[enemy.Length + 2];
        
        for (int idx = 0; idx < enemy.Length; idx++)
        {
            _enemyArr[idx + 1] = enemy[idx];
        }
        
        for(int idx=1; idx<=enemy.Length; idx++)
        {
            if (IsOkay(_enemyArr[idx]))
            {
                answer++;
            }
            else
            {
                return answer;
            }
        }

        return answer;
    }

    private bool IsOkay(int element)
    {
        if (_pq.Count < _skipCount)
        {
            _pq.Enqueue(element,element);
            
            return true;
        }
        
        if (_pq.Peek() < element)
        {
            _curSoldier -= _pq.Dequeue();
            _pq.Enqueue(element,element);
        }
        else
        {
            _curSoldier -= element;
        }

        if (_curSoldier < 0)
        {
            return false;
        }

        return true;
    }
}

public class Program
{
    public static void Main()
    {
        var sol = new Solution();

        // TODO
        // Static Input Class의 메서드를 활용해서 solution 메서드에 인자를 넣으세요.
        Console.Write(sol.solution(Input.ReadInt(), Input.ReadInt(), Input.ReadInts()));
    }
}