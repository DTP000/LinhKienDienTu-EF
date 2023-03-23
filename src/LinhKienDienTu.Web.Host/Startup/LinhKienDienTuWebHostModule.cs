using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LinhKienDienTu.Configuration;

namespace LinhKienDienTu.Web.Host.Startup
{
    [DependsOn(
       typeof(LinhKienDienTuWebCoreModule))]
    public class LinhKienDienTuWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LinhKienDienTuWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LinhKienDienTuWebHostModule).GetAssembly());
        }
    }
}
