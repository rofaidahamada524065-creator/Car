namespace Car.Repos.Interface
{
    public interface IGenaricRepo<T> where T :class
    {
        void Delet(int id);
        void Update(T ent);
        Task Create(T enet);
        Task<T> GetById(int id);
        Task<ICollection<T>> GetAll();
    }
}
