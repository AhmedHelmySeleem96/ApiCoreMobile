using ApiCoreMobile.Data;
using ApiCoreMobile.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiCoreMobile.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IMapper _mapper;
        private  ApiUser _user;
        private readonly IConfiguration _configuration;

        public AuthManager(UserManager<ApiUser> userManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetsigningCredentials();
            var claims = await GetClaims();
            var Token = GenerateToken(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }

        private JwtSecurityToken GenerateToken(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var Expired = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("Expired").Value)); 
            var Token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: Expired,
                signingCredentials:signingCredentials
                );
            return Token; 
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,_user.UserName)
            };
            var Roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in Roles)
            {
                claims.Add(new Claim (ClaimTypes.Role,role));
            }
            return claims;
        }

        private SigningCredentials GetsigningCredentials()
        {
            var key = Environment.GetEnvironmentVariable("Key");
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            return new SigningCredentials(secret,SecurityAlgorithms.HmacSha256);
        }

        //public async Task<bool> ValidateUser(LoginDto userDto)
        //{
        //    _user = await _userManager.FindByNameAsync(userDto.Email);
        //    return (_user != null && await _userManager.CheckPasswordAsync(_user, userDto.Password));
        //    _user = await _userManager.FindByNameAsync(userDto.Email);
        //    var validPassword = await _userManager.CheckPasswordAsync(_user, userDto.Password);
        //    return (_user != null /*&& validPassword*/);
        //}
        public async Task<bool> ValidateUser(LoginDto userDto)
        {
            _user = await _userManager.FindByNameAsync(userDto.Email);
            var validPassword = (_user != null) ? await _userManager.CheckPasswordAsync(_user, userDto.Password) : false;
            return (validPassword);
        }
    }
}
