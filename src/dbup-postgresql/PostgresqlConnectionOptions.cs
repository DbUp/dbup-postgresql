using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace DbUp.Postgresql
{
    /// <summary>
    /// Options that will be applied on the created connection
    /// </summary>
    public class PostgresqlConnectionOptions
    {
        /// <summary>
        /// Certificate for securing connection.
        /// </summary>
        public X509Certificate2 ClientCertificate { get; set; }

        /// <summary>
        //  Custom handler to verify the remote SSL certificate.
        //  Ignored if Npgsql.NpgsqlConnectionStringBuilder.TrustServerCertificate is set.
        /// </summary>
        public RemoteCertificateValidationCallback UserCertificateValidationCallback { get; set; }
    }
}
