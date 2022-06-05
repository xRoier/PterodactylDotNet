namespace PterodactylDotNet.Models.V10;

public class SendCommandRequest {
    [JsonProperty("command")]
    public string Command { get; set; } = null!;
}