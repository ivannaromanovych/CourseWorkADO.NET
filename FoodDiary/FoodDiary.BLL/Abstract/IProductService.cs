using FoodDiary.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.BLL.Abstract
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAll();
    }
}
