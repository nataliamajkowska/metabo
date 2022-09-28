using MetaboCoins.API.Authentication;
using MetaboCoins.API.Helpers.Response;
using MetaboCoins.API.Model;
using MetaboCoins.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MetaboCoins.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly AuthenticateServices _authenticateServices;

        public AuthenticateController(IConfiguration configuration, AppDbContext context)
        {
            _authenticateServices = new AuthenticateServices(configuration, context);
        }

        [HttpPost]
        [Route("login")]
        public async Task<BaseResponse> Login([FromBody] LoginResponse model)
        {
            try
            {
                var loginRespone = await _authenticateServices.Login(model.Login, model.Password);
                return loginRespone;
            }
            catch
            {
                return new BaseResponse
                {
                    Status = "InternalError",
                    Message = "StringNoConnectionToTheServer"
                };
            }
        }

    }
}
