namespace PterodactylDotNet.Models.V10;

public class UpdateUserRequest {
    [JsonProperty("email")]
    public string Email { get; set; } = null!;

    [JsonProperty("username")]
    public string Username { get; set; } = null!;

    [JsonProperty("first_name")]
    public string FirstName { get; set; } = null!;

    [JsonProperty("last_name")]
    public string LastName { get; set; } = null!;

    [JsonProperty("language")]
    public string Language { get; set; } = null!;

    [JsonProperty("password")]
    public string Password { get; set; } = null!;
}