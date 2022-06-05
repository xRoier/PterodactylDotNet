namespace PterodactylDotNet.API.V10;

public class ClientServerSettings {
    private FlurlClient _client { get; } 

    public ClientServerSettings(FlurlClient client) {
        this._client = client;
    }

    private void raiseForStatus(int successfulStatusCode, IFlurlResponse response, string? serverId = null) {
        if (response.StatusCode == 404 && serverId is not null) throw new PterodactylUnknownServer(serverId);
        if (response.StatusCode == 403) throw new PterodactylUnauthorized();
        if (response.StatusCode != successfulStatusCode) throw new PterodactylUnknownStatusCode(response.StatusCode);
    }
    
    /// <summary>
    ///     Renames the server.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="name">New name for the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task UpdateNameAsync(string serverId, string name, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "settings", "rename")
            .PostJsonAsync(new UpdateNameRequest { Name = name }, cancellationToken);
        
        this.raiseForStatus(204, result);
    }

    /// <summary>
    ///     Reinstalls the server.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task ReinstallServerAsync(string serverId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "settings", "reinstall")
            .PostAsync(null, cancellationToken);
        
        this.raiseForStatus(204, result);
    }
}