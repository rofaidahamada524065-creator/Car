using Car.Data;
using Car.DTOs.Catigory;
using Car.Model;
using Car.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Car.Repos.Impelementation
{
    public class CatigoryCustom : GenaricRepo<Category>, ICatigoryCustom
    {
        private readonly AppDbcontext _context;
        public CatigoryCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _context = appDbcontext;
        }

        public async Task<ICollection<CatigoryWithVehclNumberDTO>> GetAllWithcountVehicle()
        {
            return await _context.Categories.Include(a => a.vehicles).Select(a => new CatigoryWithVehclNumberDTO
            {
                Id = a.Id,
                Name = a.Name,
                Discreption = a.Discreption,
                Vehiclecount = a.vehicles.Count()

            }).ToListAsync();

            
        }
    }
}
