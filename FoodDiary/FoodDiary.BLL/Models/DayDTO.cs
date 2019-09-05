using FoodDiary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.BLL.Models
{
    public class DayDTO
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public List<AtedProductDTO> AtedProducts { get; set; }
        public float AtedCalories { get; set; }
        public float AtedProteins { get; set; }
        public float AtedFats { get; set; }
        public float AtedCarbohydrates { get; set; }
        public void FillDay()
        {
            if (AtedProducts != null)
                for (int i = 0; i < AtedProducts.Count; i++)
                {
                    AtedCalories += AtedProducts[i].AtedCalories;
                    AtedProteins += AtedProducts[i].AtedProteins;
                    AtedFats += AtedProducts[i].AtedFats;
                    AtedCarbohydrates += AtedProducts[i].AtedCarbohydrates;
                }
        }
    }
}
