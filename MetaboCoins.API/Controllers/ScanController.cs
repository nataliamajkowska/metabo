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
    public class ScanController : ControllerBase
    {
        private readonly ScanServices _scanServices;

        public ScanController(AppDbContext context)
        {
            _scanServices = new ScanServices(context);
        }

        [HttpPost]
        [Route("addScanResult")]
        [Authorize]
        public async Task<BaseResponse> AddScanResult([FromBody] ScanResponse model)
        {
            try
            {
                var itemInfo = await _scanServices.AddScanResult(model.UserId, model.ProductType, model.SerialNumber);
                return itemInfo;
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
        [HttpPost]
        [Route("getScanStatusList")]
        [Authorize]
        public async Task<BaseResponse> GetScanStatusList([FromBody] ScanResponse model)
        {
            try
            {
                var scanStatusList = await _scanServices.GetScanStatusList(model.UserId, model.SkipRecords);
                return scanStatusList;
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
