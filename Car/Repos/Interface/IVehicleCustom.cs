using Car.Model;

namespace Car.Repos.Interface
{
    public interface IVehicleCustom:IGenaricRepo<Vehicle>
    {
        Task<ICollection<Vehicle>> available();
    }
}
