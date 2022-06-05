namespace PterodactylDotNet.API.V10;

public class ClientServerStartup {
    private FlurlClient _client { get; init; } 

    public ClientServerStartup(FlurlClient client) {
        this._client = client;
    }

    private void raiseForStatus(int successfulStatusCode, IFlurlResponse response, string? serverId = null) {
        if (response.StatusCode == 404 && serverId is not null) throw new PterodactylUnknownServer(serverId);
        if (response.StatusCode == 504 && serverId is not null) throw new PterodactylServerOffline(serverId);
        if (response.StatusCode == 403) throw new PterodactylUnauthorized();
        if (response.StatusCode != successfulStatusCode) throw new PterodactylUnknownStatusCode(response.StatusCode);
    }
    
    /// <summary>
    ///     Retrieves all variables on the server.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<IEnumerable<VariableObject>?> GetVariablesAsync(string serverId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "startup")
            .GetAsync(cancellationToken);
        
        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiDataListAttributes<VariableObject>>())
            .Data.Select(x => x.Attributes);
    }

    /// <summary>
    ///     Updates the specified variable
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="key">Key for the specified variable.</param>
    /// <param name="value">Value Id for the specified variable.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<VariableObject?> ReinstallServerAsync(string serverId, string key, string value, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "startup", "variable")
            .PutJsonAsync(new UpdateVariableRequest { Key = key, Value = value }, cancellationToken);
        
        this.raiseForStatus(200, result);

        return (await result.GetJsonAsync<ApiAttributes<VariableObject>>())
            .Attributes;
    }
}