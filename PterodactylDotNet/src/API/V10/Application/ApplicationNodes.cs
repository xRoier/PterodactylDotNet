namespace PterodactylDotNet.API.V10;

public class ApplicationNodes {
    private FlurlClient _client { get; } 

    public ApplicationNodes(FlurlClient client) {
        this._client = client;
        this.Allocations = new ApplicationNodesAllocations(this._client);
    }

    private void raiseForStatus(int successfulStatusCode, IFlurlResponse response, int? nodeId = null) {
        if (response.StatusCode == 404 && nodeId.HasValue) throw new PterodactylUnknownNode(nodeId.Value);
        if (response.StatusCode == 403) throw new PterodactylUnauthorized();
        if (response.StatusCode != successfulStatusCode) throw new PterodactylUnknownStatusCode(response.StatusCode);
    }

    public ApplicationNodesAllocations Allocations { get; }
    
    /// <summary>
    ///     Retrieves a list of nodes.
    /// </summary>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<IEnumerable<NodeObject>?> GetNodesAsync(CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "nodes")
            .GetAsync(cancellationToken);

        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiDataListAttributes<NodeObject>>())
            .Data.Select(x => x.Attributes);
    }

    /// <summary>
    ///     Retrieves the specified node.
    /// </summary>
    /// <param name="nodeId">Node Id of the specified node</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownNode" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<NodeObject?> GetNodeAsync(int nodeId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "nodes", nodeId, "configuration")
            .GetAsync(cancellationToken);

        this.raiseForStatus(200, result, nodeId);
        
        return (await result.GetJsonAsync<ApiAttributes<NodeObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Displays the Wings configuration.
    /// </summary>
    /// <param name="nodeId">Node Id of the specified node</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnknownNode" />
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<WingsObject?> GetNodeConfigurationAsync(int nodeId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "nodes", nodeId, "configuration")
            .GetAsync(cancellationToken);

        this.raiseForStatus(200, result, nodeId);
        
        return await result.GetJsonAsync<WingsObject>();
    }

    /// <summary>
    ///     Creates a new node.
    /// </summary>
    /// <param name="data">Data for node creation.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<NodeObject?> CreateNodeAsync(CreateNodeRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "nodes")
            .PostJsonAsync(data, cancellationToken);

        this.raiseForStatus(201, result);
        
        return (await result.GetJsonAsync<ApiAttributes<NodeObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Updates the node details.
    /// </summary>
    /// <param name="nodeId">Node Id of the specified node</param>
    /// <param name="data">Data for node update.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<NodeObject?> UpdateNodeAsync(int nodeId, UpdateNodeRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "nodes", nodeId)
            .PatchJsonAsync(data, cancellationToken);

        this.raiseForStatus(200, result, nodeId);

        
        return (await result.GetJsonAsync<ApiAttributes<NodeObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Deletes the specified node.
    /// </summary>
    /// <param name="nodeId">Node Id of the specified node</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<NodeObject?> DeleteNodeAsync(int nodeId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "nodes", nodeId)
            .DeleteAsync(cancellationToken);

        this.raiseForStatus(200, result, nodeId);
        
        return (await result.GetJsonAsync<ApiAttributes<NodeObject>>())
            .Attributes;
    }
}