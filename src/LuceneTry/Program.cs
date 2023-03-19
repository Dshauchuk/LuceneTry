

using LuceneTry;
using LuceneTry.Data;

DataPopulationManager manager = new(new EntityRepository());

await manager.PopulateAsync(1_000_000);


Console.ReadKey();