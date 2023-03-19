namespace LuceneTry.Data.Generator;

public class NumberGenerator
{
    private static readonly Random _random = new();

    public static int RandomInt(int from, int to)
    {
        return _random.Next(from, to);
    }
}
