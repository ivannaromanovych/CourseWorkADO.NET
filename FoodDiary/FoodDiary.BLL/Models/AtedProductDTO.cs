﻿using System;
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
        public string Name { get; set; }
        public float Weight { get; set; }
        //the amount of proteins, fats and carbs is measured in grams
        public float AtedProteins { get; set; }
        public float AtedFats { get; set; }
        public float AtedCarbohydrates { get; set; }
        public float AtedCalories { get; set; }
        public void FillProduct(ProductDTO product, float weight)
        {
            Weight = weight;
            AtedCalories = product.CaloriesIn100g / 100 * weight;
            AtedProteins = product.ProteinsIn100g / 100 * weight;
            AtedFats = product.FatsIn100g / 100 * weight;
            AtedCarbohydrates = product.CarbohydratesIn100g / 100 * weight;
            ProductId = product.Id;
            Name = product.Name;
        }
        public override string ToString()
        {
            return Name + " " + AtedCalories.ToString() + " cal, " + AtedProteins.ToString() + "/" + AtedFats.ToString() + "/" + AtedCarbohydrates.ToString();
            ;
        }
    }
}
