using AutoMapper;
using Car.Data;
using Car.DTOs.Vehicles;
using Car.Model;
using Car.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Vehicle_Controller : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _map;
        public Vehicle_Controller(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _repo = unitOfWork;
            _map = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateVehicle_DTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Enter data");
            }
            var x = _map.Map<Vehicle>(dto);
            await _repo.vehicle.Create(x);
            await _repo.SaveChangeAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetallAvilable()
        {
            var x =await _repo.vehicle.available();
            var list = _map.Map<List<Vehicle_DTO>>(x);
            return Ok(list);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CreateUpdateVehicle_DTO dto,int id)
        {
            var x =await _repo.vehicle.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            x.Make = dto.Make;
            x.Model = dto.Model;
            x.Year = dto.Year;
            x.Color = dto.Color;
            x.Price = dto.Price;
            x.Mileage = dto.Mileage;
            x.VIN = dto.VIN;
            x.FuelType = dto.FuelType;
            x.Transmission = dto.Transmission;
            x.Status = dto.Status;
            x.CatigoryId = dto.CatigoryId;

            await _repo.SaveChangeAsync();

            return Ok(dto);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var x = await _repo.vehicle.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            _repo.vehicle.Delet(id);
          await  _repo.SaveChangeAsync();
            return NoContent();
        }
    }
}
