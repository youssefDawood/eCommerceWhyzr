using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using eCommerceWhyzr.Authorization.Roles;
using eCommerceWhyzr.Authorization.Users;
using eCommerceWhyzr.MultiTenancy;
using eCommerceWhyzr.Domain.Attributes;
using eCommerceWhyzr.Domain.Products;

namespace eCommerceWhyzr.EntityFrameworkCore
{
    public class eCommerceWhyzrDbContext : AbpZeroDbContext<Tenant, Role, User, eCommerceWhyzrDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<InfoInAnotherLanguage> InfoInAnotherLanguages { get; set; }

        public eCommerceWhyzrDbContext(DbContextOptions<eCommerceWhyzrDbContext> options)
            : base(options)
        {
        }
    }
}
