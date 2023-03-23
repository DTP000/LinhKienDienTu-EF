using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LinhKienDienTu.EntityFrameworkCore
{
    public static class LinhKienDienTuDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LinhKienDienTuDbContext> builder, string connectionString)
        {
            var serverVersion = new MySqlServerVersion(new Version(5, 7, 33));
            //var serverVersion = ServerVersion.AutoDetect(connectionString);
            builder.UseMySql(connectionString, serverVersion);
        }

        public static void Configure(DbContextOptionsBuilder<LinhKienDienTuDbContext> builder, DbConnection connection)
        {
            var serverVersion = new MySqlServerVersion(new Version(5, 7, 33));
            builder.UseMySql(connection, serverVersion);
        }
    }
}
