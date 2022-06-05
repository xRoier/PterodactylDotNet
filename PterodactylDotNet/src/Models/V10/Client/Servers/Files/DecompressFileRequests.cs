namespace PterodactylDotNet.Models.V10;

public class DecompressFileRequest {
    [JsonProperty("root")]
    public string Directory { get; set; } = null!;

    [JsonProperty("file")]
    public string File { get; set; } = null!;
}