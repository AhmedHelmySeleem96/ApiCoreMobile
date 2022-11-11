using ApiCoreMobile.Data;
using ApiCoreMobile.IRepository;
using ApiCoreMobile.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiCoreMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly IMapper? _mapper;

        public MobileController(IUnitOfWork unitOfWork, IMapper? mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetMobiles()
        {
            try
            {
                var mob = await _unitOfWork?.Mobile.GetAll();
                var result = _mapper.Map<IList<MobileDto>>(mob);
                return Ok(mob);
            }
            catch (Exception)
            {

                return StatusCode(500, "there Is An Error");
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetMobile(int Id)
        {
            try
            {
                var mob = await _unitOfWork.Mobile.Get(d => d.Id == Id,new List<string> { "category" });
                var result = _mapper.Map<MobileDto>(mob);
                return Ok(mob);

            }
            catch (Exception)
            {

                return StatusCode(500, "category has Some Errors in Get Mobile");

            }
        }
    }
}
