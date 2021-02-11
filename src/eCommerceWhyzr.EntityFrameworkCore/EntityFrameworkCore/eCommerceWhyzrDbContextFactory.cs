using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using eCommerceWhyzr.Configuration;
using eCommerceWhyzr.Web;

namespace eCommerceWhyzr.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class eCommerceWhyzrDbContextFactory : IDesignTimeDbContextFactory<eCommerceWhyzrDbContext>
    {
        public eCommerceWhyzrDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<eCommerceWhyzrDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            eCommerceWhyzrDbContextConfigurer.Configure(builder, configuration.GetConnectionString(eCommerceWhyzrConsts.ConnectionStringName));

            return new eCommerceWhyzrDbContext(builder.Options);
        }
    }
}
