using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Todo
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
}

public enum Status
{
    Todo,
    Doing,
    Done,
}