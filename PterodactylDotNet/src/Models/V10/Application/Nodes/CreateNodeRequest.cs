namespace PterodactylDotNet.Models.V10;

public class CreateNodeRequest {
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("location_id")]
    public int LocationId { get; set; }

    [JsonProperty("fqdn")]
    public string Fqdn { get; set; } = null!;

    [JsonProperty("scheme")]
    public string Scheme { get; set; } = null!;

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

    [JsonProperty("daemon_sftp")]
    public int DaemonSftp { get; set; }

    [JsonProperty("daemon_listen")]
    public int DaemonListen { get; set; }
}