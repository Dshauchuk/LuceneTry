using LuceneTry.Models;

namespace LuceneTry.Data.Generator;

public class EntityGenerator
{
    public static Entity New()
    {
        return new Entity()
        {
            Id = Guid.NewGuid(),
            StringField1 = StringGenerator.RandomString(100),
            StringField2 = StringGenerator.RandomString(100),
            StringField3 = StringGenerator.RandomString(100),
            StringField4 = StringGenerator.RandomString(100),
            StringField5 = StringGenerator.RandomString(100),
            StringField6 = StringGenerator.RandomString(100),
            StringField7 = StringGenerator.RandomString(100),
            StringField8 = StringGenerator.RandomString(100),
            StringField9 = StringGenerator.RandomString(100),
            StringField10 = StringGenerator.RandomString(100),
            IntField1 = NumberGenerator.RandomInt(int.MinValue, int.MaxValue),
            IntField2 = NumberGenerator.RandomInt(int.MinValue, int.MaxValue),
            IntField3 = NumberGenerator.RandomInt(int.MinValue, int.MaxValue),
            IntField4 = NumberGenerator.RandomInt(int.MinValue, int.MaxValue),
            IntField5 = NumberGenerator.RandomInt(int.MinValue, int.MaxValue)
        };
    }

    public static IEnumerable<Entity> New(int count = 1)
    {
        if (count < 1)
            throw new ArgumentException($"Invalid value for {nameof(count)} parameter. It cannot be less than 1");

        List<Entity> entities = new(count);

        for (int i = 0; i < count; i++)
            entities.Add(New());

        return entities;
    }
}   
