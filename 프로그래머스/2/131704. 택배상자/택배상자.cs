using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

// TODO : Programmer에서 Solution Class 복사하세요. 
public class Solution
{
    private Queue<int> _mainQueue = new Queue<int>();
    private Stack<int> _subStack = new Stack<int>();
    private int[] _orderArr;
    private int _curIdx = 0;
    
    public int solution(int[] order) 
    {
        _orderArr = order;
        int len = _orderArr.Length;

        for (int i = 0; i < len; i++)
        {
            _mainQueue.Enqueue(i + 1);
        }

        while (true)
        {
            if (Find())
            {
                _curIdx++;
            }
            else
            {
                return _curIdx;
            }
        }

        return -1;
    }

    private bool Find()
    {
        if (_orderArr.Length == _curIdx)
        {
            return false;
        }

        int target = _orderArr[_curIdx];

        while (true)
        {
            if (_subStack.Count > 0 && _subStack.Peek() == target)
            {
                _subStack.Pop();
                return true;
            }

            if (_mainQueue.Count > 0)
            {
                int val = _mainQueue.Dequeue();

                if (val == target)
                {
                    return true;
                }

                _subStack.Push(val);
            }
            else
            {
                return false;
            }
        }
    }
}