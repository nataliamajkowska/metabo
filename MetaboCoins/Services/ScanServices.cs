using MetaboCoins.Helpers.Response;
using System;
using System.Threading.Tasks;

namespace MetaboCoins.Services
{
    public class ScanServices : ApiServices
    {
        public async Task<string> AddScanResult(Guid userId, string productType, string serialNumber)
        {
            var model = new ScanResponse
            {
                UserId = userId,
                ProductType = productType,
                SerialNumber = serialNumber
            };

            var response = await GetResponse("scan/addScanResult", model, true);
            return await CheckApiResponseObject(response);
        }
        public async Task<string> GetScanStatusList(Guid userId, int skipRecords)
        {
            var model = new ScanResponse
            {
                UserId = userId,
                SkipRecords = skipRecords
            };

            var response = await GetResponse("scan/getScanStatusList", model, true);
            return await CheckApiResponseObject(response);
        }
    }
}
