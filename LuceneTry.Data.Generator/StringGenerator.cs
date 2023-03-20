using System.Text;

namespace LuceneTry.Data.Generator;

public class StringGenerator
{
    private static readonly Random _random = new ();
    
    public static string RandomString(int length)
    {
        StringBuilder sb = new (length);
        for (int i = 0; i < length; i++)
        {
            int x = _random.Next(65, 122);
            sb.Append((char)x);
        }

        return sb.ToString();
    }
}