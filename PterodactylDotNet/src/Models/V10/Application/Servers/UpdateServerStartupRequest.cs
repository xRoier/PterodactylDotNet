namespace PterodactylDotNet.Models.V10;

public class UpdateServerStartupRequest {
    [JsonProperty("startup")]
    public string Startup { get; set; } = null!;

    [JsonProperty("environment")]
    public Dictionary<string, string> Environment { get; set; } = new();

    [JsonProperty("egg")]
    public int Egg { get; set; }

    [JsonProperty("image")]
    public string Image { get; set; } = null!;

    [JsonProperty("skip_scripts")]
    public bool SkipScripts { get; set; }
}