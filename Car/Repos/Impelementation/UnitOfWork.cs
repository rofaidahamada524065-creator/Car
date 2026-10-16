using Car.Data;
using Car.Model;
using Car.Repos.Interface;

namespace Car.Repos.Impelementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbcontext _context;
        public UnitOfWork(AppDbcontext appDbcontext, ICatigoryCustom categoryyyy, IGenaricRepo<CustomerProfile> customerProfaolll, ICustomerRepo customerrr, IGenaricRepo<Sale> saleee,IEmpeloyyCustom empeloyyyy, IVehicleCustom vehicleee)
        {
            _context = appDbcontext;
            category = categoryyyy;
            customerProfaol = customerProfaolll;
            customer = customerrr;
            sale = saleee;
            vehicle = vehicleee;
            empeloyy = empeloyyyy;
        }
        public IVehicleCustom vehicle { get; }

        public IEmpeloyyCustom empeloyy { get; }

        public IGenaricRepo<Sale> sale { get; }

      public   ICustomerRepo customer { get; }

        public IGenaricRepo<CustomerProfile> customerProfaol { get; }

        public ICatigoryCustom category { get; }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
