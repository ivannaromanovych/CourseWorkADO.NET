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
        public User Find(int id)
        {
            return _context.Users.FirstOrDefault(t => t.Id == id);
        }
        public void AddIngestion(int id, DateTime date, AtedProduct product)
        {
            User user = Find(id);
            var day = user.Days.FirstOrDefault(t => t.Date.Day == date.Day && t.Date.Month == date.Month && t.Date.Year == date.Year);
            if (day == null)
            {
                day = new Day()
                {
                    UserId = user.Id,
                    Date = date.Date

                };
                _context.Days.Add(day);
            }
            _context.SaveChanges();
            _context.AtedProducts.Add(
                new AtedProduct()
                {
                    AtedCarbohydrates = product.AtedCarbohydrates,
                    AtedCalories = product.AtedCalories,
                    AtedFats = product.AtedFats,
                    AtedProteins = product.AtedProteins,
                    Id = product.Id,
                    DayId = day.Id,
                    ProductId = product.ProductId,
                    Weight = product.Weight,
                });
            _context.SaveChanges();
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
                });
            _context.SaveChanges();
        }
    }
}
