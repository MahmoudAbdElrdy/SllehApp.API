using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Repositories.UOW
{
    public interface IUnitOfWork<T>
    {
        int Commit();
        Task<int> CommitAsync();
    }
}
