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
        var king = (line[0][0] - 'A' + 1 , line[0][1] - '0');
        var rock = (line[1][0] - 'A' + 1 , line[1][1] - '0');
        int n = int.Parse(line[2]);

        for (int i = 0; i < n; i++)
        {
            string str = Console.ReadLine();

            if (str == "R")
            {
                Move(1, 0, ref king, ref rock);
            }
            else if (str == "L")
            {
                Move(-1, 0, ref king, ref rock);
            }
            else if (str == "B")
            {
                Move(0,-1, ref king, ref rock);
            }
            else if (str == "T")
            {
                Move(0,1, ref king, ref rock);
            }
            else if (str == "RT")
            {
                Move(1,1, ref king, ref rock);
            }
            else if (str == "LT")
            {
                Move(-1,1, ref king, ref rock);
            }
            else if (str == "RB")
            {
                Move(1,-1, ref king, ref rock);
            }
            else if (str == "LB")
            {
                Move(-1,-1, ref king, ref rock);
            }
        }

        var kingWord = (char)('A' - 1 + king.Item1); 
        var rockWord = (char)('A' - 1 + rock.Item1); 
        Console.WriteLine($"{kingWord}{king.Item2}");
        Console.WriteLine($"{rockWord}{rock.Item2}");
    }

    public static void Move(int a, int b, ref (int,int) king , ref (int,int) rock)
    {
        if (king.Item1 + a == 0 || king.Item1 + a == 9)
        {
            return;
        }
        if (king.Item2 + b == 0 || king.Item2 + b == 9)
        {
            return;
        }

        if (king.Item1 + a == rock.Item1 && king.Item2 + b == rock.Item2)
        {
            if (rock.Item1 + a == 0 || rock.Item1 + a == 9)
            {
                return;
            }
            if (rock.Item2 + b == 0 || rock.Item2 + b == 9)
            {
                return;
            }
        }
        
        king = (king.Item1 + a, king.Item2 + b);
                
        if (king.Item1 == rock.Item1 && king.Item2 == rock.Item2)
        {
            rock = (rock.Item1 + a, rock.Item2 + b);
        }
    }
}