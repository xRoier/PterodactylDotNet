namespace PterodactylDotNet.Models.V10;

public class ApiData<T> {
    [JsonProperty("object")]
    public string Object { get; set; } = null!;
    
    [JsonProperty("data")]
    public T Data { get; set; } = default!;
    
    [JsonProperty("meta")]
    public ApiMetadata? Metadata { get; set; } = default!;
}

public class ApiDataList<T> {
    [JsonProperty("object")]
    public string Object { get; set; } = null!;
    
    [JsonProperty("data")]
    public List<T> Data { get; set; } = default!;
    
    [JsonProperty("meta")]
    public ApiMetadata? Metadata { get; set; } = default!;
}

public class ApiAttributes<T> {
    [JsonProperty("object")]
    public string Object { get; set; } = null!;
    
    [JsonProperty("attributes")]
    public T Attributes { get; set; } = default!;
}

public class ApiDataListAttributes<T> {
    [JsonProperty("object")]
    public string Object { get; set; } = null!;
    
    [JsonProperty("data")]
    public List<ApiAttributes<T>> Data { get; set; } = default!;
    
    [JsonProperty("meta")]
    public ApiMetadata? Metadata { get; set; } = default!;
}

public class ApiMetadata {
    [JsonProperty("pagination")]
    public ApiPagination Pagination { get; set; } = default!;

    public class ApiPagination {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}

public enum PterodactylTokenType {
    None,
    Application,
    Client
}

public enum ServerPowerState {
    Start,
    Stop,
    Restart,
    Kill
}