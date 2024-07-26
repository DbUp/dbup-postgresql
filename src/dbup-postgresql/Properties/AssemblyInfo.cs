using System;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]

#if (NETSTANDARD2_0_OR_GREATER  || NET462_OR_GREATER)
// Npgsql is not CLS compliant and PostgresqlConnectionManager exposes types like NpgsqlDataSource
[assembly: CLSCompliant(false)]
#else
[assembly: CLSCompliant(true)]
#endif

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("5ddc04cc-0bd3-421e-9ae4-9fd0e4f4ef04")]
