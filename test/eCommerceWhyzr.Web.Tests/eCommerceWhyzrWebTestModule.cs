using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using eCommerceWhyzr.EntityFrameworkCore;
using eCommerceWhyzr.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace eCommerceWhyzr.Web.Tests
{
    [DependsOn(
        typeof(eCommerceWhyzrWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class eCommerceWhyzrWebTestModule : AbpModule
    {
        public eCommerceWhyzrWebTestModule(eCommerceWhyzrEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(eCommerceWhyzrWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(eCommerceWhyzrWebMvcModule).Assembly);
        }
    }
}