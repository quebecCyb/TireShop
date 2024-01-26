using AutoMapper;
using System.Linq.Expressions;
using TireShop.Repository.Interface;
using TireShop.Service.Interfaces;

namespace TireShop.Service
{
    public class CrudService<T> : ICrudService<T> where T : class
    {
        protected readonly IRepository<T> _repository;
        protected readonly IMapper _mapper;

        public CrudService(IRepository<T> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _repository.Get(predicate);
        }
        public virtual T GetOne(Expression<Func<T, bool>> predicate)
        {
            return _repository.GetOne(predicate);
        }

        public virtual T? GetOneOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _repository.GetOneOrDefault(predicate);
        }

        public virtual T GetById(object id)
        {
            return _repository.GetById(id);
        }

        public virtual T Create(T entity)
        {
            _repository.Add(entity);
            return entity;
        }

        public virtual T Update(T entity)
        {
            _repository.Update(entity);
            return entity;
        }

        public virtual void Delete(object id)
        {
            _repository.Delete(id);
        }

        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public virtual bool Exists(Expression<Func<T, bool>> predicate)
        {
            return _repository.Exists(predicate);
        }

        public virtual bool Exists(object id)
        {
            return _repository.Exists(id);
        }
    }
}
