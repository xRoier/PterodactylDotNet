namespace PterodactylDotNet.API.V10;

public class ClientServerSubusers {
    private FlurlClient _client { get; } 

    public ClientServerSubusers(FlurlClient client) {
        this._client = client;
    }

    private void raiseForStatus(int successfulStatusCode, IFlurlResponse response, string? serverId = null) {
        if (response.StatusCode == 404 && serverId is not null) throw new PterodactylUnknownServer(serverId);
        if (response.StatusCode == 504 && serverId is not null) throw new PterodactylServerOffline(serverId);
        if (response.StatusCode == 403) throw new PterodactylUnauthorized();
        if (response.StatusCode != successfulStatusCode) throw new PterodactylUnknownStatusCode(response.StatusCode);
    }

    /// <summary>
    ///     Retrieves all users for the server.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<IEnumerable<SubuserObject>?> GetSubusersAsync(string serverId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "users")
            .GetAsync(cancellationToken);
        
        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiDataListAttributes<SubuserObject>>())
            .Data.Select(x => x.Attributes);
    }

    /// <summary>
    ///     Retrieves information about a specific subuser.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="subuserId">Subuser Id for the specified subuser.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<SubuserObject?> GetSubuserAsync(string serverId, string subuserId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "users", subuserId)
            .GetAsync(cancellationToken);
        
        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiAttributes<SubuserObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Adds a subuser to the server.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="data">Data for user creation.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<SubuserObject?> CreateSubuserAsync(string serverId, CreateSubuserRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "users")
            .PostJsonAsync(data, cancellationToken);
        
        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiAttributes<SubuserObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Updates the specified subuser.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="subuserId">Subuser Id for the specified user.</param>
    /// <param name="data">Data for user update.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<SubuserObject?> UpdateSubuserAsync(string serverId, string subuserId, UpdateSubuserRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "users", subuserId)
            .PostJsonAsync(data, cancellationToken);
        
        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiAttributes<SubuserObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Removes the specified subuser from the server
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="subuserId">Subuser Id for the specified user.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<SubuserObject?> DeleteSubuserAsync(string serverId, string subuserId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "users", subuserId)
            .DeleteAsync(cancellationToken);
        
        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiAttributes<SubuserObject>>())
            .Attributes;
    }
}