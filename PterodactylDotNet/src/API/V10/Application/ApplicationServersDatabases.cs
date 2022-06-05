namespace PterodactylDotNet.API.V10;

public class ApplicationServersDatabases {
    private FlurlClient _client { get; init; } 

    public ApplicationServersDatabases(FlurlClient client) {
        this._client = client;
    }
}