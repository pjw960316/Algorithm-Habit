using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    private int _baseTime;
    private int _baseMoney;
    private int _overTime;
    private int _overMoney;
    private Dictionary<string, List<int>> _dict = new Dictionary<string, List<int>>();
    
    public int[] solution(int[] fees, string[] records) 
    {
        _baseTime = fees[0];
        _baseMoney = fees[1];
        _overTime = fees[2];
        _overMoney = fees[3];

        InitializeDict(records);
        
        return MeasureMoney().ToArray();
    }

    private void InitializeDict(string[] records)
    {
        foreach (var record in records)
        {
            var line = record.Split();
            
            var time = line[0];
            var carNum = line[1];
            var inOut = line[2];

            if (_dict.ContainsKey(carNum) == false)
            {
                _dict[carNum] = new List<int>();
            }
            
            var list = _dict[carNum];
            var intTime = ConvertTime(time);
            
            list.Add(intTime);
        }
    }

    private List<int> MeasureMoney()
    {
        int parkTime = 0;
        var retList = new List<int>();
        
        foreach (var pair in _dict.OrderBy(kv => kv.Key))
        {
            var list = pair.Value;
            var len = list.Count;
            parkTime = 0;

            if (len % 2 == 1)
            {
                list.Add(23 * 60 + 59);
            }

            for (int idx = 0; idx < len; idx += 2)
            {
                parkTime += list[idx + 1] - list[idx];
            }

            //1. 기본
            if (parkTime <= _baseTime)
            {
                retList.Add(_baseMoney);
                continue;
            }
            
            //2. 기본 초과
            if (parkTime > _baseTime)
            {
                var overTime = parkTime - _baseTime;
                double overCount = (double)overTime / (double)_overTime; //TODO : 나는 이해한 변수명
                var upOverCount = Math.Ceiling(overCount);

                retList.Add((int)(_baseMoney + upOverCount * _overMoney));
                continue;
            }
        }
        
        //test
        foreach (var i in retList)
        {
            Console.WriteLine(i);
        }

        return retList;
    }
    private void PrintDict()
    {
        foreach (var pair in _dict)
        {
            Console.Write($"{pair.Key} -> ");

            foreach (var i in pair.Value)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
        }
    }

    private int ConvertTime(string time)
    {
        var a = (time[0] - '0') * 10;
        var b = time[1] - '0';
        var c = (time[3] - '0') * 10;
        var d = (time[4] - '0');

        var hour = a + b;
        var minute = c + d;

        return hour * 60 + minute;
    }
}