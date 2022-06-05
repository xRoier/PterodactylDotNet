namespace PterodactylDotNet.Exceptions;

public class PterodactylUnableToDeletePrimaryAllocation : Exception {
    public PterodactylUnableToDeletePrimaryAllocation(string allocationId) : 
        base("Unable t o delete primary allocation for the server. allocationId = " + allocationId) {}
}