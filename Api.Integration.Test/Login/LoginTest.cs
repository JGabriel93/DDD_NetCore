using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.Login
{
    public class LoginTest : BaseIntegration
    {
        [Fact(DisplayName = "Mantida a integridade para realizar login")]
        public async Task TestLogin()
        {
            await CreateToken();
        }
    }
}
