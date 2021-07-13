using System.Threading.Tasks;
using CBMscGAuth.Code.AuthMethods.Models;
using Types.gAuth;

namespace CBMscGAuth.Code.AuthMethods
{
    public interface IAuthService
    {
        public Task<TokenDto> Login(LoginQuery command, LoginMethod method);
    }
}