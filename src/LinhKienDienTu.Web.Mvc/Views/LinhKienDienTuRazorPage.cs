using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace LinhKienDienTu.Web.Views
{
    public abstract class LinhKienDienTuRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected LinhKienDienTuRazorPage()
        {
            LocalizationSourceName = LinhKienDienTuConsts.LocalizationSourceName;
        }
    }
}
