using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LinhKienDienTu.Configuration;

namespace LinhKienDienTu.Web.Startup
{
    [DependsOn(typeof(LinhKienDienTuWebCoreModule))]
    public class LinhKienDienTuWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LinhKienDienTuWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<LinhKienDienTuNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LinhKienDienTuWebMvcModule).GetAssembly());
        }
    }
}
