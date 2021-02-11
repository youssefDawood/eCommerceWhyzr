using Abp.Application.Services.Dto;

namespace eCommerceWhyzr.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

