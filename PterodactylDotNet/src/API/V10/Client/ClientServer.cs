namespace PterodactylDotNet.API.V10;

public class ClientServer {
    private FlurlClient _client { get; } 

    public ClientServer(FlurlClient client) {
        this._client = client;

        this.Settings = new ClientServerSettings(this._client);
        this.Startup = new ClientServerStartup(this._client);
        this.Backups = new ClientServerBackups(this._client);
        this.Users = new ClientServerSubusers(this._client);
        this.Network = new ClientServerNetwork(this._client);
        this.Schedules = new ClientServerSchedules(this._client);
        this.Files = new ClientServerFiles(this._client);
        this.Databases = new ClientServerDatabases(this._client);
    }

    public ClientServerSettings Settings { get; }
    public ClientServerStartup Startup { get; }
    public ClientServerBackups Backups { get; }
    public ClientServerSubusers Users { get; }
    public ClientServerNetwork Network { get; }
    public ClientServerSchedules Schedules { get; }
    public ClientServerFiles Files { get; }
    public ClientServerDatabases Databases { get; }

    private void raiseForStatus(int successfulStatusCode, IFlurlResponse response, string? serverId = null) {
        if (response.StatusCode == 404 && serverId is not null) 
            throw new PterodactylUnknownServer(serverId); 
        if (response.StatusCode == 504 && serverId is not null) 
            throw new PterodactylServerOffline(serverId);
        if (response.StatusCode == 403) 
            throw new PterodactylUnauthorized();
        if (response.StatusCode != successfulStatusCode) 
            throw new PterodactylUnknownStatusCode(response.StatusCode);

    }
    
    /// <summary>
    ///     Retrieves all servers.
    /// </summary>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<IEnumerable<ServerObjectClient>?> GetServersAsync(CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client")
            .GetAsync(cancellationToken);
        
        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiDataListAttributes<ServerObjectClient>>())
            .Data.Select(x => x.Attributes);
    }

    /// <summary>
    ///     Retrieves the specified server.
    /// </summary>
    /// <param name="serverId">Server Id of the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownServer" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<ServerObjectClient?> GetServerAsync(string serverId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId)
            .GetAsync(cancellationToken);

        this.raiseForStatus(200, result, serverId);
        
        return (await result.GetJsonAsync<ApiAttributes<ServerObjectClient>>())
            .Attributes;
    }

    /// <summary>
    ///     Retrieves resource utilization of the specified server.
    /// </summary>
    /// <param name="serverId">Server Id of the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownServer" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<StatsObject?> GetServerResourcesAsync(string serverId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "resources")
            .GetAsync(cancellationToken);

        this.raiseForStatus(200, result, serverId);
        
        return (await result.GetJsonAsync<ApiAttributes<StatsObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Sends a command to the server.
    /// </summary>
    /// <param name="serverId">Server Id of the specified server.</param>
    /// <param name="command">Command to send to the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylServerOffline" />
    /// <exception cref="PterodactylUnknownServer" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task SendCommandAsync(string serverId, string command, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "command")
            .PostJsonAsync(new SendCommandRequest { Command = command }, cancellationToken);

        this.raiseForStatus(204, result, serverId);
    }

    /// <summary>
    ///     Sends a power signal to the server.
    /// </summary>
    /// <param name="serverId">Server Id of the specified server.</param>
    /// <param name="state">Power state to send to the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylServerOffline" />
    /// <exception cref="PterodactylUnknownServer" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task SendPowerState(string serverId, ServerPowerState state, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "power")
            .PostJsonAsync(new SendPowerStateRequest { Signal = state.ToString().ToLower() }, cancellationToken);

        this.raiseForStatus(204, result, serverId);
    }
}