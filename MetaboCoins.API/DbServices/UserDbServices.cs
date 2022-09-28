using MetaboCoins.API.Authentication;
using MetaboCoins.API.Helpers.Response;
using MetaboCoins.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MetaboCoins.API.DbServices
{
    public class UserDbServices
    {
        private readonly AppDbContext _context;
        public UserDbServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Login(string login, string password)
        {
            try
            {
                var user = new UserModel();
                var userId = (from u in _context.Users
                              where u.Login == login && u.Password == password
                              select u.Id
                              ).FirstOrDefault();
                return userId;
            }
            catch
            {
                return Guid.Empty;
            }
        }
        public async Task<MetaboCoinsInformationResponse> GetMetaboCoinsInformation(Guid userId)
        {
            try
            {
                var metaboCoinsInformationResponse = (from u in _context.Users
                                    where u.Id == userId
                                    from store in _context.StoreBranches
                                    where u.StoreBranchId == store.Id
                                    select new MetaboCoinsInformationResponse
                                    {
                                        MetaboCoins = u.MetaboCoins,
                                        MetaboCoinsForSettlement = u.MetaboCoinsForSettlement,
                                        MetaboCoinsCleared = u.MetaboCoinsCleared,
                                        TurnoverThreshold = store.TurnoverThreshold,
                                        Turnover = store.Turnover
                                    }).FirstOrDefault();
                return metaboCoinsInformationResponse;
            }
            catch
            {
                return null;
            }
        }
        public async Task<UserResponse> GetBaseInformation(Guid userId)
        {
            try
            {
                var userResponse = (from u in _context.Users
                                    where u.Id == userId
                                    select new UserResponse
                                    {
                                        Name = u.Name + " " + u.LastName,
                                        Email = u.Email,
                                        StoreName = u.StoreName,
                                        PhoneNumber = u.PhoneNumber,
                                    }).FirstOrDefault();
                return userResponse;
            }
            catch
            {
                return null;
            }
        }
    }
}
