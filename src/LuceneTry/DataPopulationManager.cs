using LuceneTry.Data;
using LuceneTry.Data.Generator;
using LuceneTry.Models;

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

			while(position < count)
			{
				slices.Add(collection.Skip(0).Take(sliceSize));
				position += sliceSize;
			}
		}

		return slices;
    }
}

public class DataPopulationManager
{
	private readonly EntityRepository _entityRepository;

	public DataPopulationManager(EntityRepository entityRepository)
	{
		_entityRepository = entityRepository;
	}

	public async Task PopulateAsync(int count)
	{
		try
		{
			Console.WriteLine($"Generating {count} items...");

            List<Entity> items = EntityGenerator.New(count).ToList();
            IEnumerable<IEnumerable<Entity>> groups = items.Slice(100);

            Console.WriteLine("Generating completed.");
            Console.WriteLine("Populating...");

			int addedCount = 0;

            foreach (var group in groups)
			{
				await _entityRepository.AddAsync(group);
				addedCount += group.Count();

                Console.WriteLine($"{addedCount}/{count} were added.");
			}

			Console.WriteLine("Population completed");
        }
		catch(Exception ex)
		{
			Console.WriteLine(ex);
		}
	}

	public Task DeleteAll()
		=> _entityRepository.DeleteAsync();
}
