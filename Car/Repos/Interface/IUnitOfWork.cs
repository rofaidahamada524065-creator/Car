using Car.Model;

namespace Car.Repos.Interface
{
    public interface IUnitOfWork
    {
       IVehicleCustom vehicle { get; }
        IEmpeloyyCustom empeloyy { get; }
        IGenaricRepo<Sale> sale { get; }
       ICustomerRepo customer { get; }
        IGenaricRepo<CustomerProfile> customerProfaol { get; }
       ICatigoryCustom category { get; }

        Task<int> SaveChangeAsync();
    }
}
