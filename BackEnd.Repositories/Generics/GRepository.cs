using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Repositories.Generics
{
public class GRepository<T> : IGRepository<T>
        where T : class
    {
        #region Private fields
        protected readonly DbContext _dbContext;
        private bool _disposed = false;
        #endregion

        #region Constructor
        public GRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Add Methods
        /// <summary>
        /// Insert single entity 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual object Add(T entity)
        {
            return _dbContext.Set<object>().Add(entity).Entity;
        }

        /// <summary>
        /// Insert single entity asynchronously
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual async Task AddAsync(T t)
        {
            await _dbContext.Set<T>().AddAsync(t);
        }

        /// <summary>
        /// Insert list of entities
        /// </summary>
        /// <param name="entities"></param>
        public virtual void AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }

        /// <summary>
        /// Insert list of entities asynchronously
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
        }
        #endregion

        #region Count Methods
        /// <summary>
        /// Retrieve the count of currently exisiting records
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _dbContext.Set<T>().Count();
        }

        /// <summary>
        /// Retrieve the count of currently exisiting records asynchronously
        /// </summary>
        /// <returns></returns>

        public Task<int> CountAsync()
        {
            return _dbContext.Set<T>().CountAsync();
        }

        #endregion

        #region Minimum Methods
        /// <summary>
        /// Returns the minimum value of generic IQueryable 
        /// </summary>
        /// <returns></returns>
        public T GetMinimum()
        {
            return _dbContext.Set<T>().Min();
        }
        /// <summary>
        /// Returns the minimum value of generic IQueryable asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<T> GetMinimumAsync()
        {
            return await _dbContext.Set<T>().MinAsync();
        }

        /// <summary>
        /// Returns the minimum value of generic IQueryable using given key
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public object GetMinimum(Expression<Func<T, object>> selector)
        {
            return _dbContext.Set<T>().Min(selector);
        }

        /// <summary>
        /// Returns the minimum value of generic IQueryable using given key asynchronously
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public async Task<object> GetMinimumAsync(Expression<Func<T, object>> selector)
        {
            return await _dbContext.Set<T>().MinAsync(selector);
        }
        #endregion

        #region Maximum Methods
        /// <summary>
        /// Returns the maximum value of generic IQueryable
        /// </summary>
        /// <returns></returns>
        public T GetMaximum()
        {
            return _dbContext.Set<T>().Max();
        }

        /// <summary>
        /// Returns the maximum value of generic IQueryable asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<T> GetMaximumAsync()
        {
            return await _dbContext.Set<T>().MaxAsync();
        }

        /// <summary>
        /// Returns the maximum value of generic IQueryable using given key
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public object GetMaximum(Expression<Func<T, object>> selector)
        {
            return _dbContext.Set<T>().Max(selector);
        }

        /// <summary>
        /// Returns the maximum value of generic IQueryable using given key asynchronously
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public async Task<object> GetMaximumAsync(Expression<Func<T, object>> selector)
        {
            return await _dbContext.Set<T>().MaxAsync(selector);
        }
        #endregion

        #region Find Methods
        /// <summary>
        /// Searches for record(s) using given keys
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public T Find(params object[] keys)
        {
            return _dbContext.Set<T>().Find(keys);
        }

        /// <summary>
        /// Searches for record(s) using given condition
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T Find(Func<T, bool> where)
        {
            return _dbContext.Set<T>().Find(where);
        }

        /// <summary>
        /// Searches for record(s) using given keys asynchronously
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public async Task<T> FindAsync(params object[] keys)
        {
            return await _dbContext.Set<T>().FindAsync(keys);
        }

        /// <summary>
        /// Searches for record(s) that match(es) a given condition
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _dbContext.Set<T>().FindAsync(match);
        }
        #endregion

        #region Get Methods
        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          string includeProperties = "", int page = 0, string NoTrack = "")
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (NoTrack != "")
            {
                query = query.AsNoTracking();
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                // Paging
                if (page > 0)
                {
                    return query.ToList().Skip(page - 1).Take(1);
                }
                else
                    return query.ToList();
            }
        }

        /// <summary>
        /// Retrieve all records
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// Retrieve all records based on a given condition
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().AsNoTracking().Where(where).AsQueryable();
        }

        /// <summary>
        /// Retrieve all records based on a given condition and key
        /// </summary>
        /// <param name="where"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        public virtual IQueryable<object> GetAll(Expression<Func<T, bool>> where, Expression<Func<T, object>> select)
        {
            var x = _dbContext.Set<T>().AsNoTracking().Where(where).Select(select);
            return x;
        }

        /// <summary>
        /// Retrieve all records asynchronously
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IQueryable<T>> GetAllAsync()
        {
            var list = await _dbContext.Set<T>().AsNoTracking().ToListAsync();
            return list.AsQueryable();
        }

        /// <summary>
        /// Retrieve all records based on a given condition asynchronously
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            var list = await this._dbContext.Set<T>().AsNoTracking().Where(expression).ToListAsync();
            return list.AsQueryable();
        }

        /// <summary>
        /// Retrieve all records based on a given condition and selector asynchronously
        /// </summary>
        /// <param name="where"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        public virtual async Task<IQueryable<object>> GetAllAsync(Expression<Func<T, bool>> where, Expression<Func<T, object>> select)
        {
            var list = await _dbContext.Set<T>().AsNoTracking().Where(where).Select(select).ToListAsync();
            return list.AsQueryable();
        }

        /// <summary>
        /// Retrieve all records with set of properties
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = GetAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }
            return queryable;
        }

        /// <summary>
        /// Retrieve all records with set of properties asynchronously
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public async Task<IQueryable<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            // need more investigation to avoid actual exeution by tolist()
            return (await _dbContext.Set<T>().AsNoTracking().Include(includeProperties.ToString()).ToListAsync()).AsQueryable();
        }

        /// <summary>
        /// Retrieve the first record
        /// </summary>
        /// <returns></returns>
        public T GetFirst()
        {
            return _dbContext.Set<T>().AsNoTracking().FirstOrDefault();
        }

        /// <summary>
        /// Retrieve the first record asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<T> GetFirstAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync();
        }

        /// <summary>
        /// Retrieve the first record based on a given condition
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T GetFirst(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().AsNoTracking().FirstOrDefault(where);
        }

        /// <summary>
        /// Retrieve the first record based on a given condition asynchronously
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> where)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(where);
        }

        /// <summary>
        /// Retrieve the last record
        /// </summary>
        /// <returns></returns>
        public T GetLast()
        {
            return _dbContext.Set<T>().AsNoTracking().LastOrDefault();
        }

        /// <summary>
        /// Retrieve the last record asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<T> GetLastAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().LastOrDefaultAsync();
        }

        /// <summary>
        /// Retrieve the last record based on a given condition
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T GetLast(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().AsNoTracking().LastOrDefault(where);
        }

        /// <summary>
        /// Retrieve the last record based on a given condition asynchronously
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<T> GetLastAsync(Expression<Func<T, bool>> where)
        {
            return await _dbContext.Set<T>().AsNoTracking().LastOrDefaultAsync(where);
        }





        #endregion



        #region Remove Methods
        /// <summary>
        /// Logically or physically deleting record based on the entity type
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual EntityEntry<T> Remove(T entity)
        {
            return _dbContext.Update(entity);
        }

        /// <summary>
        /// Logically or physically deleting list of records based on the entity type
        /// </summary>
        /// <param name="entities"></param>
        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public virtual void Truncate()
        {
            var sqlCmd = $"TRUNCATE TABLE {typeof(T).Name}" + "s";
            _dbContext.Database.ExecuteSqlCommand(sqlCmd);
        }
        #endregion

        #region Update Method
        /// <summary>
        /// Update record data
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual EntityEntry<T> Update(T entity)
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries<T>().ToList())
            {
                entry.State = EntityState.Detached;
            }
            return _dbContext.Update(entity);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
        #endregion
    }
}
