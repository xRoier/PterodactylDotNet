namespace PterodactylDotNet.Exceptions;

public class PterodactylUnknownLocation : Exception {
    public PterodactylUnknownLocation(int locationId) : 
        base("An unknown locationId was specified. locationId = " + locationId) {}
}