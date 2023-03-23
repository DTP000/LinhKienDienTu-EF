using System.Collections.Generic;
using LinhKienDienTu.Roles.Dto;

namespace LinhKienDienTu.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
