using DbUp.Builder;
using DbUp.Tests.Common;

namespace DbUp.Postgresql.Tests;

public class DatabaseSupportTests : DatabaseSupportTestsBase
{
    public DatabaseSupportTests() : base()
    {
        AppContext.SetSwitch("Npgsql.EnableSqlRewriting", true);
    }

    protected override UpgradeEngineBuilder DeployTo(SupportedDatabases to)
        => to.PostgresqlDatabase("");

    protected override UpgradeEngineBuilder AddCustomNamedJournalToBuilder(UpgradeEngineBuilder builder, string schema, string tableName)
        => builder.JournalTo(
            (connectionManagerFactory, logFactory)
                => new PostgresqlTableJournal(connectionManagerFactory, logFactory, schema, tableName)
        );
}
