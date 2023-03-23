using Abp.Authorization;
using LinhKienDienTu.Authorization.Roles;
using LinhKienDienTu.Authorization.Users;

namespace LinhKienDienTu.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
