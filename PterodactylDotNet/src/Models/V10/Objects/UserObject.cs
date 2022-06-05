namespace PterodactylDotNet.Models.V10;

public class UserObject {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("external_id")]
    public string ExternalId { get; set; } = null!;

    [JsonProperty("uuid")]
    public Guid Uuid { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; } = null!;

    [JsonProperty("email")]
    public string Email { get; set; } = null!;

    [JsonProperty("first_name")]
    public string FirstName { get; set; } = null!;

    [JsonProperty("last_name")]
    public string LastName { get; set; } = null!;

    [JsonProperty("language")]
    public string Language { get; set; } = null!;

    [JsonProperty("root_admin")]
    public bool RootAdmin { get; set; }

    [JsonProperty("2fa")]
    public bool TwoFactorEnabled { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public static async Task<IEnumerable<UserObject>> Parse(IFlurlResponse response) {
        var ret = new List<UserObject>();
        var data = await response.GetJsonAsync<ApiDataListAttributes<UserObject>>();

        foreach (var userObject in data.Data) 
            ret.Add(userObject.Attributes);

        return ret;
    }
}