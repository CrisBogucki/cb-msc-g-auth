using System.Threading.Tasks;
using CBMscGAuth.Services.AuthMethods.Models;
using Messages.gAuth;

namespace CBMscGAuth.Services.AuthMethods
{
    public interface IAuthService
    {
        public Task<UserModel> Login(LoginQuery command, LoginMethod method);
    }
}