namespace PterodactylDotNet.Exceptions;

public class PterodactylUnauthorized : Exception {
    public PterodactylUnauthorized() : 
        base("You are not authorized to view this resource") {}
}