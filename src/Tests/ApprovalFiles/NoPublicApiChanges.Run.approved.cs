[assembly: System.CLSCompliant(false)]
[assembly: System.Reflection.AssemblyMetadata("RepositoryUrl", "https://github.com/DbUp/dbup-postgresql.git")]
[assembly: System.Runtime.InteropServices.ComVisible(false)]
[assembly: System.Runtime.InteropServices.Guid("5ddc04cc-0bd3-421e-9ae4-9fd0e4f4ef04")]
[assembly: System.Runtime.Versioning.TargetFramework(".NETCoreApp,Version=v8.0", FrameworkDisplayName=".NET 8.0")]
public static class PostgresqlExtensions
{
    public static DbUp.Builder.UpgradeEngineBuilder JournalToPostgresqlTable(this DbUp.Builder.UpgradeEngineBuilder builder, string schema, string table) { }
    public static DbUp.Builder.UpgradeEngineBuilder PostgresqlDatabase(DbUp.Engine.Transactions.IConnectionManager connectionManager) { }
    public static DbUp.Builder.UpgradeEngineBuilder PostgresqlDatabase(this DbUp.Builder.SupportedDatabases supported, DbUp.Engine.Transactions.IConnectionManager connectionManager) { }
    public static DbUp.Builder.UpgradeEngineBuilder PostgresqlDatabase(this DbUp.Builder.SupportedDatabases supported, string connectionString) { }
    public static DbUp.Builder.UpgradeEngineBuilder PostgresqlDatabase(DbUp.Engine.Transactions.IConnectionManager connectionManager, string schema) { }
    public static void PostgresqlDatabase(this DbUp.SupportedDatabasesForDropDatabase supported, string connectionString) { }
    public static void PostgresqlDatabase(this DbUp.SupportedDatabasesForEnsureDatabase supported, string connectionString) { }
    public static DbUp.Builder.UpgradeEngineBuilder PostgresqlDatabase(this DbUp.Builder.SupportedDatabases supported, string connectionString, string schema) { }
    public static void PostgresqlDatabase(this DbUp.SupportedDatabasesForDropDatabase supported, string connectionString, DbUp.Engine.Output.IUpgradeLog logger) { }
    public static void PostgresqlDatabase(this DbUp.SupportedDatabasesForDropDatabase supported, string connectionString, DbUp.Postgresql.PostgresqlConnectionOptions connectionOptions) { }
    public static void PostgresqlDatabase(this DbUp.SupportedDatabasesForDropDatabase supported, string connectionString, System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { }
    public static void PostgresqlDatabase(this DbUp.SupportedDatabasesForEnsureDatabase supported, string connectionString, DbUp.Engine.Output.IUpgradeLog logger) { }
    public static void PostgresqlDatabase(this DbUp.SupportedDatabasesForEnsureDatabase supported, string connectionString, DbUp.Postgresql.PostgresqlConnectionOptions connectionOptions) { }
    public static void PostgresqlDatabase(this DbUp.SupportedDatabasesForEnsureDatabase supported, string connectionString, System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { }
    public static DbUp.Builder.UpgradeEngineBuilder PostgresqlDatabase(this DbUp.Builder.SupportedDatabases supported, string connectionString, string schema, DbUp.Postgresql.PostgresqlConnectionOptions connectionOptions) { }
    public static DbUp.Builder.UpgradeEngineBuilder PostgresqlDatabase(this DbUp.Builder.SupportedDatabases supported, string connectionString, string schema, System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { }
    public static void PostgresqlDatabase(this DbUp.SupportedDatabasesForDropDatabase supported, string connectionString, DbUp.Engine.Output.IUpgradeLog logger, DbUp.Postgresql.PostgresqlConnectionOptions connectionOptions) { }
    public static void PostgresqlDatabase(this DbUp.SupportedDatabasesForDropDatabase supported, string connectionString, DbUp.Engine.Output.IUpgradeLog logger, System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { }
    public static void PostgresqlDatabase(this DbUp.SupportedDatabasesForEnsureDatabase supported, string connectionString, DbUp.Engine.Output.IUpgradeLog logger, DbUp.Postgresql.PostgresqlConnectionOptions connectionOptions) { }
    public static void PostgresqlDatabase(this DbUp.SupportedDatabasesForEnsureDatabase supported, string connectionString, DbUp.Engine.Output.IUpgradeLog logger, System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { }
}
namespace DbUp.Postgresql
{
    public class PostgresqlConnectionManager : DbUp.Engine.Transactions.DatabaseConnectionManager
    {
        public PostgresqlConnectionManager(Npgsql.NpgsqlDataSource datasource) { }
        public PostgresqlConnectionManager(string connectionString) { }
        public PostgresqlConnectionManager(string connectionString, DbUp.Postgresql.PostgresqlConnectionOptions connectionOptions) { }
        public PostgresqlConnectionManager(string connectionString, System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { }
        public bool StandardConformingStrings { get; set; }
        public override System.Collections.Generic.IEnumerable<string> SplitScriptIntoCommands(string scriptContents) { }
    }
    public class PostgresqlConnectionOptions
    {
        public PostgresqlConnectionOptions() { }
        public System.Security.Cryptography.X509Certificates.X509Certificate2 ClientCertificate { get; set; }
        public string MasterDatabaseName { get; set; }
        public System.Net.Security.RemoteCertificateValidationCallback UserCertificateValidationCallback { get; set; }
    }
    public class PostgresqlObjectParser : DbUp.Support.SqlObjectParser
    {
        public PostgresqlObjectParser() { }
    }
    public class PostgresqlPreprocessor : DbUp.Engine.IScriptPreprocessor
    {
        public PostgresqlPreprocessor() { }
        public string Process(string contents) { }
    }
    public class PostgresqlScriptExecutor : DbUp.Support.ScriptExecutor
    {
        public PostgresqlScriptExecutor(System.Func<DbUp.Engine.Transactions.IConnectionManager> connectionManagerFactory, System.Func<DbUp.Engine.Output.IUpgradeLog> log, string schema, System.Func<bool> variablesEnabled, System.Collections.Generic.IEnumerable<DbUp.Engine.IScriptPreprocessor> scriptPreprocessors, System.Func<DbUp.Engine.IJournal> journalFactory) { }
        protected override void ExecuteCommandsWithinExceptionHandler(int index, DbUp.Engine.SqlScript script, System.Action executeCommand) { }
        protected override string GetVerifySchemaSql(string schema) { }
    }
    public class PostgresqlTableJournal : DbUp.Support.TableJournal
    {
        public PostgresqlTableJournal(System.Func<DbUp.Engine.Transactions.IConnectionManager> connectionManager, System.Func<DbUp.Engine.Output.IUpgradeLog> logger, string schema, string tableName) { }
        protected override string CreateSchemaTableSql(string quotedPrimaryKeyName) { }
        protected override string GetInsertJournalEntrySql(string scriptName, string applied) { }
        protected override System.Data.IDbCommand GetInsertScriptCommand(System.Func<System.Data.IDbCommand> dbCommandFactory, DbUp.Engine.SqlScript script) { }
        protected override string GetJournalEntriesSql() { }
    }
}