namespace PterodactylDotNet.API.V10;

public class ApplicationServersDatabases {
    private FlurlClient _client { get; } 

    public ApplicationServersDatabases(FlurlClient client) {
        this._client = client;
    }
}