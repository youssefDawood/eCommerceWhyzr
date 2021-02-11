using System.Threading.Tasks;
using eCommerceWhyzr.Configuration.Dto;

namespace eCommerceWhyzr.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
