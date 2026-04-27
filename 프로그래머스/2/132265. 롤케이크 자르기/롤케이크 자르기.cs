using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public class Solution 
{
    private int[] _dpLeft = new int[1000003];
    private int[] _dpRight = new int[1000003];
    
    private HashSet<int> _leftHashSet = new HashSet<int>();
    private HashSet<int> _rightHashSet = new HashSet<int>();
    
    private int _maxToppingCount;
    
    public int solution(int[] topping)
    {
        _maxToppingCount = topping.Length;
        
        for (int idx = 0; idx < _maxToppingCount; idx++)
        {
            _leftHashSet.Add(topping[idx]);
            _dpLeft[idx + 1] = _leftHashSet.Count;
        }

        // todo : for idx
        for (int idx = _maxToppingCount - 1; idx >= 1; idx--)
        {
            _rightHashSet.Add(topping[idx]);
            _dpRight[idx + 1] = _rightHashSet.Count;
        }
        
        return CountSame();
    }

    private int CountSame()
    {
        int sameCount = 0;
        
        // todo : 마지막 idx 맞는지
        for (int idx = 1; idx < _maxToppingCount; idx++)
        {
            var left = _dpLeft[idx];
            var right = _dpRight[idx+1];

            if (left == right)
            {
                sameCount++;
            }
        }

        return sameCount;
    }
}