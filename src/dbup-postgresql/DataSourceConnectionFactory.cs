using System;
using System.Data;
using DbUp.Engine.Output;
using DbUp.Engine.Transactions;
using Npgsql;

namespace DbUp.Postgresql;

/// <summary>
/// A connection factory that uses Npgsql's data source pattern to create PostgreSQL database connections.
/// This factory provides better performance and resource management compared to traditional connection strings
/// by reusing configured data sources and connection pooling.
/// </summary>
internal class DataSourceConnectionFactory : IConnectionFactory
{

    private readonly NpgsqlDataSource dataSource;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataSourceConnectionFactory"/> class.
    /// </summary>
    /// <param name="connectionString">The PostgreSQL connection string used to configure the data source.</param>
    /// <param name="connectionOptions">Additional connection options including SSL certificate configuration.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="connectionString"/> or <paramref name="connectionOptions"/> is null.</exception>
    /// <exception cref="System.ArgumentException">Thrown when <paramref name="connectionString"/> is empty or invalid.</exception>
    public DataSourceConnectionFactory(string connectionString, PostgresqlConnectionOptions connectionOptions)
    {
        if (connectionString == null)
        {
            throw new ArgumentNullException(nameof(connectionString));
        }
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException("Connection string cannot be empty.", nameof(connectionString));
        }
        if (connectionOptions == null)
        {
            throw new ArgumentNullException(nameof(connectionOptions));
        }
        var builder = new NpgsqlDataSourceBuilder(connectionString);
        
#if NET8_0_OR_GREATER
        // Use the new SSL authentication callback API for .NET 8.0 with Npgsql 9
        if (connectionOptions.ClientCertificate != null || connectionOptions.UserCertificateValidationCallback != null)
        {
            builder.UseSslClientAuthenticationOptionsCallback(options =>
            {
                if (connectionOptions.ClientCertificate != null)
                {
                    options.ClientCertificates = new System.Security.Cryptography.X509Certificates.X509CertificateCollection
                    {
                        connectionOptions.ClientCertificate
                    };
                }
                if (connectionOptions.UserCertificateValidationCallback != null)
                {
                    options.RemoteCertificateValidationCallback = connectionOptions.UserCertificateValidationCallback;
                }
            });
        }
#else
        // Use legacy API for netstandard2.0 with Npgsql 8
        if (connectionOptions.ClientCertificate != null)
        {
            builder.UseClientCertificate(connectionOptions.ClientCertificate);
        }
        if (connectionOptions.UserCertificateValidationCallback != null)
        {
            builder.UseUserCertificateValidationCallback(connectionOptions.UserCertificateValidationCallback);
        }
#endif
        dataSource = builder.Build();
    }

    /// <summary>
    /// Creates a new database connection using the configured data source.
    /// </summary>
    /// <param name="upgradeLog">The upgrade log for recording connection-related messages. This parameter is not used in this implementation.</param>
    /// <param name="databaseConnectionManager">The database connection manager. This parameter is not used in this implementation.</param>
    /// <returns>A new <see cref="IDbConnection"/> instance ready for use.</returns>
    /// <remarks>
    /// The returned connection is not automatically opened. The caller is responsible for opening and properly disposing of the connection.
    /// The connection benefits from the data source's connection pooling and configuration reuse.
    /// </remarks>
    public IDbConnection CreateConnection(IUpgradeLog upgradeLog, DatabaseConnectionManager databaseConnectionManager) => dataSource.CreateConnection();

    /// <summary>
    /// Creates a new database connection using the configured data source.
    /// Simpler implementation of <see cref="CreateConnection(IUpgradeLog, DatabaseConnectionManager)"/>  for internal use. 
    /// </summary>
    /// <returns>A new <see cref="IDbConnection"/> instance ready for use.</returns>
    internal NpgsqlConnection CreateConnection() => dataSource.CreateConnection();
}
