using AutoMapper;
using Car.DTOs.Customer;
using Car.DTOs.Vehicles;
using Car.Model;
using Car.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customer_Controller : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _map;
        public Customer_Controller(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repo = unitOfWork;
            _map = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UpdateCreateCustomerDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Enter data");
            }
            var customer = new Customer
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                DriverLicenseNumber=dto.DriverLicenseNumber,
                customerProfile=new CustomerProfile
                {
                    Address=dto.Address,
                    City=dto.City,
                    Nationality=dto.Nationality,
                    DateOfBirth=dto.DateOfBirth
                }
            };
            await _repo.customer.Create(customer);
            await _repo.SaveChangeAsync();
            return Ok(customer);
        }
        [HttpGet]
        public async Task<IActionResult> GetallAvilable(int custid)
        {
            var x = await _repo.customer.Details(custid);
           
            return Ok(x);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCreateCustomerDTO dto, int id)
        {
            var x = await _repo.customer.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            x.FullName = dto.FullName;
            x.Email = dto.Email;
            x.Phone = dto.Phone;
            x.DriverLicenseNumber = dto.DriverLicenseNumber;

            x.customerProfile.Address = dto.Address;
            x.customerProfile.City = dto.City;
            x.customerProfile.Nationality = dto.Nationality;


            await _repo.SaveChangeAsync();

            return Ok(x);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var x = await _repo.customer.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            _repo.customer.Delet(id);
            await _repo.SaveChangeAsync();
            return NoContent();
        }
    }
}
