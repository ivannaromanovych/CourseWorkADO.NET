using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.DAL.Entities
{
    [Table("tblProducts")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //the amount of proteins, fats and carbohydrates is measured in grams
        [Required]
        public float ProteinsIn100g { get; set; }
        [Required]
        public float FatsIn100g { get; set; }
        [Required]
        public float CarbohydratesIn100g { get; set; }
        [Required]
        public float CaloriesIn100g { get; set; }
        public virtual ICollection<AtedProduct> AtedProducts { get; set; }
    }
}
