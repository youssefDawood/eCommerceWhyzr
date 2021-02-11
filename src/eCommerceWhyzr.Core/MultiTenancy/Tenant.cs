using Abp.MultiTenancy;
using eCommerceWhyzr.Authorization.Users;

namespace eCommerceWhyzr.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
