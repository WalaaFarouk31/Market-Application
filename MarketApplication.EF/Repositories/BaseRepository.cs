using MarketApplication.Core.Services;
using MarketApplication.EF.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace MarketApplication.EF.Repositories;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<T> AddNew(T entity)
    {
       await _context.AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> Criteria)
    {
        return await _context.Set<T>().Where(Criteria).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public Task Update(T entity)
    {
        throw new NotImplementedException();
    }
}

