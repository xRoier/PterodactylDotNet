namespace PterodactylDotNet.Models.V10;

public class CreateNodeAllocationRequest {
    [JsonProperty("ip")]
    public string Ip { get; set; } = null!;

    [JsonProperty("ports")]
    public List<string> Ports { get; set; } = new();
}