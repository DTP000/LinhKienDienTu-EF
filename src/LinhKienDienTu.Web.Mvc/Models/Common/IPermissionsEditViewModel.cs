using System.Collections.Generic;
using LinhKienDienTu.Roles.Dto;

namespace LinhKienDienTu.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}