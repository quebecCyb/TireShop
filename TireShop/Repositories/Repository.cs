using Microsoft.EntityFrameworkCore;
using TireShop.Exceptions;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using TireShop.Entities;
using TireShop.Repository.Interface;

namespace TireShop.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class 
    {

        protected ApplicationDbContext Context { get; }

        public Repository(ApplicationDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Read Queries

        // Метод для получения всех объектов типа T
        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }


        protected IQueryable<T> CreateQuery(
            Expression<Func<T, bool>>? filter = null,
            string includeProperties = "",
            string? orderBy = null,
            bool? isDescending = false,
            Expression<Func<T, T>>? selectedColumns = null
        )
        {
            IQueryable<T> query = Context.Set<T>();
            if (selectedColumns != null)
                query = query.Select(selectedColumns);


            // Apply the filter predicate if specified
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Include related entities if specified
            // if (selectedColumns == null)
            foreach (var includeProperty in includeProperties.Split
                (new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries))
            {
                // Include the base property
                query = query.Include(includeProperty);
            }

            // Apply sorting if specified
            if (!string.IsNullOrEmpty(orderBy))
            {
                // Use System.Linq.Dynamic.Core to perform dynamic ordering
                query = query.OrderBy(orderBy + (isDescending ?? false ? " descending" : ""));
            }

            return query;
        }

        public IEnumerable<T> Get(
            Expression<Func<T, bool>>? filter = null,
            int pageNumber = 1,
            int pageSize = 10,
            string includeProperties = "",
            string? orderBy = null,
            bool? isDescending = false,
            Expression<Func<T, T>>? selectedColumns = null
        ) {
            return CreateQuery(filter, includeProperties, orderBy, isDescending, selectedColumns)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
         }


        public T? GetOneOrDefault(
            Expression<Func<T, bool>>? filter = null,
            int pageNumber = 1,
            int pageSize = 10,
            string includeProperties = "",
            string? orderBy = null,
            bool? isDescending = false,
            Expression<Func<T, T>>? selectedColumns = null
        )
        {
            return CreateQuery(filter, includeProperties, orderBy, isDescending, selectedColumns)
                .FirstOrDefault();
        }


        // Метод для получения объекта по его идентификатору
        public virtual T? GetByIdOrDefault(object id)
        {
            return Context.Set<T>().Find(id);
        }

        // Метод для получения объекта по его идентификатору
        public virtual T GetById(object id)
        {
            return GetByIdOrDefault(id) ?? throw new NotFound($"Entity {typeof(T).Name} not found");
        }

        public virtual T? GetOneOrDefault(
            Expression<Func<T, bool>>? filter = null
        )
        {
            if (filter == null) return null;
            return Context.Set<T>().FirstOrDefault(filter);
        }

        // Метод для получения объекта по его идентификатору
        public virtual T GetOne(
            Expression<Func<T, bool>> filter
        ) {
            return GetOneOrDefault(filter) ?? throw new NotFound($"Entity {typeof(T).Name} not found");
        }

        // Execute commands
        // Метод для добавления нового объекта в базу данных
        public virtual void Add(T entity)
        {
            try
            {
                Context.Set<T>().Add(entity);
                Context.SaveChanges();
            } catch(DbUpdateException ex)
            {
                throw new BadGateway($"DB error: " + ex.ToString());
            }
        }

        // Метод для обновления существующего объекта в базе данных
        public virtual void Update(T entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new BadGateway($"DB error: {e.Message}");
            }
        }

        // Метод для удаления объекта из базы данных
        public virtual void Delete(object id)
        {
            T entityToDelete = Context.Set<T>().Find(id) ?? throw new NotFound($"Entity {typeof(T).Name} not found");
            Delete(entityToDelete);
        }

        public virtual void Delete(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Context.Set<T>().Attach(entity);
            }
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }


        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Any(predicate);
        }

        public bool Exists(object id)
        {
            return Context.Set<T>().Find(id) != null;
        }
    }
}
