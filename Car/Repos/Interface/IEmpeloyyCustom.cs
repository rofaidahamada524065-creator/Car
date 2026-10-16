using Car.DTOs.Sale;
using Car.Model;

namespace Car.Repos.Interface
{
    public interface IEmpeloyyCustom:IGenaricRepo<Employee>
    {
        Task<ICollection<CountSale>> sales_count();
    }
}
