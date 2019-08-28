using FoodDiary.DAL.Abstract;
using FoodDiary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.DAL.Concrate
{
    public class UserRepository : IRepository<User>
    {
        private readonly EFContext _context = new EFContext();
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }
    }
}
