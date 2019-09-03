using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_microservice_backend.Model
{
    public class Comment
    {
        [BsonId]
        public int Id { get; set; }
        [BsonElement("text")]
        public string Text { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}
