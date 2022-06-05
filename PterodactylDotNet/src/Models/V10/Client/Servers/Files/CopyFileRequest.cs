namespace PterodactylDotNet.Models.V10;

public class CopyFileRequest {
    [JsonProperty("location")]
    public string Location { get; set; } = null!;
}