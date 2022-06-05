namespace PterodactylDotNet.Models.V10;

public class UpdateSubuserRequest {
    [JsonProperty("permissions")]
    public List<string> Permissions = new();
}