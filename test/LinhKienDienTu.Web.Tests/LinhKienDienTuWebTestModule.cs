using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LinhKienDienTu.EntityFrameworkCore;
using LinhKienDienTu.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace LinhKienDienTu.Web.Tests
{
    [DependsOn(
        typeof(LinhKienDienTuWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class LinhKienDienTuWebTestModule : AbpModule
    {
        public LinhKienDienTuWebTestModule(LinhKienDienTuEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LinhKienDienTuWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(LinhKienDienTuWebMvcModule).Assembly);
        }
    }
}