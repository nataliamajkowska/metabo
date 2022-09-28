using MetaboCoins.API.Authentication;
using MetaboCoins.API.Helpers.Response;
using MetaboCoins.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace MetaboCoins.API.DbServices
{
    public class ScanDbServices
    {
        private readonly AppDbContext _context;
        public ScanDbServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ScanItemResponse> AddScanResult(Guid userId, int productTypeId, long serialNumber)
        {
            try
            {
                //Search Item in DB
                var item = (from u in _context.Items
                            where u.ProductId == productTypeId
                            select u).FirstOrDefault();
                if(item != null)
                {
                    //Checking if the item has already been scanned
                    var scanExist = _context.ScanHistories.Any(x => x.ProductId == productTypeId && x.SerialNumber == serialNumber);
                    //Create Scan History
                    var scanHistoryModel = new ScanHistoryModel
                    {
                        UserId = userId,
                        ProductId = productTypeId,
                        SerialNumber = serialNumber,
                        Points = item.Points,
                        AddDate = DateTime.Now,
                        ScanSuccess = scanExist ? false : true
                    };
                    _context.ScanHistories.Add(scanHistoryModel);
                    if (!scanExist)
                    {
                        //Update Metabo Coins in user account
                        var userProfile = (from u in _context.Users
                                           where u.Id == userId
                                           select u).FirstOrDefault();
                        userProfile.MetaboCoins += item.Points;
                        //Update Turnover in store account
                        var storeBranch = (from u in _context.StoreBranches
                                           where u.Id == userProfile.StoreBranchId
                                           select u).FirstOrDefault();
                        storeBranch.Turnover += item.Price;
                    }

                    _context.SaveChanges();
                    return new ScanItemResponse
                    {
                        ProductId = productTypeId,
                        Points = item.Points,
                        Name = item.Name,
                        Image = item.Image,
                        ScanSuccess = scanExist ? false : true
                    };
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<ScanItemResponse>> GetScanStatusList(Guid userId, int skipRecords)
        {
            try
            {
                var scanItemList = (from u in _context.ScanHistories
                                    where u.UserId == userId
                                    join item in _context.Items on u.ProductId equals item.ProductId
                                    orderby u.AddDate descending
                                    select new ScanItemResponse
                                    {
                                        ProductId = item.ProductId,
                                        Points = item.Points,
                                        Name = item.Name,
                                        Image = item.Image,
                                        ScanSuccess = u.ScanSuccess
                                    }).Skip(skipRecords).Take(10).ToList();
                return scanItemList;
            }
            catch
            {
                return null;
            }
        }
    }
}
