namespace PterodactylDotNet.Models.V10;

public class FeatureLimitsObject {
    [JsonProperty("databases")]
    public int Databases { get; set; }

    [JsonProperty("allocations")]
    public int Allocations { get; set; }

    [JsonProperty("backups")]
    public int Backups { get; set; }
}