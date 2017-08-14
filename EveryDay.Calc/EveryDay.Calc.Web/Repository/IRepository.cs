using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDay.Calc.Web.Repository
{
    public interface IRepository<T> where T: class
    {
        void Create(T obj);

        T Read(long Id);

        void Update(T obj);

        void Delete(long Id);

        IEnumerable<T> GetAll();
    }
}
