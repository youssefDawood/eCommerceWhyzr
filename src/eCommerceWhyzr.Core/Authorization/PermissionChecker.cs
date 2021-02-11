using Abp.Authorization;
using eCommerceWhyzr.Authorization.Roles;
using eCommerceWhyzr.Authorization.Users;

namespace eCommerceWhyzr.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
