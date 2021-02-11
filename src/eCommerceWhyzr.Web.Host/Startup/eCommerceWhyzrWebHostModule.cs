using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using eCommerceWhyzr.Configuration;

namespace eCommerceWhyzr.Web.Host.Startup
{
    [DependsOn(
       typeof(eCommerceWhyzrWebCoreModule))]
    public class eCommerceWhyzrWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public eCommerceWhyzrWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(eCommerceWhyzrWebHostModule).GetAssembly());
        }
    }
}
