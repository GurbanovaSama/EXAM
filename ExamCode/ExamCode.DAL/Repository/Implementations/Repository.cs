using ExamCode.DAL.Contexts;
using ExamCode.DAL.Models;
using ExamCode.DAL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ExamCode.DAL.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }



        public DbSet<T> Table =>_context.Set<T>();      

        public async  Task CreateAsync(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow.AddHours(4);
            await Table.AddAsync(entity);     
        }

        public void Delete(T entity)
        {
           Table.Remove(entity);    
        }

     

        public async Task<ICollection<T>> GetAllAsync(params string[] includes)
        {
            IQueryable<T> query = Table;

            if(includes.Length > 0)
            {
                foreach(string include in includes)
                {
                    query = query.Include(include);     
                }
            }

            return await query.ToListAsync();       
        }



        public Task<T?> GetByIdAsync(int id, params string[] includes)
        {
            IQueryable<T> query = Table;

            if (includes.Length > 0)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.SingleOrDefaultAsync(x=>x.Id == id);           
        }

        public async Task<int> SaveChangeAsync()=> await _context.SaveChangesAsync();           

        public void Update(T entity)
        {
            entity.UpdatedAt = DateTime.UtcNow.AddHours(4);
            Table.Update(entity);   
        }
    }
}
