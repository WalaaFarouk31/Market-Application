using System.Linq.Expressions;
namespace MarketApplication.Core.Services;

public interface IBaseRepository<T> where T:class
{
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> Get(Expression<Func<T,bool>> Criteria);
    Task<T> AddNew(T entity);
    Task Update(T entity);  
}

