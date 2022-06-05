namespace PterodactylDotNet.Models.V10;

public class AllocationObjectApplication {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("ip")]
    public string Ip { get; set; } = null!;

    [JsonProperty("alias")]
    public string Alias { get; set; } = null!;

    [JsonProperty("port")]
    public int Port { get; set; }

    [JsonProperty("notes")]
    public string Notes { get; set; } = null!;

    [JsonProperty("assigned")]
    public bool Assigned { get; set; }
}

public class AllocationObjectClient {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("ip")]
    public string Ip { get; set; } = null!;

    [JsonProperty("alias")]
    public string Alias { get; set; } = null!;

    [JsonProperty("port")]
    public int Port { get; set; }

    [JsonProperty("notes")]
    public string Notes { get; set; } = null!;

    [JsonProperty("is_default")]
    public bool IsDefault { get; set; }
}