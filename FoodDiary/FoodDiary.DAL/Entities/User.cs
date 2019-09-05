using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.DAL.Entities
{
    [Table("tblUsers")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public float Height { get; set; }
        [Required]
        public float Weight { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public float RecommentedCountOfCalories { get; set; }
        //the amount of proteins, fats and carbohydrates is measured in grams
        [Required]
        public float RecommentedCountOfProteins { get; set; }
        [Required]
        public float RecommentedCountOfFats { get; set; }
        [Required]
        public float RecommentedCountOfCarbohydrates { get; set; }
        public virtual ICollection<Day> Days { get; set; }
    }
}
