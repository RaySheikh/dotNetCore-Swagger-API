using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Data.Models
{
    public partial class Quote
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public Catagory Catagory { get; set; }
        public Quote()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }
    }

    public partial class Catagory
    {
        public string Name { get; set; }
    }

}
