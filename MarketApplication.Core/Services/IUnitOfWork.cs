using MarketApplication.Core.Models;
namespace MarketApplication.Core.Services;

public interface IUnitOfWork:IDisposable
{
    IBaseRepository<Product> Products { get;  }
    IBaseRepository<Category> Categories { get; }
    Task<int> Complete { get; }
   
}

