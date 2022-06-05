namespace PterodactylDotNet.Models.V10;

public class UpdateAllocationNoteRequest {
    [JsonProperty("notes")]
    public string Notes { get; set; } = null!;
}