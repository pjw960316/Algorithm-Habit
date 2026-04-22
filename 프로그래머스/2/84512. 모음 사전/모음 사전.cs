using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    private readonly char[] _alphaArr = { ' ', 'A', 'E', 'I', 'O', 'U' };
    private char[] _wordArr = new char[5];
    private Dictionary<string, int> _dict = new Dictionary<string, int>();
    
    private int _index = 1;
    private int _curDepth = -1;
    private StringBuilder sb = new StringBuilder();
    
    public int solution(string word) 
    {
        DFS(0);
        
        return _dict[word];
    }
    
    private void DFS(int depth)
    {
        if (depth == 5)
        {
            _curDepth = depth;
            UpdateDict();
            return;
        }

        for (int idx = 0; idx <= 5; idx++)
        {
            if (_alphaArr[idx] == ' ')
            {
                _curDepth = depth;
                UpdateDict();
                continue;
            }
            _wordArr[depth] = _alphaArr[idx];
            
            DFS(depth + 1);
        }
    }

    private void UpdateDict()
    {
        sb.Clear();

        if (_curDepth == 0)
        {
            return;
        }
        
        for (int depth = 0; depth < _curDepth; depth++)
        {
            var val = _wordArr[depth];
            if (val == ' ')
            {
                break;
            }
            
            sb.Append(val);
        }

        /*Console.Write(sb);
        Console.Write(" -> ");
        Console.Write(_index);
        Console.WriteLine();*/
        
        _dict[sb.ToString()] = _index;
        _index++;
    }
}