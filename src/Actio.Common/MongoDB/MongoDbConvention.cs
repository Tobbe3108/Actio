using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace Actio.Common.MongoDB
{
    public class MongoDbConvention : IConventionPack
    {
        public IEnumerable<IConvention> Conventions => new List<IConvention>
        {
            new IgnoreExtraElementsConvention(true),
            new EnumRepresentationConvention(BsonType.String),
            new CamelCaseElementNameConvention()
        };
    }
}