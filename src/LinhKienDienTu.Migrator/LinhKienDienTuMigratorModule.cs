using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LinhKienDienTu.Configuration;
using LinhKienDienTu.EntityFrameworkCore;
using LinhKienDienTu.Migrator.DependencyInjection;

namespace LinhKienDienTu.Migrator
{
    [DependsOn(typeof(LinhKienDienTuEntityFrameworkModule))]
    public class LinhKienDienTuMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public LinhKienDienTuMigratorModule(LinhKienDienTuEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(LinhKienDienTuMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                LinhKienDienTuConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LinhKienDienTuMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
