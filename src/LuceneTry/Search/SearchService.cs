using Lucene.Net.Index;
using Lucene.Net.Search;
using LuceneTry.Data;
using LuceneTry.Models;
using System.Diagnostics;

namespace LuceneTry.Search;

internal class DbSearchService
{
    public async Task<SearchResult<Entity>> SearchAsync(string query)
    {
        Stopwatch sw = Stopwatch.StartNew();

        EntityRepository repo = new();
        IEnumerable<Entity> entities = await repo.GetAsync(query);


        return new SearchResult<Entity>(sw.Elapsed.TotalMilliseconds, entities, query);
    }
}

internal class LuceneSearchService
{
    private readonly IndexSearcher _indexSearcher;

    public LuceneSearchService(IndexSearcher indexSearcher)
    {
        _indexSearcher = indexSearcher;
    }

    public async Task<SearchResult<Entity>> SearchAsync(string query)
    {
        Stopwatch sw = Stopwatch.StartNew();

        TopDocs docs = _indexSearcher.Search(new WildcardQuery(new Term("StringField1", $"{query}*")), null, int.MaxValue);

        List<Entity> entities = new(docs.TotalHits);
        foreach(var doc in docs.ScoreDocs)
        {
            var e = _indexSearcher.Doc(doc.Doc);
            entities.Add(new Entity()
            {
                Id = Guid.Parse(e.Get("Id").ToString()),
                StringField1 = e.Get("StringField1"),
                StringField2 = e.Get("StringField2"),
                StringField3 = e.Get("StringField3"),
                StringField4 = e.Get("StringField4"),
                StringField5 = e.Get("StringField5"),
                StringField6 = e.Get("StringField6"),
                StringField7 = e.Get("StringField7"),
                StringField8 = e.Get("StringField8"),
                StringField9 = e.Get("StringField9"),
                StringField10 = e.Get("StringField10"),
                IntField1 = int.Parse(e.Get("IntField1")),
                IntField2 = int.Parse(e.Get("IntField2")),
                IntField3 = int.Parse(e.Get("IntField3")),
                IntField4 = int.Parse(e.Get("IntField4")),
                IntField5 = int.Parse(e.Get("IntField5"))
            });
        }

        return await Task.FromResult(new SearchResult<Entity>(sw.Elapsed.TotalMilliseconds, entities, query));
    }
}
