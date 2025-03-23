using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ToDo.Domain.Entities
{
    public class ToDoEntity
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name"), BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [BsonElement("description"), BsonRepresentation(BsonType.String)]
        public string Description { get; set; }

        [BsonElement("deadline"), BsonRepresentation(BsonType.DateTime)]
        public DateTime DeadLine { get; set; }

        [BsonElement("Category"), BsonRepresentation(BsonType.String)]
        public string Category { get; set; }

        public bool IsOnOrPassedDeadLine()
        {
            if (DeadLine == DateTime.Now || DeadLine < DateTime.Now)
            {
                return true;
            }

            return false;
        }
    }
}
