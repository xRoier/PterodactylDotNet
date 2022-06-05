namespace PterodactylDotNet.Exceptions;

public class PterodactylServerOffline : Exception {
    public PterodactylServerOffline(string serverId) : 
        base("The specified server is offline. serverId = " + serverId) {}
}