namespace PterodactylDotNet.Models.V10;

public class NodeObject {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("uuid")]
    public Guid Uuid { get; set; }

    [JsonProperty("public")]
    public bool Public { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("description")]
    public string Description { get; set; } = null!;

    [JsonProperty("location_id")]
    public int LocationId { get; set; }

    [JsonProperty("fqdn")]
    public string FQDN { get; set; } = null!;

    [JsonProperty("scheme")]
    public string Scheme { get; set; } = null!;

    [JsonProperty("behind_proxy")]
    public bool BehindProxy { get; set; }

    [JsonProperty("maintenance_mode")]
    public bool MaintenanceMode { get; set; }

    [JsonProperty("memory")]
    public int Memory { get; set; }

    [JsonProperty("memory_overallocate")]
    public int MemoryOverallocate { get; set; }

    [JsonProperty("disk")]
    public int Disk { get; set; }

    [JsonProperty("disk_overallocate")]
    public int DiskOverallocate { get; set; }

    [JsonProperty("upload_size")]
    public int UploadSize { get; set; }

    [JsonProperty("daemon_listen")]
    public int DaemonListen { get; set; }

    [JsonProperty("daemon_sftp")]
    public int DaemonSftp { get; set; }

    [JsonProperty("daemon_base")]
    public string DaemonBase { get; set; } = null!;

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }
}