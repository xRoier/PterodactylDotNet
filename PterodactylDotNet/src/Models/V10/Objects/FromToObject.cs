namespace PterodactylDotNet.Models.V10;

public class FromToObject {
    [JsonProperty("from")]
    public string From { get; set; } = null!;
    
    [JsonProperty("to")]
    public string To { get; set; } = null!;
}