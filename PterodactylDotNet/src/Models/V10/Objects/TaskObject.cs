namespace PterodactylDotNet.Models.V10;

public class TaskObject {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("sequence_id")]
    public int SequenceId { get; set; }

    [JsonProperty("action")]
    public string Action { get; set; } = null!;

    [JsonProperty("payload")]
    public string Payload { get; set; } = null!;

    [JsonProperty("time_offset")]
    public int TimeOffset { get; set; }

    [JsonProperty("is_queued")]
    public bool IsQueued { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }
}