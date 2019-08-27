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
        [Key, Column(Order = 0), ForeignKey("UserOf")]
        public int UserId { get; set; }
        [Key, Column(Order = 1)]
        public DateTime Date { get; set; }
        public virtual User UserOf { get; set; }
        public virtual ICollection<AtedProduct> AtedProducts { get; set; }
    }
}
