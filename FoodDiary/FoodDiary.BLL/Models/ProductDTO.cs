using FoodDiary.DAL.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.BLL.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //the amount of proteins, fats and carbohydrates is measured in grams
        public float ProteinsIn100g { get; set; }
        public float FatsIn100g { get; set; }
        public float CarbohydratesIn100g { get; set; }
        public float CaloriesIn100g { get; set; }
    }
}
