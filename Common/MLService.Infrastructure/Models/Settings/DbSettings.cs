using MLService.Enums.Enums;
using MLService.Infrastructure.Interfaces.Settings;

namespace MLService.Infrastructure.Models.Settings
{
    public class DbSettings : IDbSettings
    {
        public virtual DatabaseType DbType {
            get
            {
                if (string.IsNullOrEmpty(ConnectionString))
                    return DatabaseType.Undefined;

                if (ConnectionString.StartsWith("Data Source"))
                    return DatabaseType.SqlServer;

                if (ConnectionString.StartsWith("Server"))
                    return DatabaseType.PgSql;

                return DatabaseType.Undefined;
            }
        }

        public virtual string ConnectionString { get; set; }
    }
}
