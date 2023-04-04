using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LinhKienDienTu.Authorization.Roles;
using LinhKienDienTu.Authorization.Users;
using LinhKienDienTu.MultiTenancy;
using LinhKienDienTu.Entity;

namespace LinhKienDienTu.EntityFrameworkCore
{
    public class LinhKienDienTuDbContext : AbpZeroDbContext<Tenant, Role, User, LinhKienDienTuDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public LinhKienDienTuDbContext(DbContextOptions<LinhKienDienTuDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>(entity => { entity.HasIndex(p => p.Name); });
            builder.Entity<Product>(entity => { entity.HasIndex(p => p.Name); });

            builder.Entity<Image>(entity => { entity.HasIndex(p => p.Url); });
            builder.Entity<Order>(entity => { entity.HasIndex(p => p.Name).IsUnique(); });
            builder.Entity<OrderDetail>().HasOne(c => c.Order).WithMany(t => t.OrderDetails).OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
