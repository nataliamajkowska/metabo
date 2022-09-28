using MetaboCoins.Helpers.Response;
using System;
using System.Threading.Tasks;

namespace MetaboCoins.Services
{
    public class UserServices : ApiServices
    {
        public async Task<string> GetMetaboCoinsInformation(Guid userId)
        {
            var model = new BaseResponse
            {
                Id = userId
            };

            var response = await GetResponse("user/getMetaboCoinsInformation", model, true);
            return await CheckApiResponseObject(response);
        }
    }
}
