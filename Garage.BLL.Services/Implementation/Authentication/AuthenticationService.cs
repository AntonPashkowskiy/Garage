using Garage.BLL.Services.Interfaces.Authentication;
using System;
using System.Threading.Tasks;

namespace Garage.BLL.Services.Implementation.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<bool> IsUserAuthenticated()
        {
            throw new NotImplementedException();
        }

        public void SignInAsync()
        {
            throw new NotImplementedException();
        }

        public void SignOutAsync()
        {
            throw new NotImplementedException();
        }

        public void SignUpAsync()
        {
            throw new NotImplementedException();
        }
    }
}
