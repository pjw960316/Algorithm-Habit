using System;
using System.Linq;
using System.Collections.Generic;

public class Solution 
{
    public string[] solution(string[] players, string[] callings) 
    {
        string[] answer = new string[] {};
        
        var rankDict = new Dictionary<string,int>();
        int rank = 0;
        
        foreach(var player in players)
        {
            rankDict[player] = rank;
            rank++;
        }
        
        foreach(var calling in callings)
        {
            var frontPlayer = players[rankDict[calling]-1];
            rankDict[frontPlayer] += 1;
            rankDict[calling] -= 1;
            
            players[rankDict[calling]] = calling;
            players[rankDict[frontPlayer]] = frontPlayer;
        }
        
        return players;
    }
}