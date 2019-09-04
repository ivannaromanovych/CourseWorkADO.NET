using FoodDiary.BLL.Abstract;
using FoodDiary.BLL.Models;
using FoodDiary.DAL.Concrate;
using FoodDiary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.BLL.Concrate
{
    public class UserService : IUserService
    {
        private readonly UserRepository _repository;
        public UserService(UserRepository repository)
        {
            _repository = repository;
        }
        public UserDTO FindById(int id)
        {
            var user=_repository.Find(id);
            return new UserDTO()
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
                Days = user.Days.Select(d => new DayDTO()
                {
                    UserId = d.UserId,
                    Date = d.Date,
                    AtedProducts = d.AtedProducts.Select(a => new AtedProductDTO()
                    {
                        Id = a.Id,
                        ProductId = a.ProductId,
                        Weight = a.Weight,

                        AtedCalories = a.AtedCalories,
                        AtedProteins = a.AtedProteins,
                        AtedFats = a.AtedFats,
                        AtedCarbohydrates = a.AtedCarbohydrates
                    }).ToList()
                }).ToList()
            };
        }
        public IEnumerable<UserDTO> GetAll()
        {
            return _repository.Get().Select(t => new UserDTO()
            {
                Id = t.Id,
                FirstName = t.FirstName,
                LastName = t.LastName,
                Gender = t.Gender,
                Age = t.Age,
                Height = t.Height,
                Weight = t.Weight,
                Login = t.Login,
                Password = t.Password,
                RecommentedCountOfCalories = t.RecommentedCountOfCalories,
                RecommentedCountOfProteins = t.RecommentedCountOfProteins,
                RecommentedCountOfFats = t.RecommentedCountOfFats,
                RecommentedCountOfCarbohydrates = t.RecommentedCountOfCarbohydrates,
                AtedCalories = t.AtedCalories,
                AtedProteins = t.AtedProteins,
                AtedFats = t.AtedFats,
                AtedCarbohydrates = t.AtedCarbohydrates,
                Days = t.Days.Select(d => new DayDTO()
                {
                    UserId = d.UserId,
                    Date = d.Date,
                    AtedProducts = d.AtedProducts.Select(a => new AtedProductDTO()
                    {
                        Id = a.Id,
                        ProductId = a.ProductId,
                        Weight = a.Weight,

                        AtedCalories = a.AtedCalories,
                        AtedProteins = a.AtedProteins,
                        AtedFats = a.AtedFats,
                        AtedCarbohydrates = a.AtedCarbohydrates
                    }).ToList()
                }).ToList(),
            }).ToList();
        }
        public void AddOrUpdate(UserDTO user)
        {
            _repository.AddOrUpdate(new User()
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
        }
    }
}
