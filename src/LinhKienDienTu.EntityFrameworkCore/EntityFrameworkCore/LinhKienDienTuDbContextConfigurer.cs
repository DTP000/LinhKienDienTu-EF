using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LinhKienDienTu.EntityFrameworkCore
{
    public static class LinhKienDienTuDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LinhKienDienTuDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LinhKienDienTuDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
