## :fire: 프로그래머스 사이트의 단점 및 해결방식
#### :one: 단점
- 프로그래머스의 컴파일러는 C# 6.0이다.
  - local function 사용 불가
- 프로그래머스 사이트에서 코딩하는 방식은 불편하다.

<br>

#### :two: 해결방식
- Rider에서 Code Template을 만들어 놓는다.
- Rider에서 테스트를 완료한다.
- GPT를 이용해서 Rider의 코드를 Programmers 형식 (c# 6.0)으로 변환시켜서 제출한다.

<br><br>

## :fire: 코드 템플릿
#### :one: Main
~~~c#
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var sol = new Solution();

        // TODO : Static Input Class의 메서드를 활용해서 Input 받으세요.

        // TODO : solution 메서드에 인자를 넣으세요.
        Console.Write(sol.solution());
    }
}
~~~

<br>

#### :two: static Input
~~~c#
public static class Input
{
    public static int ReadInt()
    {
        return int.Parse(Console.ReadLine());
    }

    public static int[] ReadInts()
    {
        var input = Console.ReadLine();
        if (input == null)
            return Array.Empty<int>();

        // [ ] 제거
        input = input.Trim('[', ']');

        return input
            .Split(',')
            .Select(x => int.Parse(x.Trim()))
            .ToArray();
    }

    public static string ReadString()
    {
        return Console.ReadLine();
    }

    public static string[] ReadStrings()
    {
        var input = Console.ReadLine();
        if (input == null)
        {
            return Array.Empty<string>();
        }

        input = input.Trim('[', ']');

        return input
            .Split(',')
            .Select(x => x.Trim().Trim('"'))
            .ToArray();
    }

    public static int[,] ReadIntMatrix()
    {
        var input = Console.ReadLine();
        if (input == null)
        {
            return new int[1, 1];
        }

        // 외곽 괄호 제거
        input = input.Substring(2, input.Length - 4); 

        var line = input.Split(["], ["], StringSplitOptions.None);

        var rowMax = line.Length;
        var colMax = line[0].Split(',').Length;
        var arr = new int[rowMax, colMax];

        for (int r = 0; r < rowMax; r++)
        {
            var cols = line[r].Split(',');

            for (int c = 0; c < colMax; c++)
            {
                arr[r,c] = int.Parse(cols[c]);
            }
        }

        return arr;
    }
}
~~~
