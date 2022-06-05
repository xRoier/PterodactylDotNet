namespace PterodactylDotNet.Models.V10;

public class UpdateServerBuildRequest {
    [JsonProperty("allocation")]
    public int Allocation { get; set; }

    [JsonProperty("memory")]
    public int Memory { get; set; }

    [JsonProperty("swap")]
    public int Swap { get; set; }

    [JsonProperty("disk")]
    public int Disk { get; set; }

    [JsonProperty("io")]
    public int Io { get; set; }

    [JsonProperty("cpu")]
    public int Cpu { get; set; }

    [JsonProperty("threads")]
    public string Threads { get; set; } = null!;

    [JsonProperty("feature_limits")]
    public FeatureLimitsObject FeatureLimits { get; set; } = null!;
}