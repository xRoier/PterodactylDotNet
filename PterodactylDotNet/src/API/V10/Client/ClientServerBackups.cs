namespace PterodactylDotNet.API.V10;

public class ClientServerBackups {
    private FlurlClient _client { get; init; } 

    public ClientServerBackups(FlurlClient client) {
        this._client = client;
    }

    private void raiseForStatus(int successfulStatusCode, IFlurlResponse response, string? serverId = null, string? backupId = null) {
        if (response.StatusCode == 404 && serverId is not null) throw new PterodactylUnknownServer(serverId);
        if (response.StatusCode == 404 && backupId is not null) throw new PterodactylUnknownBackup(backupId);
        if (response.StatusCode == 504 && serverId is not null) throw new PterodactylServerOffline(serverId);
        if (response.StatusCode == 403) throw new PterodactylUnauthorized();
        if (response.StatusCode != successfulStatusCode) throw new PterodactylUnknownStatusCode(response.StatusCode);
    }
    
    /// <summary>
    ///     Retrieves all backups on the server.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<IEnumerable<BackupObject>?> GetBackupsAsync(string serverId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "backups")
            .GetAsync(cancellationToken);
        
        this.raiseForStatus(200, result, serverId);
        
        return (await result.GetJsonAsync<ApiDataListAttributes<BackupObject>>())
            .Data.Select(x => x.Attributes);
    }

    /// <summary>
    ///     Retrieves information about the specified backup.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="backupId">Backup Id for the specified backup.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<BackupObject?> GetBackupAsync(string serverId, string backupId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "startup", "variable")
            .GetAsync(cancellationToken);
        
        this.raiseForStatus(200, result, serverId, backupId);

        return (await result.GetJsonAsync<ApiAttributes<BackupObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Creates a new backup.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<BackupObject?> CreateBackupAsync(string serverId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "backups")
            .PostAsync(null, cancellationToken);
        
        this.raiseForStatus(200, result, serverId);

        return (await result.GetJsonAsync<ApiAttributes<BackupObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Generates a download link for a backup.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="backupId">Backup Id for the specified backup.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<SignedUrlObject?> DownloadBackupAsync(string serverId, string backupId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "backups", backupId, "download")
            .GetAsync(cancellationToken);
        
        this.raiseForStatus(200, result, serverId, backupId);

        return (await result.GetJsonAsync<ApiAttributes<SignedUrlObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Deletes the specified backup
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="backupId">Backup Id for the specified backup.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task DeleteBackupAsync(string serverId, string backupId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "backups", backupId, "download")
            .DeleteAsync(cancellationToken);
        
        this.raiseForStatus(204, result, serverId, backupId);
    }
}