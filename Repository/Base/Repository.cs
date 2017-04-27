using System;
using Repository.Interfaces;
using System.Data.Entity;
using Repository.Exceptions;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace Repository.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {

        private readonly DbBKContext _dbContext; 
        private DbSet<T> _dbSet;

        public Repository(DbBKContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
            }
            catch (Exception e)
            {
                throw new RepositoryException(e.Message);
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
            catch (Exception e)
            {
                throw new RepositoryException(e.Message);
            }
        }

        public List<T> Find(Func<T, bool> predicate)
        {
            try
            {
                return _dbSet.Where(predicate).ToList();
            }
            catch (Exception e)
            {
                throw new RepositoryException(e.Message);
            }
        }

        public T Get(int id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch (Exception e)
            {
                throw new RepositoryException(e.Message);
            }
        }

        public IEnumerable<T> ListAll()
        {
            try
            {
                return _dbSet;
            }
            catch (Exception e)
            {
                throw new RepositoryException(e.Message);
            }
        }

        public bool Update(T entity)
        {
            try
            {
                DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);

                if (dbEntityEntry.State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }

                dbEntityEntry.State = EntityState.Modified;
                return true;
            }
            catch (Exception e)
            {
                throw new RepositoryException(e.Message);
            }
        }
    }
}
