using ApiCoreMobile.Data;
using ApiCoreMobile.Models;
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
        //private readonly SignInManager<ApiUser> _signInManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApiUser> userManager/*, SignInManager<ApiUser> signInManager*/, IMapper mapper)
        {
            _userManager = userManager;
            //_signInManager = signInManager;
            _mapper = mapper;
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

        //[HttpPost]
        //[Route("Login")]

        //public async Task<IActionResult> Login([FromBody] LoginDto LoginDto)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    try
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(LoginDto.Password, LoginDto.Email, false, false);
        //        if (!result.Succeeded) return Unauthorized(LoginDto);
        //        return Accepted(result);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "There Is An Error In Registeration Process");
        //    }
        //}
    }
}
