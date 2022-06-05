namespace PterodactylDotNet.API.V10;

public class ClientServerFiles {
    private FlurlClient _client { get; } 

    public ClientServerFiles(FlurlClient client) {
        this._client = client;
    }

    private void raiseForStatus(int successfulStatusCode, IFlurlResponse response, string? serverId = null) {
        if (response.StatusCode == 404 && serverId is not null) throw new PterodactylUnknownServer(serverId);
        if (response.StatusCode == 504 && serverId is not null) throw new PterodactylServerOffline(serverId);
        if (response.StatusCode == 403) throw new PterodactylUnauthorized();
        if (response.StatusCode != successfulStatusCode) throw new PterodactylUnknownStatusCode(response.StatusCode);
    }
    
    /// <summary>
    ///     Retrieves all files for the server.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="directory">Directory to get retrieve all files for.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<IEnumerable<FileObject>?> GetFilesAsync(string serverId, string directory = "/", CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "files", "list")
            .SetQueryParam("directory", directory)
            .GetAsync(cancellationToken);
        
        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiDataListAttributes<FileObject>>())
            .Data.Select(x => x.Attributes);
    }

    ///<summary>
    ///     Displays the contents of the specified file.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="directory">Directory to get retrieve all files for.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<string?> GetFileContentsAsync(string serverId, string filePath, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "files", "contents")
            .SetQueryParam("file", filePath)
            .GetAsync(cancellationToken);
        
        this.raiseForStatus(200, result);
        
        return await result.GetStringAsync();
    }

    ///<summary>
    ///     Generates a one-time link to download the specified file.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="directory">Directory to get retrieve all files for.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<SignedUrlObject?> DownloadFileAsync(string serverId, string filePath, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "files", "download")
            .SetQueryParam("file", filePath)
            .GetAsync(cancellationToken);
        
        this.raiseForStatus(200, result);
        
        return (await result.GetJsonAsync<ApiAttributes<SignedUrlObject>>())
            .Attributes;
    }

    ///<summary>
    ///     Renames the specified file(s) or folder(s)
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="data">Data for file rename creation.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task RenameFileAsync(string serverId, UpdateFileNameRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "files", "rename")
            .PutJsonAsync(data, cancellationToken);
        
        this.raiseForStatus(204, result);
    }

    ///<summary>
    ///     Copies the specified file.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="data">Data for file copy.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task CopyFileAsync(string serverId, CopyFileRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "files", "copy")
            .PostJsonAsync(data, cancellationToken);
        
        this.raiseForStatus(204, result);
    }

    ///<summary>
    ///     Writes data to the specified file.
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="filePath">File to update.</param>
    /// <param name="data">Data for file contents update.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task UpdateFileContentsAsync(string serverId, string filePath, string data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "files", "write")
            .SetQueryParam("file", filePath)
            .PostJsonAsync(data, cancellationToken);
        
        this.raiseForStatus(204, result);
    }

    ///<summary>
    ///     Compresses the specified file
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="data">Data for file compress.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<FileObject?> CompressFileAsync(string serverId, CompressFileRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "files", "compress")
            .PostJsonAsync(data, cancellationToken);
        
        this.raiseForStatus(200, result);

        return (await result.GetJsonAsync<ApiAttributes<FileObject>>())
            .Attributes;
    }

    ///<summary>
    ///     Decompresses the specified file
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="data">Data for file decompress.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task DecompressFileAsync(string serverId, DecompressFileRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "files", "decompress")
            .PostJsonAsync(data, cancellationToken);
        
        this.raiseForStatus(204, result);
    }

    ///<summary>
    ///     Deletes the specified file(s) or folder(s)
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="data">Data for file delete.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task DeleteFileAsync(string serverId, DecompressFileRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "files", "delete")
            .PostJsonAsync(data, cancellationToken);
        
        this.raiseForStatus(204, result);
    }

    ///<summary>
    ///     Creates the specified folder in the specified directory
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="data">Data for file delete.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task CreateFolderAsync(string serverId, CreateFolderRequest data, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "files", "create-folder")
            .PostJsonAsync(data, cancellationToken);
        
        this.raiseForStatus(204, result);
    }
 
    ///<summary>
    ///     Returns a signed URL used to upload files to the server using POST
    /// </summary>
    /// <param name="serverId">Server Id for the specified server.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="PterodactylUnauthorized" />
    /// <exception cref="PterodactylUnknownStatusCode" />
    public async Task<SignedUrlObject?> UploadFileAsync(string serverId, CancellationToken cancellationToken = default) {
        var result = await _client.Request("api", "client", "servers", serverId, "files", "compress")
            .GetAsync(cancellationToken);
        
        this.raiseForStatus(200, result);

        return (await result.GetJsonAsync<ApiAttributes<SignedUrlObject>>())
            .Attributes;
    }

}