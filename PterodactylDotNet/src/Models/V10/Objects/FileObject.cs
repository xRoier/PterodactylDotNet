namespace PterodactylDotNet.Models.V10;

public class FileObject {
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("mode")]
    public string Mode { get; set; } = null!;

    [JsonProperty("size")]
    public ulong Size { get; set; }

    [JsonProperty("is_file")]
    public bool IsFile { get; set; }

    [JsonProperty("is_symlink")]
    public bool IsSymlink { get; set; }

    [JsonProperty("is_editable")]
    public bool IsEditable { get; set; }

    [JsonProperty("mimetype")]
    public string MimeType { get; set; } = null!;

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("modified_at")]
    public DateTime ModifiedAt { get; set; }
}