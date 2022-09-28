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
    public class ScanServices
    {
        private readonly AppDbContext _context;
        private readonly ScanDbServices _scanDbServices;
        public ScanServices(AppDbContext context)
        {
            _context = context;
            _scanDbServices = new ScanDbServices(context);
        }
        public async Task<BaseResponse> AddScanResult(Guid userId, string productType, string serialNumber)
        {
            try
            {
                var productTypeId = Int32.Parse("6" + productType);
                var itemInfo = await _scanDbServices.AddScanResult(userId, productTypeId, long.Parse(serialNumber));
                if (itemInfo != null && itemInfo.ScanSuccess)
                {
                    return new BaseResponse
                    {
                        Status = "Success",
                        Message = "AddScanSuccessful",
                        Obj = itemInfo
                    };
                }
                else if (itemInfo != null)
                {
                    return new BaseResponse
                    {
                        Status = "Error",
                        Message = "Duplicate"
                    };
                }
                else
                {
                    return new BaseResponse
                    {
                        Status = "Error",
                        Message = "Failed"
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
        public async Task<BaseResponse> GetScanStatusList(Guid userId, int skipRecords)
        {
            try
            {
                var scanStatusList = await _scanDbServices.GetScanStatusList(userId, skipRecords);
                if (scanStatusList != null)
                {
                    return new BaseResponse
                    {
                        Status = "Success",
                        Message = "GetSuccessful",
                        Obj = scanStatusList
                    };
                }
                else
                {
                    return new BaseResponse
                    {
                        Status = "Error",
                        Message = "Duplicate"
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
