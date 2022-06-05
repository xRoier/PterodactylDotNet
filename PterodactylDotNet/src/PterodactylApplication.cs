namespace PterodactylDotNet;

public class PterodactylApplication {
    private FlurlClient _client { get; init; }

    private string _hostname { get; init; }
    private string _token { get; init; }
    private PterodactylTokenType _tokenType { get; init; }
    
    public PterodactylApplication(string hostname, string token, PterodactylTokenType tokenType) {
        this._hostname = hostname;
        this._token = token;
        this._tokenType = tokenType;

        this._client = new FlurlClient(this._hostname)
            .WithOAuthBearerToken(this._token)
            .AllowAnyHttpStatus()
            .WithHeader("content-type", "application/json");
            
        this.Users = new ApplicationUsers(this._client);
        this.Nodes = new ApplicationNodes(this._client);
        this.Locations = new ApplicationLocations(this._client);
        this.Servers = new ApplicationServers(this._client);
        this.Nests = new ApplicationNests(this._client);
    }

    public ApplicationUsers Users { get; init; }
    public ApplicationNodes Nodes { get; init; }
    public ApplicationLocations Locations { get; init; }
    public ApplicationServers Servers { get; init; }
    public ApplicationNests Nests { get; init; }
}