namespace PterodactylDotNet.Models.V10;

public class BackupObject {
    [JsonProperty("uuid")]
    public Guid Uuid { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("ignored_files")]
    public List<object> IgnoredFiles { get; set; } = null!;

    [JsonProperty("sha256_hash")]
    public string Sha256Hash { get; set; } = null!;

    [JsonProperty("bytes")]
    public int Bytes { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("completed_at")]
    public DateTime CompletedAt { get; set; }
}