namespace PterodactylDotNet.Models.V10;

public class DeleteFileRequest {
    [JsonProperty("root")]
    public string Directory { get; set; } = null!;

    [JsonProperty("files")]
    public List<string> Files { get; set; } = new();
}