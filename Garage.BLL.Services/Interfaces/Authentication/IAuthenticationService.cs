using System.Threading.Tasks;

namespace Garage.BLL.Services.Interfaces.Authentication
{
    public interface IAuthenticationService: IBusinessLogicLayerService
    {
        void SignInAsync();
        void SignUpAsync();
        void SignOutAsync();
        Task<bool> IsUserAuthenticated();
    }
}
