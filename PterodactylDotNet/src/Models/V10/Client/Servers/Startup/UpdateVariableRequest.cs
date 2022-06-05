namespace PterodactylDotNet.Models.V10;

public class UpdateVariableRequest {
    [JsonProperty("key")]
    public string Key { get; set; } = null!;

    [JsonProperty("value")]
    public string Value { get; set; } = null!;
}