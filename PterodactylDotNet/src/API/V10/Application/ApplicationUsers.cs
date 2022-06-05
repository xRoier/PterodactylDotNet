namespace PterodactylDotNet.API.V10;

public class ApplicationUsers {
    private FlurlClient _client { get; } 

    public ApplicationUsers(FlurlClient client) {
        this._client = client;
    }

    private void raiseForStatus(int successfulStatusCode, IFlurlResponse response, int? userId = null) {
        if (response.StatusCode == 404 && userId.HasValue) throw new PterodactylUnknownUser(userId.Value);
        if (response.StatusCode == 403) throw new PterodactylUnauthorized();
        if (response.StatusCode != successfulStatusCode) throw new PterodactylUnknownStatusCode(response.StatusCode);
    }
    
    /// <summary>
    ///     Retrieves all users.
    /// </summary>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <param name="filter">Filter object.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <returns>A Task whose result is <see cref="ListUsersResponse" /></returns>
    public async Task<IEnumerable<UserObject>?> GetUsersAsync(CancellationToken cancellationToken = default, object filter = null!) {
        var result = await _client.Request("api", "application", "users")
            .WithFilters(filter)
            .GetAsync(cancellationToken);

        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiDataListAttributes<UserObject>>())
            .Data.Select(x => x.Attributes);
    }

    /// <summary>
    ///     Retrieves the specified user.
    /// </summary>
    /// <param name="userId">User Id of the specified user.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <returns>A Task whose result is <see cref="UserDetailsResponse" /></returns>
    public async Task<UserObject?> GetUserAsync(int userId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "users", userId)
            .GetAsync(cancellationToken);

        this.raiseForStatus(200, result, userId);
        
        return (await result.GetJsonAsync<ApiAttributes<UserObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Retrieves the specified user by its external ID.
    /// </summary>
    /// <param name="remoteId">Remote Id of the specified user.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <returns>A Task whose result is <see cref="UserDetailsResponse" /></returns>
    public async Task<UserObject?> GetUserAsync(string remoteId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "users", "external", remoteId)
            .GetAsync(cancellationToken);

        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiAttributes<UserObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Creates a new user.
    /// </summary>
    /// <param name="data">Data for user creation.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <returns>A Task whose result is <see cref="UserDetailsResponse" /></returns>
    public async Task<UserObject?> CreateUserAsync(CreateUserRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "users")
            .PostJsonAsync(data, cancellationToken);

        this.raiseForStatus(201, result);
        
        return (await result.GetJsonAsync<ApiAttributes<UserObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Updates the user information.
    /// </summary>
    /// <param name="userId">User Id of the specified user.</param>
    /// <param name="data">Data for user update.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <returns>A Task whose result is <see cref="UserDetailsResponse" /></returns>
    public async Task<UserObject?> UpdateUserAsync(int userId, UpdateUserRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "users", userId)
            .PatchJsonAsync(data, cancellationToken);

        this.raiseForStatus(200, result, userId);
        
        return (await result.GetJsonAsync<ApiAttributes<UserObject>>())
            .Attributes;
    }

    /// <summary>
    ///     Deletes the specified user
    /// </summary>
    /// <param name="userId">User Id of the specified user.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <returns>A Task with no result</returns>
    public async Task DeleteUserAsync(int userId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "application", "users", userId)
            .DeleteAsync(cancellationToken);

        this.raiseForStatus(204, result, userId);
    }
}