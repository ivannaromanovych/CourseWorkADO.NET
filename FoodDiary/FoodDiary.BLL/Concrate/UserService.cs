using FoodDiary.BLL.Abstract;
using FoodDiary.BLL.Models;
using FoodDiary.DAL.Concrate;
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
                AtedCarbohydrates = t.AtedCarbohydrates
            }).ToList();
        }
    }
}
