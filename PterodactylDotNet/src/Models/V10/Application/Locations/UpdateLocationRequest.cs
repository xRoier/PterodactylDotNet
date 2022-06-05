namespace PterodactylDotNet.Models.V10;

public class UpdateLocationRequest {
    [JsonProperty("short")]
    public string Short { get; set; } = null!;

    [JsonProperty("long")]
    public string Long { get; set; } = null!;
}