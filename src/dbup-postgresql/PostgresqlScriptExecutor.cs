﻿using System;
using System.Collections.Generic;
using DbUp.Engine;
using DbUp.Engine.Output;
using DbUp.Engine.Transactions;
using DbUp.Support;
using Npgsql;

namespace DbUp.Postgresql;

/// <summary>
/// An implementation of <see cref="ScriptExecutor"/> that executes against a PostgreSQL database.
/// </summary>
public class PostgresqlScriptExecutor : ScriptExecutor
{
    /// <summary>
    /// Initializes an instance of the <see cref="PostgresqlScriptExecutor"/> class.
    /// </summary>
    /// <param name="connectionManagerFactory"></param>
    /// <param name="log">The logging mechanism.</param>
    /// <param name="schema">The schema that contains the table.</param>
    /// <param name="variablesEnabled">Function that returns <c>true</c> if variables should be replaced, <c>false</c> otherwise.</param>
    /// <param name="scriptPreprocessors">Script Preprocessors in addition to variable substitution</param>
    /// <param name="journalFactory">Database journal</param>
    public PostgresqlScriptExecutor(Func<IConnectionManager> connectionManagerFactory, Func<IUpgradeLog> log, string schema, Func<bool> variablesEnabled,
        IEnumerable<IScriptPreprocessor> scriptPreprocessors, Func<IJournal> journalFactory)
        : base(connectionManagerFactory, new PostgresqlObjectParser(), log, schema, variablesEnabled, scriptPreprocessors, journalFactory)
    {
    }

    protected override string GetVerifySchemaSql(string schema) => $"CREATE SCHEMA IF NOT EXISTS {schema}";

    protected override void ExecuteCommandsWithinExceptionHandler(int index, SqlScript script, Action executeCommand)
    {
        try
        {
            executeCommand();
        }
        catch (PostgresException exception)
        {
            Log().LogInformation("Npgsql exception has occurred in script: '{0}'", script.Name);
            Log().LogError("Script block number: {0}; Block line {1}; Position: {2}; Message: {3}", index, exception.Line, exception.Position, exception.Message);
            Log().LogError(exception.ToString());
            throw;
        }
    }
}