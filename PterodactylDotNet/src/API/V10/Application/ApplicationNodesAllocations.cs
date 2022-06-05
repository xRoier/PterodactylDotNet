namespace PterodactylDotNet.API.V10;

public class ApplicationNodesAllocations {
    private FlurlClient _client { get; } 

    public ApplicationNodesAllocations(FlurlClient client) {
        this._client = client;
    }

    private void raiseForStatus(int successfulStatusCode, IFlurlResponse response, int? nodeId = null, int? allocationId = null) {
        if (response.StatusCode == 404 && nodeId.HasValue) throw new PterodactylUnknownNode(nodeId.Value);
        if (response.StatusCode == 404 && allocationId.HasValue) throw new PterodactylUnknownAllocation(allocationId.Value);
        if (response.StatusCode == 403) throw new PterodactylUnauthorized();
        if (response.StatusCode != successfulStatusCode) throw new PterodactylUnknownStatusCode(response.StatusCode);
    }

    /// <summary>
    ///     Lists allocations added to the node.
    /// </summary>
    /// <param name="nodeId">Node Id of the specified node.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<IEnumerable<AllocationObjectApplication>?> GetAllocationsAsync(int nodeId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "nodes", nodeId, "allocations")
            .GetAsync(cancellationToken);

        this.raiseForStatus(200, result, nodeId);
        
        return (await result.GetJsonAsync<ApiDataListAttributes<AllocationObjectApplication>>())
            .Data.Select(x => x.Attributes);
    }

    /// <summary>
    ///     Adds an allocation to the node.
    /// </summary>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <param name="nodeId">Node Id of the specified node.</param>
    /// <param name="data">Data for allocation creation.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task CreateAllocationAsync(int nodeId, CreateNodeAllocationRequest data, CancellationToken cancellationToken = default) { 
        var result = await _client.Request("api", "application", "nodes", nodeId, "allocations")
            .PostJsonAsync(data, cancellationToken);

        this.raiseForStatus(204, result, nodeId);
    }

    /// <summary>
    ///     Deletes the specified allocation.
    /// </summary>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <param name="nodeId">Node Id of the specified node.</param>
    /// <param name="allocationId">Allocation Id of the specified allocation.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task DeleteAllocationAsync(int nodeId, int allocationId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "nodes", nodeId, "allocations", allocationId)
            .DeleteAsync(cancellationToken);

        this.raiseForStatus(204, result, nodeId, allocationId);
    }
}