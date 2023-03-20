using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using LuceneTry.Models;

namespace LuceneTry;

internal class IndexManager
{
    const LuceneVersion AppLuceneVersion = LuceneVersion.LUCENE_48;
    private readonly IndexWriter _indexWriter;
    private readonly FSDirectory _directory;

    public IndexManager()
	{
        // Construct a machine-independent path for the index
        var basePath = Environment.GetFolderPath(
            Environment.SpecialFolder.CommonApplicationData);
        var indexPath = Path.Combine(basePath, "index");

        _directory = FSDirectory.Open(indexPath);

        // Create an analyzer to process the text
        var analyzer = new StandardAnalyzer(AppLuceneVersion);

        // Create an index writer
        var indexConfig = new IndexWriterConfig(AppLuceneVersion, analyzer);
        _indexWriter = new IndexWriter(_directory, indexConfig);
    }

    public void IndexData(IEnumerable<Entity> entities)
    {
        List<Document> documents = entities
            .Select(e => new Document
            {
                new StringField("Id",
                    e.Id.ToString(),
                    Field.Store.YES),
                new StringField("StringField1",
                    e.StringField1,
                    Field.Store.YES),
                new StringField("StringField2",
                    e.StringField2,
                    Field.Store.YES),
                new StringField("StringField3",
                    e.StringField3,
                    Field.Store.YES),
                new StringField("StringField4",
                    e.StringField4,
                    Field.Store.YES),
                new StringField("StringField5",
                    e.StringField5,
                    Field.Store.YES),
                new StringField("StringField6",
                    e.StringField6,
                    Field.Store.YES),
                new StringField("StringField7",
                    e.StringField7,
                    Field.Store.YES),
                new StringField("StringField8",
                    e.StringField8,
                    Field.Store.YES),
                new StringField("StringField9",
                    e.StringField9,
                    Field.Store.YES),
                new StringField("StringField10",
                    e.StringField10,
                    Field.Store.YES),
                new Int32Field("IntField1",
                    e.IntField1,
                    Field.Store.YES),
                new Int32Field("IntField2",
                    e.IntField2,
                    Field.Store.YES),
                new Int32Field("IntField3",
                    e.IntField3,
                    Field.Store.YES),
                new Int32Field("IntField4",
                    e.IntField4,
                    Field.Store.YES),
                new Int32Field("IntField5",
                    e.IntField5,
                    Field.Store.YES)
            })
            .ToList();

        int indexed = 0;
        var groups = documents.Slice(1_000);

        foreach(var group in groups)
        {
            _indexWriter.AddDocuments(group);
            _indexWriter.Flush(triggerMerge: false, applyAllDeletes: false);

            indexed += group.Count();

            Console.WriteLine($"{indexed}/{documents.Count} items were indexed.");
        }

        _indexWriter.Commit();
    }

    public IndexSearcher CreateSearcher()
        => new (_indexWriter.GetReader(applyAllDeletes: true));
}
