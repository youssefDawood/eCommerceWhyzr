using System.Threading.Tasks;
using Abp.Application.Services;
using eCommerceWhyzr.Authorization.Accounts.Dto;

namespace eCommerceWhyzr.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
