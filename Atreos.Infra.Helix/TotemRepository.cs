using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atreos.Infra.Helix.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Atreos.Infra.Helix
{
  public class TotemRepository
  {
    private const string TotemCollection = "sth_/_urn:ngsi-ld:totem:070_iot";
    
    public async Task<List<Totem>> GetAllTotems()
    {
      var mongoConnection = new MongoDbConnection();
      var totemCollection = mongoConnection.Connect<Totem>(TotemCollection);
      
      // var dateFilter = DateTime.UtcNow.AddHours(-8);
      // var result = await totemCollection.FindAsync(x=> x.recvTime > dateFilter);
      
      var result = await totemCollection.FindAsync(_ => true);

      return result.ToList();
    }
  }
}