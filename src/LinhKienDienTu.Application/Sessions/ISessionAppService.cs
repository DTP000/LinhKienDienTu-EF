using System.Threading.Tasks;
using Abp.Application.Services;
using LinhKienDienTu.Sessions.Dto;

namespace LinhKienDienTu.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
