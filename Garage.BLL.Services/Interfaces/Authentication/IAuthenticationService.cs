using Garage.BLL.Services.Models.Authentication;
using System.Threading.Tasks;

namespace Garage.BLL.Services.Interfaces.Authentication
{
    public interface IAuthenticationService: IBusinessLogicLayerService
    {
        Task SignInAsync(SignInModel model);
        Task SignUpAsync(SignUpModel model);
        Task SignOutAsync();
        bool IsUserAuthenticated();
    }
}
