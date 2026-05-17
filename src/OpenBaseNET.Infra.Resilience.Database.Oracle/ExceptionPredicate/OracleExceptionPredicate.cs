using Oracle.ManagedDataAccess.Client;

namespace OpenBaseNET.Infra.Resilience.Database.Oracle.ExceptionPredicate;

internal static class OracleExceptionPredicate
{
    internal static bool ShouldRetryOn(OracleException exception)
    {
        return exception.Number switch
        {
            DeadlockDetected
                or ResourceBusy
                or SnapshotTooOld
                or EndOfFileCommunication
                or NotConnected
                or ConnectTimeout
                or NoListener
                or HostUnreachable
                or ConnectionClosed
                or InitializationOrShutdown
                or OracleNotAvailable
                or ImmediateShutdown
                or ShutdownInProgress
                or ProtocolAdapterError
                or PacketWriterFailure
                or ArchiverStuck => true,
            _ => false
        };
    }

    #region constantes

    // Deadlock / concurrency
    private const int DeadlockDetected = 60;       // ORA-00060
    private const int ResourceBusy = 54;            // ORA-00054
    private const int SnapshotTooOld = 1555;        // ORA-01555

    // Connection lost
    private const int EndOfFileCommunication = 3113; // ORA-03113
    private const int NotConnected = 3114;           // ORA-03114
    private const int ConnectionClosed = 12537;      // ORA-12537
    private const int PacketWriterFailure = 12571;   // ORA-12571
    private const int ProtocolAdapterError = 12560;  // ORA-12560

    // Network / listener
    private const int ConnectTimeout = 12170;        // ORA-12170
    private const int NoListener = 12541;            // ORA-12541
    private const int HostUnreachable = 12543;       // ORA-12543

    // Shutdown / maintenance
    private const int InitializationOrShutdown = 1033; // ORA-01033
    private const int OracleNotAvailable = 1034;        // ORA-01034
    private const int ImmediateShutdown = 1089;         // ORA-01089
    private const int ShutdownInProgress = 1090;        // ORA-01090

    // Resources
    private const int ArchiverStuck = 257;          // ORA-00257

    #endregion constantes
}
