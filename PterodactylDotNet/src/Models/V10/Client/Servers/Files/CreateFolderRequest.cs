namespace PterodactylDotNet.Models.V10;

public class CreateFolderRequest {
    [JsonProperty("root")]
    public string Directory { get; set; } = null!;

    [JsonProperty("name")]
    public string Name { get; set; } = null!;
}