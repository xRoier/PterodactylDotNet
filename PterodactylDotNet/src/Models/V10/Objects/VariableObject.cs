namespace PterodactylDotNet.Models.V10;

public class VariableObject {
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("description")]
    public string Description { get; set; } = null!;

    [JsonProperty("env_variable")]
    public string EnvVariable { get; set; } = null!;

    [JsonProperty("default_value")]
    public string DefaultValue { get; set; } = null!;

    [JsonProperty("server_value")]
    public string ServerValue { get; set; } = null!;

    [JsonProperty("is_editable")]
    public bool IsEditable { get; set; }

    [JsonProperty("rules")]
    public string Rules { get; set; } = null!;
}