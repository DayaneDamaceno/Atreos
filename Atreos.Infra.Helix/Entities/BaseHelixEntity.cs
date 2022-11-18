using Newtonsoft.Json;

namespace Atreos.Infra.Helix.Entities
{
  public abstract class BaseHelixEntity<T> where T : class
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("type")]
    public abstract string Type { get; }

    public BaseHelixEntity(string id)
    {
      Id = id;
    }

    public BaseHelixEntity() { }
  }
}