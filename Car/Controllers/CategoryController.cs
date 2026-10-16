using AutoMapper;
using Car.DTOs.Catigory;
using Car.DTOs.Vehicles;
using Car.Model;
using Car.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _map;
        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repo = unitOfWork;
            _map = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateCatigoryDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Enter data");
            }
            var x = _map.Map<Category>(dto);
            await _repo.category.Create(x);
            await _repo.SaveChangeAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetallAvilable()
        {
            var x = await _repo.category.GetAllWithcountVehicle();
          
            return Ok(x);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CreateUpdateCatigoryDTO dto, int id)
        {
            var x = await _repo.category.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            x.Name = dto.Name;
            x.Discreption = dto.Discreption;
           

            await _repo.SaveChangeAsync();

            return Ok(dto);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var x = await _repo.category.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            _repo.category.Delet(id);
            await _repo.SaveChangeAsync();
            return Ok();
        }
    }
}
