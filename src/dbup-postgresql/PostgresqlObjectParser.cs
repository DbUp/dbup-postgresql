using DbUp.Support;

namespace DbUp.Postgresql;

/// <summary>
/// Parses Sql Objects and performs quoting functions.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="PostgresqlObjectParser"/> class.
/// </remarks>
public class PostgresqlObjectParser() : SqlObjectParser("\"", "\"");
