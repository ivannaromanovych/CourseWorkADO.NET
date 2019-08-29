using FoodDiary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.BLL.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public float RecommentedCountOfCalories { get; set; }
        //the amount of proteins, fats and carbohydrates is measured in grams
        public float RecommentedCountOfProteins { get; set; }
        public float RecommentedCountOfFats { get; set; }
        public float RecommentedCountOfCarbohydrates { get; set; }
        public float AtedProteins { get; set; }
        public float AtedFats { get; set; }
        public float AtedCarbohydrates { get; set; }
        public float AtedCalories { get; set; }
        public List<DayDTO> Days { get; set; }
    }
}
