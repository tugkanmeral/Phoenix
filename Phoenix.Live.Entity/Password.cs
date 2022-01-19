using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Phoenix.LayerBases.Entity;

namespace Phoenix.Live.Entity
{
    public class Password : IEntity<int>, IDocument
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Description { get; set; }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
    }
}
