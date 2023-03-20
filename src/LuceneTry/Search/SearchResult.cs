namespace LuceneTry.Search;

internal class SearchResult<T>
{
    public SearchResult(double duration, IEnumerable<T> results, string query)
    {
        DurationMilliseconds = duration;
        Results = results ?? new List<T>();
        Query = query;
    }

    public double DurationMilliseconds { get; }
    public IEnumerable<T> Results { get; }
    public bool HasItems => Results.Any();
    public string Query { get; }

    public override string ToString()
    {
        return $"{Results.Count()} items found in {DurationMilliseconds} msec for \"{Query}\" query";
    }
}
