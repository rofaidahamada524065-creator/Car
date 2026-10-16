using Car.Data;
using Car.DTOs.Customer;
using Car.Model;
using Car.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Car.Repos.Impelementation
{
    public class CustomerCustom : GenaricRepo<Customer>, ICustomerRepo
    {
        private readonly AppDbcontext _context;
        public CustomerCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _context = appDbcontext;
        }

        public async Task<historyandmoney?> Details(int CustomerID)
        {
            return await _context.Customers.Include(a => a.customerProfile).Include(a => a.sales).ThenInclude(a => a.vehicle).Where(a => a.Id == CustomerID).Select(a => new historyandmoney
            {
                Id = a.Id,
                FullName = a.FullName,
                Email = a.Email,

                Phone=a.Phone,
                DriverLicenseNumber=a.DriverLicenseNumber,
                Address = a.customerProfile.Address,
                City = a.customerProfile.City,
                Nationality = a.customerProfile.Nationality,
                TotalVehicles = a.sales.Count(),
                MoneySpent = a.sales.Sum(a => a.SalePrice)

            }).FirstOrDefaultAsync();
        }
    }
}
