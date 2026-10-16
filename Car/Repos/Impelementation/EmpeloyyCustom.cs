using Car.Data;
using Car.DTOs.Sale;
using Car.Model;
using Car.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Car.Repos.Impelementation
{
    public class EmpeloyyCustom : GenaricRepo<Employee>, IEmpeloyyCustom
    {
        private readonly AppDbcontext _context;
        public EmpeloyyCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _context = appDbcontext;
        }

        public async Task<ICollection<CountSale>> sales_count()
        {
            return await _context.Employees.Include(a => a.sales).Select(a => new CountSale
            {
                Id = a.Id,
                FullName = a.FullName,
                Position = a.Position,
                Email = a.Email,
                Phone = a.Phone,
                HireDate = a.HireDate,
                countSale = a.sales.Count()
            }).OrderByDescending(a=>a.countSale).ToListAsync();
        }
    }
}
