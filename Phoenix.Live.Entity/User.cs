using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Phoenix.LayerBases.DataAccess.MongoDb;
using Phoenix.LayerBases.Entity;

namespace Phoenix.Live.Entity
{
    public class User : IEntity<int>, IDocument
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
    }
}
