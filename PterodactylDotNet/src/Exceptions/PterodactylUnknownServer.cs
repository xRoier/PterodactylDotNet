namespace PterodactylDotNet.Exceptions;

public class PterodactylUnknownServer : Exception {
    public PterodactylUnknownServer(int serverId) : 
        base("An unknown serverId was specified. serverId = " + serverId) {}
    
    public PterodactylUnknownServer(string serverId) : 
        base("An unknown serverId was specified. serverId = " + serverId) {}
}