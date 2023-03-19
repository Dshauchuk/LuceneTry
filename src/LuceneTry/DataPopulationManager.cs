using LuceneTry.Data;

namespace LuceneTry;

public class DataPopulationManager
{
	private readonly EntityRepository _entityRepository;

	public DataPopulationManager(EntityRepository entityRepository)
	{
		_entityRepository = entityRepository;
	}

	public async Task PopulateAsync(int count)
	{

	}
}
