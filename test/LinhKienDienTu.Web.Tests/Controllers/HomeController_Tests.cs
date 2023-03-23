using System.Threading.Tasks;
using LinhKienDienTu.Models.TokenAuth;
using LinhKienDienTu.Web.Controllers;
using Shouldly;
using Xunit;

namespace LinhKienDienTu.Web.Tests.Controllers
{
    public class HomeController_Tests: LinhKienDienTuWebTestBase
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