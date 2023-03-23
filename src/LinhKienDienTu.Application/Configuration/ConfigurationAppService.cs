using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using LinhKienDienTu.Configuration.Dto;

namespace LinhKienDienTu.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LinhKienDienTuAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
