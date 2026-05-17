using OpenBaseNET.Infra.Resilience.Core.Pipelines;
using OpenBaseNET.Infra.Resilience.Database.Oracle.ExceptionPredicate;
using Oracle.ManagedDataAccess.Client;
using Polly;

namespace OpenBaseNET.Infra.Resilience.Database.Oracle.Pipelines;

public static class DatabasePipeline
{
    public static readonly ResiliencePipeline AsyncRetryPipeline =
        BasePipeline<OracleException>.GetAsyncRetryPipeline(OracleExceptionPredicate.ShouldRetryOn);
}
