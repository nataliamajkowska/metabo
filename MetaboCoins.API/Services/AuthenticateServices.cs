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
    public class AuthenticateServices
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private readonly UserDbServices _userDbServices;
        public AuthenticateServices(IConfiguration configuration, AppDbContext context)
        {
            _context = context;
            _configuration = configuration;
            _userDbServices = new UserDbServices(context);
        }
        public async Task<BaseResponse> Login(string login, string password)
        {
            try
            {
                var userId = await _userDbServices.Login(login, password);
                if (userId != Guid.Empty)
                {
                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                    var tokenToWrite = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],

                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(30),
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)

                        );
                    var token = new JwtSecurityTokenHandler().WriteToken(tokenToWrite);
                    var userInformation = await _userDbServices.GetBaseInformation(userId);
                    var userResponse = new UserResponse
                    {
                        UserId = userId,
                        Token = token,
                        Name = userInformation.Name,
                        StoreName = userInformation.StoreName,
                        Email = userInformation.Email,
                        PhoneNumber = userInformation.PhoneNumber
                    };
                    return new BaseResponse { 
                        Status = "Success",
                        Message = "LoginSuccessfull",
                        Obj = userResponse
                    };
                }
                return new BaseResponse
                {
                    Status = "Error",
                    Message = "WrongLoginOrPassword"
                };
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
