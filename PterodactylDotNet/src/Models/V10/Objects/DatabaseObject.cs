namespace PterodactylDotNet.Models.V10;

public class DatabaseObject {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("server")]
    public int Server { get; set; }

    [JsonProperty("host")]
    public int Host { get; set; }

    [JsonProperty("database")]
    public string Database { get; set; } = null!;

    [JsonProperty("username")]
    public string Username { get; set; } = null!;

    [JsonProperty("remote")]
    public string Remote { get; set; } = null!;

    [JsonProperty("max_connections")]
    public int MaxConnections { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }
}