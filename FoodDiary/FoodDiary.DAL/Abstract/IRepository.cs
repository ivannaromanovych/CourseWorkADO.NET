using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.DAL.Abstract
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
    }
}
