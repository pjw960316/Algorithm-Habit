using System.Text;

public class CSharpHabit
{
    private static void Main()
    {
        var tcMax = int.Parse(Console.ReadLine());
        var sb = new StringBuilder();

        string str;
        int strLen;
        
        var list = new List<char>();
        var visit = new bool[22];
        var arr = new char[22]; //depth
        var dict = new Dictionary<int, HashSet<char>>();
        

        for (var tc = 0; tc < tcMax; tc++)
        {
            str = Console.ReadLine();
            strLen = str.Length;
            
            list.Clear();
            Array.Clear(visit);
            Array.Clear(arr);
            
            for (int i = 1; i <= 22; i++)
            {
                dict[i] = new HashSet<char>();
            }

            for (var idx = 0; idx < strLen; idx++)
            {
                list.Add(str[idx]);
            }

            list.Sort();

            DFS(1);
        }

        Console.Write(sb);

        void DFS(int depth)
        {
            if (depth == strLen + 1)
            {
                AppendSb(arr);
                return;
            }

            char prev = '\0';
            for (var idx = 0; idx < strLen; idx++)
            {
                if (visit[idx] == false && prev != list[idx])
                {
                    arr[depth] = list[idx];
                    prev = list[idx];
                    visit[idx] = true;
                    
                    DFS(depth + 1);

                    visit[idx] = false;
                }
            }
        }

        void AppendSb(char[] arr)
        {
            for (int idx = 1; idx <= strLen; idx++)
            {
                sb.Append(arr[idx]);
            }

            sb.AppendLine();
        }
    }
}