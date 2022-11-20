using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Atreos.Infra.Helix.Models
{
  public class Totem
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public DateTime recvTime { get; set; } 
    public string attrName { get; set; } 
    public string attrType { get; set; } 
    public string attrValue { get; set; }
    
    // _id 
    // recvTime 2022-11-17T17:00:53.510+00:00
    // attrName "cartao"
    // attrType "string"
    // attrValue "BD 9B 06 7D"
  }
}