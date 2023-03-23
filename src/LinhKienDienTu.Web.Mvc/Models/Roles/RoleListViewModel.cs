using System.Collections.Generic;
using LinhKienDienTu.Roles.Dto;

namespace LinhKienDienTu.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
