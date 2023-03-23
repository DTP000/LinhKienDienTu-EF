using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace LinhKienDienTu.Controllers
{
    public abstract class LinhKienDienTuControllerBase: AbpController
    {
        protected LinhKienDienTuControllerBase()
        {
            LocalizationSourceName = LinhKienDienTuConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
