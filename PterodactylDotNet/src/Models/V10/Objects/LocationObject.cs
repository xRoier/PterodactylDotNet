namespace PterodactylDotNet.Models.V10;

public class LocationObject {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("short")]
    public string Short { get; set; } = null!;

    [JsonProperty("long")]
    public string Long { get; set; } = null!;

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }
}