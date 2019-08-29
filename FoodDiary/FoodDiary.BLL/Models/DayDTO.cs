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
    }
}
