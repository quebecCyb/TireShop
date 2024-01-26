using System.Linq.Expressions;

namespace TireShop.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetOne(Expression<Func<T, bool>> predicate);
        T? GetOneOrDefault(Expression<Func<T, bool>> predicate);

        IEnumerable<T> Get(
            Expression<Func<T, bool>>? filter = null,
            int pageNumber = 1,
            int pageSize = 10,
            string includeProperties = "",
            string? orderBy = null,
            bool? isDescending = false,
            Expression<Func<T, T>>? selectedColumns = null
        );

        T? GetOneOrDefault(
            Expression<Func<T, bool>>? filter = null,
            int pageNumber = 1,
            int pageSize = 10,
            string includeProperties = "",
            string? orderBy = null,
            bool? isDescending = false,
            Expression<Func<T, T>>? selectedColumns = null
        );

        T GetById(object id);
        T? GetByIdOrDefault(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(object id);
        void Delete(T entity);

        bool Exists(Expression<Func<T, bool>> predicate);
        bool Exists(object id);
    }
}
