namespace PterodactylDotNet;

public class PterodactylApplication {
    private FlurlClient _client { get; }

    private string _hostname { get; }
    private string _token { get; }
    private PterodactylTokenType _tokenType { get; }
    
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

    public ApplicationUsers Users { get; }
    public ApplicationNodes Nodes { get; }
    public ApplicationLocations Locations { get; }
    public ApplicationServers Servers { get; }
    public ApplicationNests Nests { get; }
}