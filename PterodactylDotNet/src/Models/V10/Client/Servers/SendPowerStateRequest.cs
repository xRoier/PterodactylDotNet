namespace PterodactylDotNet.Models.V10;

public class SendPowerStateRequest {
    [JsonProperty("signal")]
    public string Signal { get; set; } = null!;
}