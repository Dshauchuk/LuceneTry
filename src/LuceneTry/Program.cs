using LuceneTry;
using LuceneTry.Data;
using LuceneTry.Data.Generator;
using LuceneTry.Search;

// data populating
EntityRepository repository = new();
DataPopulationManager dataManager = new(repository);
await dataManager.PopulateAsync(1_000_000);

// indexing
//Console.WriteLine("Indexing...");
IndexManager indexManager = new();
var items = await repository.GetAsync(string.Empty);
indexManager.IndexData(items);
Console.WriteLine($"{items.Count()} items indexed.");

// searching
Console.WriteLine("Searching...");
string queryPhase = Console.ReadLine();
var foundInDb = await new DbSearchService().SearchAsync(queryPhase);
var foundInLucene = await new LuceneSearchService(indexManager.CreateSearcher()).SearchAsync(queryPhase);

Console.WriteLine(foundInDb);
Console.WriteLine(foundInLucene);

Console.ReadKey();