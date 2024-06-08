
using MarketApplication.Core.Models;
using MarketApplication.Core.Services;
using MarketApplication.EF.Data;
using MarketApplication.EF.Repositories;

namespace MarketApplication.EF;
public class UnitOfWork:IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Products=new BaseRepository<Product>(_context);
    }

    public IBaseRepository<Product> Products { get;}
    public IBaseRepository<Category> Categories { get; }

    public Task<int> Complete => _context.SaveChangesAsync();

    public void Dispose()
    {
        _context.Dispose();
    }
}

