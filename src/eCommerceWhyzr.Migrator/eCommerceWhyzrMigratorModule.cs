using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using eCommerceWhyzr.Configuration;
using eCommerceWhyzr.EntityFrameworkCore;
using eCommerceWhyzr.Migrator.DependencyInjection;

namespace eCommerceWhyzr.Migrator
{
    [DependsOn(typeof(eCommerceWhyzrEntityFrameworkModule))]
    public class eCommerceWhyzrMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public eCommerceWhyzrMigratorModule(eCommerceWhyzrEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(eCommerceWhyzrMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                eCommerceWhyzrConsts.ConnectionStringName
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
            IocManager.RegisterAssemblyByConvention(typeof(eCommerceWhyzrMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
