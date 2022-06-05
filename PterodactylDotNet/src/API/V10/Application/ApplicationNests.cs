namespace PterodactylDotNet.API.V10;

public class ApplicationNests {
    private FlurlClient _client { get; init; } 

    public ApplicationNests(FlurlClient client) {
        this._client = client;
    }

    private void raiseForStatus(int successfulStatusCode, IFlurlResponse response, int? nodeId = null) {
        if (response.StatusCode == 404 && nodeId.HasValue) throw new PterodactylUnknownNode(nodeId.Value);
        if (response.StatusCode == 403) throw new PterodactylUnauthorized();
        if (response.StatusCode != successfulStatusCode) throw new PterodactylUnknownStatusCode(response.StatusCode);
    }
}