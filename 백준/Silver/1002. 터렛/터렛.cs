using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
public class CSharpHabit
{
    static void Main()
    {
        int tcMax = int.Parse(Console.ReadLine());
        var sb = new StringBuilder();

        int x1, x2, y1, y2, r1, r2;
        double dis;
        
        for (int tc = 0; tc < tcMax; tc++)
        {
            var line = Console.ReadLine().Split();
            
            x1 = int.Parse(line[0]);
            y1 = int.Parse(line[1]);
            
            x2 = int.Parse(line[3]);
            y2 = int.Parse(line[4]);
            
            r1 = int.Parse(line[2]);
            r2 = int.Parse(line[5]);

            dis = MeasureDistance(x1, y1, x2, y2);

            sb.Append(MeasureCircle());
            sb.AppendLine();
        }

        Console.Write(sb);
        return;
        
        double MeasureDistance(int x1, int y1, int x2, int y2)
        {
            var disX = Math.Abs(x2 - x1);
            var disY = (double)Math.Abs(y2 - y1);

            return Math.Sqrt((double)(disX * disX) + (double)(disY * disY));
        }

        int MeasureCircle()
        {
            if (x1 == x2 && y1 == y2 && r1 == r2)
            {
                return -1;
            }

            if (dis > r1 + r2)
            {
                return 0;
            }

            if (dis == r1 + r2)
            {
                return 1;
            }

            if (dis < Math.Abs(r1 - r2))
            {
                return 0;
            }

            if (dis == Math.Abs(r1 - r2))
            {
                return 1;
            }
            return 2;
        }
    }
}