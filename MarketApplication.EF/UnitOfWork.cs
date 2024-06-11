
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
        Categories = new BaseRepository<Category>(_context);

    }

    public IBaseRepository<Product> Products { get; private set; }
    public IBaseRepository<Category> Categories { get; private set; }

    public async Task<int> Complete() => (await _context.SaveChangesAsync());       
    

    public void Dispose()
    {
        _context.Dispose();
    }
}

