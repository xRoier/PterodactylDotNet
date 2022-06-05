namespace PterodactylDotNet.Models.V10;

public class CreateServerRequest {
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("user")]
    public int User { get; set; }

    [JsonProperty("egg")]
    public int Egg { get; set; }

    [JsonProperty("docker_image")]
    public string DockerImage { get; set; } = null!;

    [JsonProperty("startup")]
    public string Startup { get; set; } = null!;

    [JsonProperty("environment")]
    public Dictionary<string, string> Environment { get; set; } = new();

    [JsonProperty("limits")]
    public RequestLimits Limits { get; set; } = new();

    [JsonProperty("feature_limits")]
    public RequestFeatureLimits FeatureLimits { get; set; } = new();

    //TODO: Find out how this works as there appears to be functionality not shown in the API docs
    [JsonProperty("allocation")]
    public RequestAllocation Allocation { get; set; } = new();

    public class RequestLimits {
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
    }

    public class RequestFeatureLimits  {
        [JsonProperty("databases")]
        public int Databases { get; set; }

        [JsonProperty("backups")]
        public int Backups { get; set; }
    }

    public class RequestAllocation {
        [JsonProperty("default")]
        public int Default { get; set; }
    }
}