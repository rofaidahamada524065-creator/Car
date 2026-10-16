using Car.DTOs.Catigory;
using Car.Model;

namespace Car.Repos.Interface
{
    public interface ICatigoryCustom:IGenaricRepo<Category>
    {
        Task<ICollection<CatigoryWithVehclNumberDTO>> GetAllWithcountVehicle();
    }
}
