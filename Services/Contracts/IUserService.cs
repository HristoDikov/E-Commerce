using E_Commerce.InputModels;
using System.Threading.Tasks;

namespace E_Commerce.Services.Contracts
{
    public interface IUserService
    {
        void Register(UserRegistrationModel registerUser);

        void Login(UserLoginModel userLoginModel);

        void Logout();
    }
}
