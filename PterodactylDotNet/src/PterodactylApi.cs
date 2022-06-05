global using Flurl.Http;
global using Newtonsoft.Json;

global using PterodactylDotNet.API.V10;
global using PterodactylDotNet.Models.V10;
global using PterodactylDotNet.Exceptions;

namespace PterodactylDotNet;

public class PterodactylApi {
    private PterodactylTokenType _tokenType;

    public PterodactylApplication Application { get; }
    public PterodactylClient Client { get; }

    public PterodactylApi(string hostname, string token, PterodactylTokenType tokenType) {
        this._tokenType = tokenType;

        this.Application = new PterodactylApplication(hostname, token, tokenType);
        this.Client = new PterodactylClient(hostname, token, tokenType);
    }
}