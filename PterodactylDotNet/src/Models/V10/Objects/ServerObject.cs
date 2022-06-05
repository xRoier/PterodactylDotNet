namespace PterodactylDotNet.Models.V10;

public class ServerObjectApplication {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("external_id")]
    public object ExternalId { get; set; } = null!;

    [JsonProperty("uuid")]
    public Guid Uuid { get; set; }

    [JsonProperty("identifier")]
    public string Identifier { get; set; } = null!;

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("description")]
    public string Description { get; set; } = null!;

    //TODO: Work out what this is meant to be.
    [JsonProperty("status")]
    public object Status { get; set; } = null!;

    [JsonProperty("suspended")]
    public bool Suspended { get; set; }

    [JsonProperty("limits")]
    public LimitsObject Limits { get; set; } = null!;

    [JsonProperty("feature_limits")]
    public FeatureLimitsObject FeatureLimits { get; set; } = null!;

    [JsonProperty("user")]
    public int User { get; set; }

    [JsonProperty("node")]
    public int Node { get; set; }

    [JsonProperty("allocation")]
    public int Allocation { get; set; }

    [JsonProperty("nest")]
    public int Nest { get; set; }

    [JsonProperty("egg")]
    public int Egg { get; set; }

    [JsonProperty("container")]
    public ServerContainer Container { get; set; } = null!;

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    public class ServerContainer {
        [JsonProperty("startup_command")]
        public string StartupCommand { get; set; } = null!;

        [JsonProperty("image")]
        public string Image { get; set; } = null!;

        [JsonProperty("installed")]
        public int Installed { get; set; }

        [JsonProperty("environment")]
        public Dictionary<string, string> Environment { get; set; } = null!;
    }
}

public class ServerObjectClient {
    [JsonProperty("server_owner")]
    public bool ServerOwner { get; set; }

    [JsonProperty("identifier")]
    public string Identifier { get; set; } = null!;

    [JsonProperty("internal_id")]
    public int InternalId { get; set; }

    [JsonProperty("uuid")]
    public Guid Uuid { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("node")]
    public string Node { get; set; } = null!;

    [JsonProperty("sftp_details")]
    public SftpDetailsObject SftpDetails { get; set; } = null!;

    [JsonProperty("description")]
    public string Description { get; set; } = null!;

    [JsonProperty("limits")]
    public LimitsObject Limits { get; set; } = null!;

    [JsonProperty("invocation")]
    public string Invocation { get; set; } = null!;

    [JsonProperty("docker_image")]
    public string DockerImage { get; set; } = null!;

    [JsonProperty("egg_features")]
    public List<string> EggFeatures { get; set; } = null!;

    [JsonProperty("feature_limits")]
    public FeatureLimitsObject FeatureLimits { get; set; } = null!;

    [JsonProperty("status")]
    public object Status { get; set; } = null!;

    [JsonProperty("is_suspended")]
    public bool IsSuspended { get; set; }

    [JsonProperty("is_installing")]
    public bool IsInstalling { get; set; }

    [JsonProperty("is_transferring")]
    public bool IsTransferring { get; set; }

    [JsonProperty("relationships")]
    public ServerRelationships Relationships { get; set; } = null!;

    public class ServerRelationships {
        [JsonProperty("allocations")]
        public ApiDataListAttributes<AllocationObjectClient> Allocations { get; set; } = null!;

        [JsonProperty("variables")]
        public ApiDataListAttributes<VariableObject> Variables { get; set; } = null!;
    }
}

// Below is a merged varient combining both ServerObjectApplication and ServerObjectClient
// public class ServerObject {
//     [JsonProperty("id")]
//     public int Id { get; set; }

//     [JsonProperty("external_id")]
//     public object ExternalId { get; set; } = null!;

//     [JsonProperty("uuid")]
//     public Guid Uuid { get; set; }

//     [JsonProperty("identifier")]
//     public string Identifier { get; set; } = null!;

