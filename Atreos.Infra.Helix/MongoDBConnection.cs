using MongoDB.Driver;

namespace Atreos.Infra.Helix
{
  public class MongoDbConnection
  {
    private const string ConnectionString = "mongodb://helix:H3l1xNG@20.55.24.230:27000/?authMechanism=SCRAM-SHA-1";
    private const string DatabaseName = "sth_helixiot";
    
    public IMongoCollection<T> Connect<T>(in string collection)
    {
      var client = new MongoClient(ConnectionString);
      var db = client.GetDatabase(DatabaseName);
      return db.GetCollection<T>(collection);
    }
  }
}