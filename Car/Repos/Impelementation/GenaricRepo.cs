using Car.Data;
using Car.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Car.Repos.Impelementation
{
    public class GenaricRepo<T> : IGenaricRepo<T> where T : class
    {
        private readonly AppDbcontext _context;
        public DbSet<T> db;
        public GenaricRepo(AppDbcontext appDbcontext)
        {
            _context = appDbcontext;
            db = _context.Set<T>();
        }
        public async Task Create(T enet)
        {
            await db.AddAsync(enet);
        }

        public void Delet(int id)
        {
            var x = db.Find(id);
            if (x != null)
            {
                db.Remove(x);
            }
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await db.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await db.FindAsync(id);
        }

        public void Update(T ent)
        {
            db.Update(ent);
        }
    }
}
