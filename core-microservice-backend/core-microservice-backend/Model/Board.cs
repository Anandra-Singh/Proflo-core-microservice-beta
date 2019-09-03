using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_microservice_backend.Model
{
    public class Board
    {
        [BsonId]
        public int BId { get; set; }
        [BsonElement("boardname")]
        public string BoardName { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        public List<Member> Members { get; set; }
        public List<Invite> Invites { get; set; }
        public List<List> Lists { get; set; }
    }
}
