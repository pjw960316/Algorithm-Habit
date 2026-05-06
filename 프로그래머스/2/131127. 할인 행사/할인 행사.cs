using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    private Dictionary<string, int> _dict = new Dictionary<string, int>();
    private string[] _wantArr;
    private int[] _numberArr;
    private string[] _discountArr;
    
    public int solution(string[] want, int[] number, string[] discount)
    {
        var answer = 0;

        _wantArr = want;
        _numberArr = number;
        _discountArr = discount;

        // todo : 순회 endPoint
        var endIdx = discount.Length - 10;
        for (int idx = 0; idx <= endIdx; idx++)
        {
            ClearOriginDict();
            
            if (IsGoMarket(idx))
            {
                answer++;
            }
        }
        
        return answer;
    }

    private bool IsGoMarket(int startIdx)
    {
        var endIdx = startIdx + 10;
        
        for (int idx = startIdx; idx < endIdx; idx++)
        {
            var targetItem = _discountArr[idx];
            if (_dict.ContainsKey(targetItem))
            {
                _dict[targetItem] -= 1;
                if (_dict[targetItem] == 0)
                {
                    _dict.Remove(targetItem);
                }
            }
            else
            {
                return false;
            }
        }

        //Console.WriteLine($"{startIdx}");
        return true;
    }
    
    private void ClearOriginDict()
    {
        _dict.Clear();

        int len = _wantArr.Length;
        for (int idx = 0; idx < len; idx++)
        {
            var str = _wantArr[idx];
            var count = _numberArr[idx];
            
            _dict[str] = count;
        }
    }
}