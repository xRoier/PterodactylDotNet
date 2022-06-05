namespace PterodactylDotNet.Models.V10;

public class StatsObject {
    [JsonProperty("current_state")]
    public string CurrentState { get; set; } = null!;

    [JsonProperty("is_suspended")]
    public bool IsSuspended { get; set; }

    [JsonProperty("resources")]
    public StatsResources Resources { get; set; } = null!;

    public class StatsResources {
        [JsonProperty("memory_bytes")]
        public int MemoryBytes { get; set; }

        [JsonProperty("cpu_absolute")]
        public int CpuAbsolute { get; set; }

        [JsonProperty("disk_bytes")]
        public int DiskBytes { get; set; }

        [JsonProperty("network_rx_bytes")]
        public int NetworkRxBytes { get; set; }

        [JsonProperty("network_tx_bytes")]
        public int NetworkTxBytes { get; set; }
    }
}