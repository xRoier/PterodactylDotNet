namespace PterodactylDotNet.API.V10;

public class ApplicationLocations {
    private FlurlClient _client { get; } 

    public ApplicationLocations(FlurlClient client) {
        this._client = client;
    }

    private void raiseForStatus(int successfulStatusCode, IFlurlResponse response, int? locationId = null) {
        if (response.StatusCode == 404 && locationId.HasValue) throw new PterodactylUnknownLocation(locationId.Value);
        if (response.StatusCode == 403) throw new PterodactylUnauthorized();
        if (response.StatusCode != successfulStatusCode) throw new PterodactylUnknownStatusCode(response.StatusCode);
    }
    
    /// <summary>
    ///     Retrieves all locations.
    /// </summary>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<IEnumerable<LocationObject>?> GetLocationsAsync(CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "locations")
            .GetAsync(cancellationToken);

        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiDataListAttributes<LocationObject>>())
            .Data.Select(x => x.Attributes);
    }

    /// <summary>
    ///     Retrieves the specified location.
    /// </summary>
    /// <param name="locationId">Location Id of the specified location.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<LocationObject?> GetLocationAsync(int locationId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "locations", locationId)
            .GetAsync(cancellationToken);

        this.raiseForStatus(200, result, locationId);
        
        return (await result.GetJsonAsync<ApiAttributes<LocationObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Creates a new location.
    /// </summary>
    /// <param name="data">Data for location creation.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<LocationObject?> CreateLocationAsync(CreateLocationRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "locations")
            .PostJsonAsync(data, cancellationToken);

        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiAttributes<LocationObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Updates the specified location.
    /// </summary>
    /// <param name="locationId">Location Id of the specified location.</param>
    /// <param name="data">Data for location update.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<LocationObject?> UpdateLocationAsync(int locationId, UpdateLocationRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "locations", locationId)
            .PatchJsonAsync(data, cancellationToken);

        this.raiseForStatus(200, result, locationId);
        
        return (await result.GetJsonAsync<ApiAttributes<LocationObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Deletes the specified location.
    /// </summary>
    /// <param name="locationId">Location Id of the specified location.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<LocationObject?> DeleteLocationAsync(int locationId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "locations", locationId)
            .DeleteAsync( cancellationToken);

        this.raiseForStatus(204, result, locationId);
        
        return (await result.GetJsonAsync<ApiAttributes<LocationObject>>())
            .Attributes;
    }
}