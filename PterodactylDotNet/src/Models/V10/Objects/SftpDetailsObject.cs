namespace PterodactylDotNet.Models.V10;

public class SftpDetailsObject {
    [JsonProperty("ip")]
    public string Ip { get; set; } = null!;

    [JsonProperty("port")]
    public int Port { get; set; }
}