using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using eCommerceWhyzr.EntityFrameworkCore.Seed;

namespace eCommerceWhyzr.EntityFrameworkCore
{
    [DependsOn(
        typeof(eCommerceWhyzrCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class eCommerceWhyzrEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<eCommerceWhyzrDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        eCommerceWhyzrDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        eCommerceWhyzrDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(eCommerceWhyzrEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
