using MetaboCoins.API.Authentication;
using MetaboCoins.API.Helpers.Response;
using MetaboCoins.API.Model;
using MetaboCoins.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetaboCoins.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userServices;

        public UserController(AppDbContext context)
        {
            _userServices = new UserServices(context);
        }

        [HttpPost]
        [Route("getMetaboCoinsInformation")]
        [Authorize]
        public async Task<BaseResponse> GetMetaboCoinsInformation([FromBody] BaseResponse model)
        {
            try
            {
                var loginRespone = await _userServices.GetMetaboCoinsInformation(model.Id);
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
