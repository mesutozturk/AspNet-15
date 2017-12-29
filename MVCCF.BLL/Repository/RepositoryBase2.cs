using MVCCF.DAL;
using MVCCF.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCF.BLL.Repository
{
    public class RepositoryBase2<T, ID1, ID2> : IDisposable where T : AraTemel<ID1, ID2>
    {
        protected static MyContext dbContext;
        public async virtual Task<List<T>> GetAll()
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
        public async virtual Task<T> GetById(ID1 id1, ID2 id2)
        {
            try
            {
                dbContext = new MyContext();
                return await dbContext.Set<T>().FindAsync(id1, id2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async virtual void Insert(T entity)
        {
            try
            {
                dbContext = dbContext ?? new MyContext();
                dbContext.Set<T>().Add(entity);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async virtual void Delete(T entity)
        {
            try
            {
                dbContext = dbContext ?? new MyContext();
                dbContext.Set<T>().Remove(entity);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async virtual void Update()
        {
            try
            {
                await dbContext.SaveChangesAsync();
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
        public void Dispose(bool isDispose = true)
        {
            if (isDispose)
                this.Dispose();
        }
    }
}
