using System.Collections.Generic;
using System.Data;
using DbUp.Engine.Transactions;

namespace DbUp.Postgresql.Tests;

/// <summary>
/// Test implementation of DatabaseConnectionManager for unit testing.
/// </summary>
public class TestConnectionManager : DatabaseConnectionManager
{
    public TestConnectionManager(IDbConnection connection) 
        : base(new DelegateConnectionFactory(_ => connection))
    {
    }

    public override IEnumerable<string> SplitScriptIntoCommands(string scriptContents)
    {
        yield return scriptContents;
    }
}
