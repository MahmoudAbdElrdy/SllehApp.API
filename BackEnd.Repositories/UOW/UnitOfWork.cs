using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BackEnd.Repositories.UOW
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext
    {
        private readonly T _dbContext;
        private bool disposed = false;

        public UnitOfWork(T dbContext)
        {
            _dbContext = dbContext;
        }

        //public int Commit()
        //{
        //    return _dbContext.SaveChanges();
        //}
        public int Commit()
        {
            int returnValue = 200;
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
                //  {
                try
                {
                    _dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (DbUpdateException ex)
                {
                    var sqlException = ex.GetBaseException() as SqlException;

                    if (sqlException != null)
                    {
                        var number = sqlException.Number;

                        if (number == 547)
                        {
                            returnValue = 501;

                        }
                        else
                            returnValue = 500;
                    }
                }
                catch (Exception ex)
                {
                    //Log Exception Handling message                      
                    returnValue = 500;
                    dbContextTransaction.Rollback();
                }
            //    }

            return returnValue;
        }
        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

