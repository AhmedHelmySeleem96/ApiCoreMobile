using ApiCoreMobile.Data;
using ApiCoreMobile.Models;
using ApiCoreMobile.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public AccountController(UserManager<ApiUser> userManager, IMapper mapper,IAuthManager authManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _authManager = authManager;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]UserDto userDto )
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
               var user = _mapper.Map<ApiUser>(userDto);
                user.UserName = userDto.Email;
                user.PasswordHash = userDto.Password;
                if (user == null) return BadRequest(ModelState);
                var result = await _userManager.CreateAsync(user);
                if (!result.Succeeded) return BadRequest($"Registeratio Is Atempt Failed ({result.Errors.FirstOrDefault().Description})");
                await _userManager.AddToRolesAsync(user, userDto.Roles);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "There Is An Error In Registeration Process");
            }
        }

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] LoginDto LoginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                if (! await _authManager.ValidateUser(LoginDto))
                {
                    return Unauthorized();
                }
                return Accepted(new { Token = await _authManager.CreateToken() });

            }
            catch (Exception)
            {
                throw;
                return StatusCode(500, "There Is An Error In Registeration Process");
            }
        }
    }
}
