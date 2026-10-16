using AutoMapper;
using Car.DTOs.Customer;
using Car.DTOs.Employee;
using Car.Model;
using Car.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpeloyyController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _map;
        public EmpeloyyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repo = unitOfWork;
            _map = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateEmpellyDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Enter data");
            }
            var x = _map.Map<Employee>(dto);
            await _repo.empeloyy.Create(x);
            await _repo.SaveChangeAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetallAvilable()
        {
            var x = await _repo.empeloyy.sales_count();

            return Ok(x);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CreateUpdateEmpellyDTO dto, int id)
        {
            var x = await _repo.empeloyy.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            x.FullName = dto.FullName;
            x.Position = dto.Position;
            x.Email = dto.Email;
            x.HireDate = dto.HireDate;
            x.Phone = dto.Phone;


            await _repo.SaveChangeAsync();

            return Ok(x);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var x = await _repo.empeloyy.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            _repo.empeloyy.Delet(id);
            await _repo.SaveChangeAsync();
            return NoContent();
        }
    }
}
