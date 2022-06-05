namespace PterodactylDotNet.Models.V10;

public class UpdateServerDetailsRequest {
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("user")]
    public int User { get; set; }

    [JsonProperty("external_id")]
    public string ExternalId { get; set; } = null!;

    [JsonProperty("description")]
    public string Description { get; set; } = null!;
}