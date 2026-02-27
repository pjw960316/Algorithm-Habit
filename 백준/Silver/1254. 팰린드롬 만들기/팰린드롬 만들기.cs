using System.Text;

public class CSharpHabit
{
    private static void Main(string[] args)
    {
        var str = Console.ReadLine(); 
        string newStr = "";
        int len = str.Length;
              
        for(int i=0; i<len; i++)
        {
            newStr = str.Substring(i,len-i);
            if(IsPal(newStr))
            {
                Console.WriteLine($"{len + i}");
                return;
            }         
        }        
    }
    
    public static bool IsPal(string str)
    {
        StringBuilder sb = new StringBuilder();
              
        for(int i=str.Length-1; i>=0; i--)
        {
            sb.Append(str[i]);
        }
        if(sb.ToString() == str)
        {
            return true;
        }
        return false;
    }
}