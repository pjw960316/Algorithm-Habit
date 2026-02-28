using System.Text;

public class CSharpHabit
{
    private static void Main()
    {
        // TODO : Console.ReadLine() 또는 Console.ReadLine().Split()

        var tcMax = int.Parse(Console.ReadLine());
        var dp = new int[42, 2];
        dp[0, 0] = 1;
        dp[0, 1] = 0;
        dp[1, 0] = 0;
        dp[1, 1] = 1;

        for (var i = 2; i <= 40; i++)
        {
            dp[i, 0] = dp[i - 1, 0] + dp[i - 2, 0];
            dp[i, 1] = dp[i - 1, 1] + dp[i - 2, 1];
        }

        var sb = new StringBuilder();
        for (var tc = 0; tc < tcMax; tc++)
        {
            var n = int.Parse(Console.ReadLine());

            sb.Append(dp[n, 0]);
            sb.Append(" ");
            sb.Append(dp[n, 1]);
            sb.AppendLine();
        }

        Console.Write(sb);
    }
}