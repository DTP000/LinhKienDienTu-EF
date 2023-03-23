using Abp.AutoMapper;
using LinhKienDienTu.Roles.Dto;
using LinhKienDienTu.Web.Models.Common;

namespace LinhKienDienTu.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
