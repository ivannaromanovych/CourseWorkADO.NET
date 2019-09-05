using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.DAL.Entities
{
    [Table("tblAtedProducts")]
    public class AtedProduct
    {
        [Key]
        public int Id { get; set; }
        [Required, ForeignKey("DayOf")]
        public int DayId { get; set; }
        [Required, ForeignKey("ProductOf")]
        public int ProductId { get; set; }
        [Required]
        public float Weight { get; set; }
        //the amount of proteins, fats and carbohydrates is measured in grams
        [Required]
        public float AtedProteins { get; set; }
        [Required]
        public float AtedFats { get; set; }
        [Required]
        public float AtedCarbohydrates { get; set; }
        [Required]
        public float AtedCalories { get; set; }
        public virtual Product ProductOf { get; set; }
        public virtual Day DayOf { get; set; }
    }
}
