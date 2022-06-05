namespace PterodactylDotNet.Models.V10;

public class CreateSubuserRequest {
    [JsonProperty("email")]
    public string Email { get; set; } = null!;

    [JsonProperty("permissions")]
    public List<string> Permissions = new();
}