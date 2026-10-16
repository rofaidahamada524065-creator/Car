using Car.Data;
using Car.Model;
using Car.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Car.Repos.Impelementation
{
    public class VehicleCustom : GenaricRepo<Vehicle>, IVehicleCustom
    {
        private readonly AppDbcontext _context;
        public VehicleCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _context = appDbcontext;
        }

        public async Task<ICollection<Vehicle>> available()
        {
            return await _context.Vehicles.Include(a => a.category).Where(a => a.Status == "available ").OrderByDescending(a => a.Year).ThenBy(a => a.Price).ToListAsync();
        }
    }
}
