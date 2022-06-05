namespace PterodactylDotNet.API.V10;

public class ClientServerNetwork {
    private FlurlClient _client { get; } 

    public ClientServerNetwork(FlurlClient client) {
        this._client = client;
    }

    private void raiseForStatus(int successfulStatusCode, IFlurlResponse response, string? serverId = null) {
        if (response.StatusCode == 404 && serverId is not null) throw new PterodactylUnknownServer(serverId);
        if (response.StatusCode == 400 && serverId is not null) throw new PterodactylUnableToDeletePrimaryAllocation(serverId);
        if (response.StatusCode == 504 && serverId is not null) throw new PterodactylServerOffline(serverId);
        if (response.StatusCode == 403) throw new PterodactylUnauthorized();
        if (response.StatusCode != successfulStatusCode) throw new PterodactylUnknownStatusCode(response.StatusCode);
    }

    /// <summary>
    ///     Retrieves all allocations for the server.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<IEnumerable<AllocationObjectClient>?> GetAllocationsAsync(string serverId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "network", "allocations")
            .GetAsync(cancellationToken);
        
        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiDataListAttributes<AllocationObjectClient>>())
            .Data.Select(x => x.Attributes);
    }

    /// <summary>
    ///     Automatically assigns a new allocation if auto-assign is enabled on the instance
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<AllocationObjectClient?> CreateAllocationAsync(string serverId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "network", "allocations")
            .PostAsync(null, cancellationToken);
        
        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiAttributes<AllocationObjectClient>>())
            .Attributes;
    }

    /// <summary>
    ///     Sets a note for the allocation.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="allocationId">Allocation Id for the specified allocation.</param>
    /// <param name="notes">Notes to update the allocation with.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<AllocationObjectClient?> UpdateAllocationNotesAsync(string serverId, string allocationId, string notes, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "network", "allocations", allocationId)
            .PostJsonAsync(new UpdateAllocationNoteRequest { Notes = notes }, cancellationToken);
        
        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiAttributes<AllocationObjectClient>>())
            .Attributes;
    }

    /// <summary>
    ///     Sets a note for the allocation.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="allocationId">Allocation Id for the specified allocation.</param>
    /// <param name="notes">Notes to update the allocation with.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<AllocationObjectClient?> UpdatePrimaryAllocationAsysnc(string serverId, string allocationId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "network", "allocations", allocationId, "primary")
            .PostAsync(null, cancellationToken);
        
        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiAttributes<AllocationObjectClient>>())
            .Attributes;
    }
    
    /// <summary>
    ///     Deletes the specified non-primary allocation
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="allocationId">Allocation Id for the specified allocation.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task DeleteAllocationAsync(string serverId, string allocationId, string notes, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "network", "allocations", allocationId)
            .DeleteAsync(cancellationToken);
        
        this.raiseForStatus(204, result);
    }
}