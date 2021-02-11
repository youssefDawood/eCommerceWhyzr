using Abp.AutoMapper;
using eCommerceWhyzr.Authentication.External;

namespace eCommerceWhyzr.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
