using System.Linq.Expressions;

namespace TireShop.Service.Interfaces
{
    public interface ICrudService<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        T GetOne(Expression<Func<T, bool>> predicate);
        T? GetOneOrDefault(Expression<Func<T, bool>> predicate);

        T GetById(object id);
        T Create(T entity);
        T Update(T entity);
        void Delete(object id);
        void Delete(T entity);
        bool Exists(object id);
    }
}
