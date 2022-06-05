namespace PterodactylDotNet.Exceptions;

public class PterodactylUnknownUser : Exception {
    public PterodactylUnknownUser(int userId) : 
        base("An unknown userId was specified. userId = " + userId) {}
}