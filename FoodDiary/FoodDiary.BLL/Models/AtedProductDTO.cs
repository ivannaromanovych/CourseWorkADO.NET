using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.BLL.Models
{
    public class AtedProductDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public float Weight { get; set; }
        //the amount of proteins, fats and carbs is measured in grams
        public float AtedProteins { get; set; }
        public float AtedFats { get; set; }
        public float AtedCarbohydrates { get; set; }
        public float AtedCalories { get; set; }
    }
}
