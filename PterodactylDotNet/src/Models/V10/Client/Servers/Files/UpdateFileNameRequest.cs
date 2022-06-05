namespace PterodactylDotNet.Models.V10;

public class UpdateFileNameRequest {
    [JsonProperty("root")]
    public string Directory { get; set; } = null!;

    [JsonProperty("files")]
    public List<FromToObject> Files = new();
}