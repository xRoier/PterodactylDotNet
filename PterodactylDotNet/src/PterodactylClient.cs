namespace PterodactylDotNet;

public class PterodactylClient {
    private FlurlClient _client { get; init; }

    private string _hostname { get; init; }
    private string _token { get; init; }
    private PterodactylTokenType _tokenType { get; init; }
    
    public PterodactylClient(string hostname, string token, PterodactylTokenType tokenType) {
        this._hostname = hostname;
        this._token = token;
        this._tokenType = tokenType;

        this._client = new FlurlClient(this._hostname)
            .WithOAuthBearerToken(this._token)
            .AllowAnyHttpStatus()
            .WithHeader("accept", "Application/vnd.pterodactyl.v1+json")
            .WithHeader("content-type", "application/json");
            
        this.Servers = new ClientServer(this._client);
        this.Account = new ClientAccount(this._client);
    }

    public ClientServer Servers { get; init; }
    public ClientAccount Account { get; init; }
}