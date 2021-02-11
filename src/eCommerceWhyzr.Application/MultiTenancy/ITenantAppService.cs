using Abp.Application.Services;
using eCommerceWhyzr.MultiTenancy.Dto;

namespace eCommerceWhyzr.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

