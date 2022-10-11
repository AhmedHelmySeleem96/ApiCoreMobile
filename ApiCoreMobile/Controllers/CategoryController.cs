using ApiCoreMobile.Data;
using ApiCoreMobile.IRepository;
using ApiCoreMobile.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace ApiCoreMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var category = await _unitOfWork.Catrgories.GetAll();

                var result = _mapper.Map<IList<CategoryDto>>(category);
                return Ok(category);
            }
            catch (Exception Ex)
            {

                return StatusCode(500, "there Is An Error");
            }
            
        }
        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetCategorie(int Id)
        {
            try
            {
                var Category = await _unitOfWork.Catrgories.Get(q=>q.Id== Id,new List<string> { "mobile" });
                var category = _mapper.Map<CategoryDto>(Category);
                
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "category has Some Errors in GetCategorie");
                
            }
        }

    }
}
