namespace PterodactylDotNet.Models.V10;

public class SignedUrlObject {
    [JsonProperty("url")]
    public string Url { get; set; } = null!;
}