namespace LuceneTry;

public static class CollectionExtensions
{
    public static IEnumerable<IEnumerable<T>> Slice<T>(this IEnumerable<T> collection, int sliceSize = 100)
    {
        List<IEnumerable<T>> slices = new();
        int count = collection.Count();

        if (count <= 100)
        {
            slices.Add(collection);
        }
        else
        {
            int position = 0;

            while (position < count)
            {
                slices.Add(collection.Skip(0).Take(sliceSize));
                position += sliceSize;
            }
        }

        return slices;
    }
}
