namespace LuceneTry.Data.Generator;

public class StringGenerator
{
    private static readonly Random _random = new ();

    public static string RandomString(int length)
    {
        if (length < 1)
            throw new ArgumentException("String length cannot be less than 1");

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
    }
}