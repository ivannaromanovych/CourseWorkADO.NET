using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.DAL.Entities
{
    [Table("tblDays")]
    public class Day
    {
        [Key]
        public int Id { get; set; }
        [Index(IsUnique =true)]
        public DateTime Date { get; set; }

        [ForeignKey("UserOf")]
        public int UserId { get; set; }

        public virtual User UserOf { get; set; }
        public virtual ICollection<AtedProduct> AtedProducts { get; set; }
    }
}
