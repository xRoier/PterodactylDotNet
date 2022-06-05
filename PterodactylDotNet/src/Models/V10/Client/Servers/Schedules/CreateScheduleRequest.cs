namespace PterodactylDotNet.Models.V10;

public class CreateScheduleRequest {
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("minute")]
    public string Minute { get; set; } = null!;

    [JsonProperty("hour")]
    public string Hour { get; set; } = null!;

    [JsonProperty("day_of_month")]
    public string DayOfMonth { get; set; } = null!;

    [JsonProperty("day_of_week")]
    public string DayOfWeek { get; set; } = null!;

    [JsonProperty("is_active")]
    public bool IsActive { get; set; }
}