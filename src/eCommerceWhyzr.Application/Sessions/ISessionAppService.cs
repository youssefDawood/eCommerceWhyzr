using System.Threading.Tasks;
using Abp.Application.Services;
using eCommerceWhyzr.Sessions.Dto;

namespace eCommerceWhyzr.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
