using MetaboCoins.Helpers.Response;
using System.Threading.Tasks;

namespace MetaboCoins.Services
{
    public class AuthenticateServices : ApiServices
    {
        public async Task<string> Login(string login, string password)
        {
            var model = new LoginResponse
            {
                Login = login,
                Password = password
            };

            var response = await GetResponse("authenticate/login", model, false);
            return await CheckApiResponseObject(response);
        }
    }
}
