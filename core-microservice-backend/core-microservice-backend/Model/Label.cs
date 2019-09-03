using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_microservice_backend.Model
{
    public class Label
    {
        [BsonId]
        public int LabId { get; set; }
        [BsonElement("labelname")]
        public string LabelName { get; set; }

    }
}
