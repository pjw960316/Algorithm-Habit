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

// TODO : Programmer에서 Solution Class 복사하세요. 

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
        return Console.ReadLine().Split().Select(int.Parse).ToArray();
    }

    public static string ReadString()
    {
        return Console.ReadLine();
    }

    public static string[] ReadStrings()
    {
        return Console.ReadLine().Split();
    }

    public static int[,] ReadMatrix(int n, int m)
    {
        var arr = new int[n, m];
        for (var i = 0; i < n; i++)
        {
            var row = ReadInts();
            for (var j = 0; j < m; j++)
                arr[i, j] = row[j];
        }

        return arr;
    }
}
~~~