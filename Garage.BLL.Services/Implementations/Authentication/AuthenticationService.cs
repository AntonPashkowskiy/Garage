using Garage.BLL.Services.Interfaces.Authentication;
using Garage.BLL.Services.Models.Authentication;
using System.Threading.Tasks;

namespace Garage.BLL.Services.Implementations.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool IsUserAuthenticated()
        {
            return false;
        }

        public Task SignInAsync(SignInModel model)
        {
            return Task.Run(() => { });
        }

        public Task SignOutAsync()
        {
            return Task.Run(() => { });
        }

        public Task SignUpAsync(SignUpModel model)
        {
            return Task.Run(() => { });
        }
    }
}
