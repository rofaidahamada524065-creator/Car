using Car.DTOs.Customer;
using Car.Model;

namespace Car.Repos.Interface
{
    public interface ICustomerRepo:IGenaricRepo<Customer>
    {
        Task<historyandmoney?> Details(int CustomerID);
    }
}
