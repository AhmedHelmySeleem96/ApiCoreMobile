using ApiCoreMobile.Data;
using ApiCoreMobile.IRepository;
using ApiCoreMobile.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

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
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(500, "there Is An Error");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMobile(int Id)
        {
            try
            {
                var mob = await _unitOfWork.Mobile.Get(d => d.Id == Id, new List<string> { "category" });
                var result = _mapper.Map<MobileDto>(mob);
                return Ok(result);

            }
            catch (Exception)
            {

                return StatusCode(500, "category has Some Errors in Get Mobile");

            }
        }
        [HttpPost]
        public async Task<IActionResult> AddMobile([FromForm] MobileDto mob)
        {
            try
            {
                var mobile = _mapper.Map<Mobiles>(mob);
                await _unitOfWork.Mobile.insert(mobile);
                await _unitOfWork.Save();
                return Ok();

            }
            catch (Exception)
            {
                return StatusCode(500, "Failed to add mobile.");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMobile(int Id)
        {
            try
            {
                var Mob = await _unitOfWork.Mobile.Get(x => x.Id == Id);
                if (Mob == null)
                {
                    return NotFound();
                }
                await _unitOfWork.Mobile.Delete(Id);
                await _unitOfWork.Save();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Failed to Delete mobile .");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMobile(int Id, MobileDto Mob)
        {
            try
            {
                var _mob = await _unitOfWork.Mobile.Get(x => x.Id == Id);
                if (_mob == null)
                {
                    return NotFound();
                }
                _mapper.Map(Mob, _mob);
                _unitOfWork.Mobile.update(_mob);
                await _unitOfWork.Save();
                var UpdatedMobile = _mapper.Map<MobileDto>(_mob);
                return Ok(UpdatedMobile);
            }
            catch (Exception)
            {

                return StatusCode(500, "There was an error while updating the mobile phone.");

            }

        }
    }
}
