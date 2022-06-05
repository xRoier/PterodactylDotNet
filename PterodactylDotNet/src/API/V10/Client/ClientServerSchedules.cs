namespace PterodactylDotNet.API.V10;

public class ClientServerSchedules {
    private FlurlClient _client { get; } 

    public ClientServerSchedules(FlurlClient client) {
        this._client = client;
    }

    private void raiseForStatus(int successfulStatusCode, IFlurlResponse response, string? serverId = null) {
        if (response.StatusCode == 404 && serverId is not null) throw new PterodactylUnknownServer(serverId);
        if (response.StatusCode == 504 && serverId is not null) throw new PterodactylServerOffline(serverId);
        if (response.StatusCode == 403) throw new PterodactylUnauthorized();
        if (response.StatusCode != successfulStatusCode) throw new PterodactylUnknownStatusCode(response.StatusCode);
    }

    /// <summary>
    ///     Retrieves all schedules for the server.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<IEnumerable<ScheduleObject>?> GetSchedulesAsync(string serverId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "schedules")
            .GetAsync(cancellationToken);
        
        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiDataListAttributes<ScheduleObject>>())
            .Data.Select(x => x.Attributes);
    }

    /// <summary>
    ///     Retrieves specific schedule.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="scheduleId">Schedule Id for the specified schedule.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<ScheduleObject?> GetScheduleAsync(string serverId, string scheduleId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "schedules", scheduleId)
            .GetAsync(cancellationToken);
        
        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiAttributes<ScheduleObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Creates a new schedule.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="data">Data for schedule creation.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<ScheduleObject?> CreateScheduleAsync(string serverId, CreateScheduleRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "schedules")
            .PostJsonAsync(data, cancellationToken);
        
        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiAttributes<ScheduleObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Updates the specified schedule.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="scheduleId">Schedule Id for the specified schedule.</param>
    /// <param name="data">Data for schedule creation.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<ScheduleObject?> UpdateScheduleAsync(string serverId, string scheduleId, UpdateScheduleRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "schedules")
            .PostJsonAsync(data, cancellationToken);
        
        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiAttributes<ScheduleObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Deletes the specified schedule.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="scheduleId">Schedule Id for the specified schedule.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task DeleteScheduleAsync(string serverId, string scheduleId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "schedules")
            .DeleteAsync(cancellationToken);
        
        this.raiseForStatus(204, result);
    }
}