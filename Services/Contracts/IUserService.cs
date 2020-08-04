using E_Commerce.InputModels;
using System.Threading.Tasks;

namespace E_Commerce.Services.Contracts
{
    public interface IUserService
    {
        string Register(UserRegistrationModel registerUser);

        string Login(UserLoginModel userLoginModel);

        void Logout();
    }
}
