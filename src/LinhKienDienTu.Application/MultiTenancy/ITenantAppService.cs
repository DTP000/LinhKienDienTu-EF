using Abp.Application.Services;
using LinhKienDienTu.MultiTenancy.Dto;

namespace LinhKienDienTu.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

