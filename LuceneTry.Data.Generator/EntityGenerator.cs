using LuceneTry.Models;

namespace LuceneTry.Data.Generator;

public class EntityGenerator
{
    public static Entity New()
    {
        return new Entity()
        {
            Id = Guid.NewGuid(),
            StringField1 = StringGenerator.RandomString(200),
            StringField2 = StringGenerator.RandomString(200),
            StringField3 = StringGenerator.RandomString(200),
            StringField4 = StringGenerator.RandomString(200),
            StringField5 = StringGenerator.RandomString(200),
            StringField6 = StringGenerator.RandomString(200),
            StringField7 = StringGenerator.RandomString(200),
            StringField8 = StringGenerator.RandomString(200),
            StringField9 = StringGenerator.RandomString(200),
            StringField10 = StringGenerator.RandomString(200),
            IntField1 = NumberGenerator.RandomInt(int.MinValue, int.MaxValue),
            IntField2 = NumberGenerator.RandomInt(int.MinValue, int.MaxValue),
            IntField3 = NumberGenerator.RandomInt(int.MinValue, int.MaxValue),
            IntField4 = NumberGenerator.RandomInt(int.MinValue, int.MaxValue),
            IntField5 = NumberGenerator.RandomInt(int.MinValue, int.MaxValue)
        };
    }
}
