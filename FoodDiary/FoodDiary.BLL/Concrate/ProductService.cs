using FoodDiary.BLL.Abstract;
using FoodDiary.BLL.Models;
using FoodDiary.DAL.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.BLL.Concrate
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _repository;
        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<ProductDTO> GetAll()
        {
            return _repository.Get().Select(t => new ProductDTO()
            {
                Id = t.Id,
                Name = t.Name,
                CaloriesIn100g = t.CaloriesIn100g,
                ProteinsIn100g = t.ProteinsIn100g,
                FatsIn100g = t.FatsIn100g,
                CarbohydratesIn100g = t.CarbohydratesIn100g
            }).ToList();
        }
    }
}
