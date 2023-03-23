using System.Threading.Tasks;
using LinhKienDienTu.Configuration.Dto;

namespace LinhKienDienTu.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
