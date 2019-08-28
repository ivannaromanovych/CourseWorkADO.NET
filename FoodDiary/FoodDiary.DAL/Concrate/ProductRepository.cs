using FoodDiary.DAL.Abstract;
using FoodDiary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.DAL.Concrate
{
    public class ProductRepository:IRepository<Product>
    {
        private readonly EFContext _context = new EFContext();
        public IEnumerable<Product> Get()
        {
            return _context.Products.ToList();
        }
    }
}
