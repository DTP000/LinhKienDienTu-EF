using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LinhKienDienTu.Authorization;

namespace LinhKienDienTu
{
    [DependsOn(
        typeof(LinhKienDienTuCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class LinhKienDienTuApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<LinhKienDienTuAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(LinhKienDienTuApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
