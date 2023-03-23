using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LinhKienDienTu.Authorization.Roles;
using LinhKienDienTu.Authorization.Users;
using LinhKienDienTu.MultiTenancy;

namespace LinhKienDienTu.EntityFrameworkCore
{
    public class LinhKienDienTuDbContext : AbpZeroDbContext<Tenant, Role, User, LinhKienDienTuDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public LinhKienDienTuDbContext(DbContextOptions<LinhKienDienTuDbContext> options)
            : base(options)
        {
        }
    }
}
