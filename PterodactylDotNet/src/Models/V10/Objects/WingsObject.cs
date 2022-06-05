namespace PterodactylDotNet.Models.V10;

public class WingsObject {
    [JsonProperty("debug")]
    public bool Debug { get; set; }

    [JsonProperty("uuid")]
    public Guid Uuid { get; set; }

    [JsonProperty("token_id")]
    public string TokenId { get; set; } = null!;

    [JsonProperty("token")]
    public string Token { get; set; } = null!;

    [JsonProperty("api")]
    public WingsApi Api { get; set; } = null!;

    [JsonProperty("system")]
    public WingsSystem System { get; set; } = null!;

    [JsonProperty("remote")]
    public string Remote { get; set; } = null!;

    public class WingsApi {
        [JsonProperty("host")]
        public string Host { get; set; } = null!;

        [JsonProperty("port")]
        public int Port { get; set; }

        [JsonProperty("ssl")]
        public ApiSsl Ssl { get; set; } = null!;

        [JsonProperty("upload_limit")]
        public int UploadLimit { get; set; }

        public class ApiSsl {
            [JsonProperty("enabled")]
            public bool Enabled { get; set; }

            [JsonProperty("cert")]
            public string Cert { get; set; } = null!;

            [JsonProperty("key")]
            public string Key { get; set; } = null!;
        }
    }

    public class WingsSystem {
        [JsonProperty("data")]
        public string Data { get; set; } = null!;

        [JsonProperty("sftp")]
        public SystemSftp Sftp { get; set; } = null!;

        public class SystemSftp {
            [JsonProperty("bind_port")]
            public int BindPort { get; set; }
        }
    }
}