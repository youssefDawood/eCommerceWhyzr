using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using eCommerceWhyzr.Authorization;

namespace eCommerceWhyzr
{
    [DependsOn(
        typeof(eCommerceWhyzrCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class eCommerceWhyzrApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<eCommerceWhyzrAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(eCommerceWhyzrApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
