#if !NETCORE
using DbUp.Tests.Common;

namespace DbUp.Postgresql.Tests;

public class NoPublicApiChanges : NoPublicApiChangesBase
{
    public NoPublicApiChanges()
        : base(typeof(PostgresqlExtensions).Assembly)
    {
    }
}
#endif
