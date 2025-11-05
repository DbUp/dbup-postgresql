using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DbUp.Engine.Transactions;
using Npgsql;

namespace DbUp.Postgresql;

/// <summary>
/// Manages PostgreSQL database connections.
/// </summary>
public class PostgresqlConnectionManager : DatabaseConnectionManager
{
    /// <summary>
    /// Disallow single quotes to be escaped with a backslash (\')
    /// </summary>
    public bool StandardConformingStrings { get; set; } = true;
    
    /// <summary>
    /// Creates a new PostgreSQL database connection.
    /// </summary>
    /// <param name="connectionString">The PostgreSQL connection string.</param>
    public PostgresqlConnectionManager(string connectionString)
        : base(new DelegateConnectionFactory(l => new NpgsqlConnection(connectionString)))
    {
    }

    /// <summary>
    /// Creates a new PostgreSQL database connection with a certificate.
    /// </summary>
    /// <param name="connectionString">The PostgreSQL connection string.</param>
    /// <param name="certificate">Certificate for securing connection.</param>
    public PostgresqlConnectionManager(string connectionString, X509Certificate2 certificate)
        : this(connectionString, new PostgresqlConnectionOptions
        {
            ClientCertificate = certificate
        }) 
    {
    }

    /// <summary>
    /// Create a new PostgreSQL database connection 
    /// </summary>
    /// <param name="connectionString">The PostgreSQL connection string.</param>
    /// <param name="connectionOptions">Custom options to apply on the created connection</param>
    public PostgresqlConnectionManager(string connectionString, PostgresqlConnectionOptions connectionOptions)
        : base(new DataSourceConnectionFactory(connectionString, connectionOptions))
    {
    }

    /// <summary>
    /// Creates a new PostgreSQL database connection with a NpgsqlDatasource
    /// </summary>
    /// <param name="datasource">The PostgreSQL NpgsqlDataSource.</param>
    public PostgresqlConnectionManager(NpgsqlDataSource datasource)
        : base(new DelegateConnectionFactory(l => datasource.CreateConnection()))
    {
    }

    /// <summary>
    /// Splits the statements in the script using the ";" character.
    /// </summary>
    /// <param name="scriptContents">The contents of the script to split.</param>
    public override IEnumerable<string> SplitScriptIntoCommands(string scriptContents)
    {
        var scriptStatements =
            PostgresqlQueryParser.ParseRawQuery(scriptContents, StandardConformingStrings)
                .Select(x => x.Trim())
                .Where(x => x.Length > 0)
                .ToArray();

        return scriptStatements;
    }
}
