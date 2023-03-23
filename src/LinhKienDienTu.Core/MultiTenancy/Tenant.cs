using Abp.MultiTenancy;
using LinhKienDienTu.Authorization.Users;

namespace LinhKienDienTu.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
