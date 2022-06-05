namespace PterodactylDotNet.Exceptions;

public class PterodactylUnknownAllocation : Exception {
    public PterodactylUnknownAllocation(int allocationId) : 
        base("An unknown allocationId was specified. allocationId = " + allocationId) {}
}