//     [JsonProperty("name")]
//     public string Name { get; set; } = null!;

//     [JsonProperty("description")]
//     public string Description { get; set; } = null!;

//     [JsonProperty("status")]
//     public object Status { get; set; } = null!;

//     [JsonProperty("suspended")]
//     public bool Suspended { get; set; }

//     [JsonProperty("user")]
//     public int User { get; set; }

//     [JsonProperty("node")]
//     public string Node { get; set; } = null!;

//     [JsonProperty("allocation")]
//     public int Allocation { get; set; }

//     [JsonProperty("nest")]
//     public int Nest { get; set; }

//     [JsonProperty("egg")]
//     public int Egg { get; set; }

//     [JsonProperty("updated_at")]
//     public DateTime UpdatedAt { get; set; }

//     [JsonProperty("created_at")]
//     public DateTime CreatedAt { get; set; }

//     [JsonProperty("server_owner")]
//     public bool ServerOwner { get; set; }

//     [JsonProperty("internal_id")]
//     public int InternalId { get; set; }

//     [JsonProperty("invocation")]
//     public string Invocation { get; set; } = null!;

//     [JsonProperty("docker_image")]
//     public string DockerImage { get; set; } = null!;

//     [JsonProperty("is_suspended")]
//     public bool IsSuspended { get; set; }

//     [JsonProperty("is_installing")]
//     public bool IsInstalling { get; set; }

//     [JsonProperty("is_transferring")]
//     public bool IsTransferring { get; set; }

//     [JsonProperty("limits")]
//     public ServerLimits? Limits { get; set; }

//     [JsonProperty("feature_limits")]
//     public ServerFeatureLimits? FeatureLimits { get; set; }

//     [JsonProperty("container")]
//     public ServerContainer? Container { get; set; }

//     [JsonProperty("sftp_details")]
//     public ServerSftpDetails? SftpDetails { get; set; }

//     [JsonProperty("egg_features")]
//     public List<string>? EggFeatures { get; set; } = null!;

//     [JsonProperty("relationships")]
//     public ServerRelationships? Relationships { get; set; }

//     public class ServerLimits {
//         [JsonProperty("memory")]
//         public int Memory { get; set; }

//         [JsonProperty("swap")]
//         public int Swap { get; set; }

//         [JsonProperty("disk")]
//         public int Disk { get; set; }

//         [JsonProperty("io")]
//         public int Io { get; set; }

//         [JsonProperty("cpu")]
//         public int Cpu { get; set; }

//         [JsonProperty("threads")]
//         public string Threads { get; set; } = null!;

//         [JsonProperty("oom_disabled")]
//         public bool OomDisabled { get; set; }
//     }

//     public class ServerFeatureLimits {
//         [JsonProperty("databases")]
//         public int Databases { get; set; }

//         [JsonProperty("allocations")]
//         public int Allocations { get; set; }

//         [JsonProperty("backups")]
//         public int Backups { get; set; }
//     }

//     public class ServerContainer {
//         [JsonProperty("startup_command")]
//         public string StartupCommand { get; set; } = null!;

//         [JsonProperty("image")]
//         public string Image { get; set; } = null!;

//         [JsonProperty("installed")]
//         public int Installed { get; set; }

//         [JsonProperty("environment")]
//         public Dictionary<string, string> Environment { get; set; } = null!;
//     }

//     public class ServerSftpDetails {
//         [JsonProperty("ip")]
//         public string Ip { get; set; } = null!;

//         [JsonProperty("port")]
//         public int Port { get; set; }
//     }

//     public class ServerRelationships {
//         [JsonProperty("allocations")]
//         public ApiDataListAttributes<AllocationObject> Allocations { get; set; } = null!;

//         [JsonProperty("variables")]
//         public ApiDataListAttributes<VariableObject> Variables { get; set; } = null!;
//     }
// }