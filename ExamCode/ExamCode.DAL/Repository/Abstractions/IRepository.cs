using ExamCode.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamCode.DAL.Repository.Abstractions;

public interface IRepository<T> where T : BaseEntity, new()        
{
     DbSet<T> Table { get; }

    Task<ICollection<T>> GetAllAsync(params string[] includes);
    Task<T?> GetByIdAsync(int id, params string[] includes);
    Task<int> SaveChangeAsync();
    Task CreateAsync(T entity); 
    void Update(T entity);     
    void Delete (T entity); 
}
