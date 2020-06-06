using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Data.Models
{
    public partial class Quote
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public Catagory Catagory { get; set; }
        public Quote()
        {
            Id = ObjectId.GenerateNewId();
        }
    }

    public partial class Catagory
    {
        public string Name { get; set; }
    }

}
