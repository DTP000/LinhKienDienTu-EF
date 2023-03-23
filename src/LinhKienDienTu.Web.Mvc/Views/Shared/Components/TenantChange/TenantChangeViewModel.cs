using Abp.AutoMapper;
using LinhKienDienTu.Sessions.Dto;

namespace LinhKienDienTu.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
