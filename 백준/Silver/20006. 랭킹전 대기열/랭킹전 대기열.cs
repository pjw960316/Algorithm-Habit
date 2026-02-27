using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharpHabit
{
    static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()
        var line = Console.ReadLine().Split();
        int playerCount = int.Parse(line[0]);
        int roomMax = int.Parse(line[1]);

        var roomList = new List<List<(int, string)>>();
        var roomLevelList = new List<int>();
        
        for (int i = 0; i < playerCount; i++)
        {
            line = Console.ReadLine().Split();
            
            int level = int.Parse(line[0]);
            string name = line[1];

            if (roomList.Count == 0)
            {
                var newList = new List<(int, string)>();
                newList.Add((level, name));
                
                roomList.Add(newList);
                roomLevelList.Add(level);
            }
            else
            {
                int roomCount = roomList.Count;
                bool shouldMakeNewRoom = true;
                
                for (var idx = 0; idx < roomCount; idx++)
                {
                    var roomInfoList = roomList[idx];
                    
                    if (roomInfoList.Count < roomMax && (roomLevelList[idx]-10 <= level && level <= roomLevelList[idx] + 10))
                    {
                        roomInfoList.Add((level, name));
                        shouldMakeNewRoom = false;
                        break;
                    }
                }

                if (shouldMakeNewRoom)
                {
                    var newList = new List<(int, string)>();
                    newList.Add((level, name));
                    
                    roomList.Add(newList);
                    roomLevelList.Add(level);
                }
            }
        }

        var len = roomList.Count;
        for (int idx = 0; idx < len; idx++)
        {
            var roomInfoList = roomList[idx];
            roomList[idx] = roomInfoList.OrderBy(pair => pair.Item2).ToList();
        }

        var sb = new StringBuilder();
        for (int idx = 0; idx < len; idx++)
        {
            var roomInfoList = roomList[idx];
            if (roomInfoList.Count == roomMax)
            {
                sb.AppendLine("Started!");
            }
            else
            {
                sb.AppendLine("Waiting!");
            }

            foreach (var i in roomInfoList)
            {
                sb.Append(i.Item1);
                sb.AppendLine(" " + i.Item2);
            }
        }

        Console.Write(sb.ToString());
    }
}