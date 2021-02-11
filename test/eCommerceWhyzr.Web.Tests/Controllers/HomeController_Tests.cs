using System.Threading.Tasks;
using eCommerceWhyzr.Models.TokenAuth;
using eCommerceWhyzr.Web.Controllers;
using Shouldly;
using Xunit;

namespace eCommerceWhyzr.Web.Tests.Controllers
{
    public class HomeController_Tests: eCommerceWhyzrWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}