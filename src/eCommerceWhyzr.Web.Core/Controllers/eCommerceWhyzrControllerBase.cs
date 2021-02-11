using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace eCommerceWhyzr.Controllers
{
    public abstract class eCommerceWhyzrControllerBase: AbpController
    {
        protected eCommerceWhyzrControllerBase()
        {
            LocalizationSourceName = eCommerceWhyzrConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
