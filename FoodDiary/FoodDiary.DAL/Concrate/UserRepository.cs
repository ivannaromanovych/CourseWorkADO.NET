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
            _context.Users.ElementAt(id).Days.First(t => t.Date.Day == date.Day && t.Date.Month == date.Month && t.Date.Year == date.Year).AtedProducts.Add(product);
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
