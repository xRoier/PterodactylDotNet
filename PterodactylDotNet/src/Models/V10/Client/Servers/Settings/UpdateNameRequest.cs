namespace PterodactylDotNet.Models.V10;

public class UpdateNameRequest {
    [JsonProperty("name")]
    public string Name { get; set; } = null!;
}