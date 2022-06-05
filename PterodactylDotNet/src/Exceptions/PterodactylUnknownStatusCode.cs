namespace PterodactylDotNet.Exceptions;

public class PterodactylUnknownStatusCode : Exception {
    public PterodactylUnknownStatusCode(int statusCode) : 
        base("An unknown status code was received. StatusCode = " + statusCode) {}
}