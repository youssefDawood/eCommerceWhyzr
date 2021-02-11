using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using eCommerceWhyzr.Configuration.Dto;

namespace eCommerceWhyzr.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : eCommerceWhyzrAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
