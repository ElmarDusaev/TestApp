using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domain.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
    }
}
