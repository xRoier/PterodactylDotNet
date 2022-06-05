namespace PterodactylDotNet.Exceptions;

public class PterodactylUnknownBackup : Exception {
    public PterodactylUnknownBackup(string backupId) : 
        base("An unknown backupId was specified. backupId = " + backupId) {}
}