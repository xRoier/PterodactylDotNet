namespace PterodactylDotNet.Exceptions;

public class PterodactylUnknownNode : Exception {
    public PterodactylUnknownNode(int nodeId) : 
        base("An unknown nodeId was specified. nodeId = " + nodeId) {}
}