using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Uyelik.DAL;

namespace Uyelik.BLL.Repository
{
    public abstract class RepositoryBase<T, Id> where T : class
    {
        protected static MyContext dbContext;

        public virtual List<T> GetAll()
        {
            try
            {
                dbContext = new MyContext();
                return dbContext.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async virtual Task<List<T>> GetAllAsync()
        {
            try
            {
                dbContext = new MyContext();
                return await dbContext.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual T GetById(Id id)
        {
            try
            {
                dbContext = new MyContext();
                return dbContext.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async virtual Task<T> GetByIdAsync(Id id)
        {
            try
            {
                dbContext = new MyContext();
                return await dbContext.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual int Insert(T entity)
        {
            try
            {
                dbContext = dbContext ?? new MyContext();
                dbContext.Set<T>().Add(entity);
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async virtual Task<int> InsertAsync(T entity)
        {
            try
            {
                dbContext = dbContext ?? new MyContext();
                dbContext.Set<T>().Add(entity);
                return await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual int Delete(T entity)
        {
            try
            {
                dbContext = dbContext ?? new MyContext();
                dbContext.Set<T>().Remove(entity);
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async virtual Task<int> DeleteAsync(T entity)
        {
            try
            {
                dbContext = dbContext ?? new MyContext();
                dbContext.Set<T>().Remove(entity);
                return await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual int Update()
        {
            try
            {
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async virtual Task<int> UpdateAsync()
        {
            try
            {
                return await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual IQueryable<T> Queryable()
        {
            try
            {
                dbContext = dbContext ?? new MyContext();
                return dbContext.Set<T>().AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Dispose()
        {
            dbContext.Dispose();
            GC.SuppressFinalize(this);
            dbContext = null;
        }
    }
}
