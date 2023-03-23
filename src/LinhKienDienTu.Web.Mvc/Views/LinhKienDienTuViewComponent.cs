using Abp.AspNetCore.Mvc.ViewComponents;

namespace LinhKienDienTu.Web.Views
{
    public abstract class LinhKienDienTuViewComponent : AbpViewComponent
    {
        protected LinhKienDienTuViewComponent()
        {
            LocalizationSourceName = LinhKienDienTuConsts.LocalizationSourceName;
        }
    }
}
