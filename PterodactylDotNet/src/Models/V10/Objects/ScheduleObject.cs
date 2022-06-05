namespace PterodactylDotNet.Models.V10;

public class ScheduleObject {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("cron")] 
    public ScheduleCronObject Cron { get; set; } = null!;

    [JsonProperty("is_active")]
    public bool IsActive { get; set; }

    [JsonProperty("is_processing")]
    public bool IsProcessing { get; set; }

    [JsonProperty("last_run_at")]
    public object LastRunAt { get; set; } = null!;

    [JsonProperty("next_run_at")]
    public DateTime NextRunAt { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }
    
    [JsonProperty("relationships")]
    public ApiDataListAttributes<TaskObject> Relationships { get; set; } = null!;

    public class ScheduleCronObject {
        [JsonProperty("day_of_week")]
        public string DayOfWeek { get; set; } = null!;

        [JsonProperty("day_of_month")]
        public string DayOfMonth { get; set; } = null!;

        [JsonProperty("hour")]
        public string Hour { get; set; } = null!;

        [JsonProperty("minute")]
        public string Minute { get; set; } = null!;
    }
}