using System.Collections.Generic;

namespace eCommerceWhyzr.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
