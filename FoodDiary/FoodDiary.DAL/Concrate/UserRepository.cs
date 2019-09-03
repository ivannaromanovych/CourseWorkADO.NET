using FoodDiary.DAL.Abstract;
using FoodDiary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
        public void AddOrUpdate(User user)
        {
            _context.Users.AddOrUpdate(t => t.Id,
                new User()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Gender = user.Gender,
                    Age = user.Age,
                    Height = user.Height,
                    Weight = user.Weight,
                    Login = user.Login,
                    Password = user.Password,
                    RecommentedCountOfCalories = user.RecommentedCountOfCalories,
                    RecommentedCountOfProteins = user.RecommentedCountOfProteins,
                    RecommentedCountOfFats = user.RecommentedCountOfFats,
                    RecommentedCountOfCarbohydrates = user.RecommentedCountOfCarbohydrates,
                    AtedCalories = user.AtedCalories,
                    AtedProteins = user.AtedProteins,
                    AtedFats = user.AtedFats,
                    AtedCarbohydrates = user.AtedCarbohydrates,
                    Days = user.Days
                });
        }
    }
}
