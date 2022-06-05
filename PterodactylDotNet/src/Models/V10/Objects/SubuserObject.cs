namespace PterodactylDotNet.Models.V10;

public class SubuserObject {
    [JsonProperty("uuid")]
    public Guid Uuid { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; } = null!;

    [JsonProperty("email")]
    public string Email { get; set; } = null!;

    [JsonProperty("image")]
    public string Image { get; set; } = null!;

    [JsonProperty("2fa_enabled")]
    public bool TwoFactorEnabled { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("permissions")]
    public List<string> Permissions { get; set; } = null!;
}