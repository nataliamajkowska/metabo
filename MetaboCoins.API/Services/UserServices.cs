using MetaboCoins.API.Authentication;
using MetaboCoins.API.DbServices;
using MetaboCoins.API.Helpers.Response;
using MetaboCoins.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MetaboCoins.API.Services
{
    public class UserServices
    {
        private readonly AppDbContext _context;
        private readonly UserDbServices _userDbServices;
        public UserServices(AppDbContext context)
        {
            _context = context;
            _userDbServices = new UserDbServices(context);
        }
        public async Task<BaseResponse> GetMetaboCoinsInformation(Guid userId)
        {
            try
            {
                var metaboCoinsInformationResponse = await _userDbServices.GetMetaboCoinsInformation(userId);
                if(metaboCoinsInformationResponse != null)
                {
                    return new BaseResponse
                    {
                        Status = "Success",
                        Message = "GetUserDataSuccessfull",
                        Obj = metaboCoinsInformationResponse
                    };
                }
                else
                {
                    return new BaseResponse
                    {
                        Status = "Error",
                        Message = "StringNoData"
                    };
                }
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
