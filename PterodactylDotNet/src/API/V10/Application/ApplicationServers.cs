namespace PterodactylDotNet.API.V10;

public class ApplicationServers {
    private FlurlClient _client { get; init; } 

    public ApplicationServers(FlurlClient client) {
        this._client = client;
        this.Databases = new ApplicationServersDatabases(this._client);
    }

    private void raiseForStatus(int successfulStatusCode, IFlurlResponse response, int? serverId = null) {
        if (response.StatusCode == 404 && serverId.HasValue) throw new PterodactylUnknownNode(serverId.Value);
        if (response.StatusCode == 403) throw new PterodactylUnauthorized();
        if (response.StatusCode != successfulStatusCode) throw new PterodactylUnknownStatusCode(response.StatusCode);
    }

    public ApplicationServersDatabases Databases { get; init; }
    
    /// <summary>
    ///     Retrieves all servers.
    /// </summary>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<IEnumerable<ServerObjectApplication>?> GetServersAsync(CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "servers")
            .GetAsync(cancellationToken);

        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiDataListAttributes<ServerObjectApplication>>())
            .Data.Select(x => x.Attributes);
    }

    /// <summary>
    ///     Retrieves the specified server.
    /// </summary>
    /// <param name="serverId">Server Id of the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<ServerObjectApplication?> GetServerAsync(int serverId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "servers", serverId)
            .GetAsync(cancellationToken);

        this.raiseForStatus(200, result, serverId);
        
        return (await result.GetJsonAsync<ApiAttributes<ServerObjectApplication>>())
            .Attributes;
    }

    /// <summary>
    ///     Retrieves a server by its external ID
    /// </summary>
    /// <param name="externalId">External Id of the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<ServerObjectApplication?> GetServerAsync(string externalId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "servers", "external", externalId)
            .GetAsync(cancellationToken);

        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiAttributes<ServerObjectApplication>>())
            .Attributes;
    }

    /// <summary>
    ///     Updates the server details;
    /// </summary>
    /// <param name="serverId">Server Id of the specified server.</param>
    /// <param name="data">Data for server detail update.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<ServerObjectApplication?> UpdateServerDetails(int serverId, UpdateServerDetailsRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "servers", serverId, "details")
            .PatchJsonAsync(data, cancellationToken);

        this.raiseForStatus(200, result, serverId);
        
        return (await result.GetJsonAsync<ApiAttributes<ServerObjectApplication>>())
            .Attributes;
    }

    /// <summary>
    ///     Updates the server build information.
    /// </summary>
    /// <param name="serverId">Server Id of the specified server.</param>
    /// <param name="data">Data for server build update.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<ServerObjectApplication?> UpdateServerBuild(int serverId, UpdateServerBuildRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "servers", serverId, "build")
            .PatchJsonAsync(data, cancellationToken);

        this.raiseForStatus(200, result, serverId);
        
        return (await result.GetJsonAsync<ApiAttributes<ServerObjectApplication>>())
            .Attributes;
    }

    /// <summary>
    ///     Updates the server startup information.
    /// </summary>
    /// <param name="serverId">Server Id of the specified server.</param>
    /// <param name="data">Data for server startup update.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<ServerObjectApplication?> UpdateServerStartup(int serverId, UpdateServerStartupRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "servers", serverId, "startup")
            .PatchJsonAsync(data, cancellationToken);

        this.raiseForStatus(200, result, serverId);
        
        return (await result.GetJsonAsync<ApiAttributes<ServerObjectApplication>>())
            .Attributes;
    }

    /// <summary>
    ///     Creates a new server.
    /// </summary>
    /// <param name="data">Data for server creation.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<ServerObjectApplication?> CreateLocationAsync(CreateServerRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "servers")
            .PostJsonAsync(data, cancellationToken);

        this.raiseForStatus(201, result);
        
        return (await result.GetJsonAsync<ApiAttributes<ServerObjectApplication>>())
            .Attributes;
    }

    /// <summary>
    ///     Suspends the specified server
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task SuspendServerAsync(int serverId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "servers", serverId, "suspend")
            .PostAsync(null, cancellationToken);
        
        this.raiseForStatus(204, result);
    }

    /// <summary>
    ///     Unsuspends the specified server
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task UnsuspendServerAsync(int serverId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "servers", serverId, "unsuspend")
            .PostAsync(null, cancellationToken);

        this.raiseForStatus(204, result);
    }

    /// <summary>
    ///     Deletes the specified server.
    /// </summary>
    /// <param name="serverId">Server Id of the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task DeleteServerAsync(int serverId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "servers", serverId)
            .DeleteAsync(cancellationToken);

        this.raiseForStatus(204, result);        
    }

    /// <summary>
    ///     Forcefully deletes the specified server.
    /// </summary>
    /// <param name="serverId">Server Id of the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task DeleteForceServerAsync(int serverId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "servers", serverId, "force")
            .DeleteAsync(cancellationToken);

        this.raiseForStatus(204, result);        
    }
}