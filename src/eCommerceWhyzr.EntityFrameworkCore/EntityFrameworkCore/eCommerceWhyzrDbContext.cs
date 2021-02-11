using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using eCommerceWhyzr.Authorization.Roles;
using eCommerceWhyzr.Authorization.Users;
using eCommerceWhyzr.MultiTenancy;

namespace eCommerceWhyzr.EntityFrameworkCore
{
    public class eCommerceWhyzrDbContext : AbpZeroDbContext<Tenant, Role, User, eCommerceWhyzrDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public eCommerceWhyzrDbContext(DbContextOptions<eCommerceWhyzrDbContext> options)
            : base(options)
        {
        }
    }
}
