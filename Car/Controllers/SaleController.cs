using AutoMapper;
using Car.DTOs.Sale;
using Car.DTOs.Vehicles;
using Car.Model;
using Car.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _map;
        public SaleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repo = unitOfWork;
            _map = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdatSaleDTO dto)
        {
            var x = await _repo.vehicle.GetById(dto.VehicleId);
            if (x == null)
            {
                return BadRequest("the vehcle Not Found");
            }
            if (x.Status!= "Available")
            {
                return BadRequest("This Vehicle Not Available");
            }
            
           
            if (dto == null)
            {
                return BadRequest("Enter data");
            }
            var xx = _map.Map<Sale>(dto);
            await _repo.sale.Create(xx);
            x.Status = "Sold";

            await _repo.SaveChangeAsync();
            return Ok();
        }
        //[HttpGet]
        //public async Task<IActionResult> GetallAvilable()
        //{
        //    var x = await _repo.vehicle.available();
        //    var list = _map.Map<List<Vehicle_DTO>>(x);
        //    return Ok(list);
        //}

        [HttpPut]
        public async Task<IActionResult> Update(CreateUpdatSaleDTO dto, int id)
        {
            var x = await _repo.sale.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
           
            x.SalePrice = dto.SalePrice;
            x.SaleDate = dto.SaleDate;
            x.Note = dto.Note;
            x.PaymentMethod = dto.PaymentMethod;
            x.VehicleId = dto.VehicleId;
            x.EmployeeId = dto.EmployeeId;
            x.CustomerId = dto.CustomerId;
           

            await _repo.SaveChangeAsync();

            return Ok(dto);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var x = await _repo.sale.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            var d = await _repo.vehicle.GetById(x.VehicleId);
            if (d != null)
            {
                d.Status = "Available";
            }
            
            _repo.sale.Delet(id);
            await _repo.SaveChangeAsync();
            return NoContent();
        }
    }
}
