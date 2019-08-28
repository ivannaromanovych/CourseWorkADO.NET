namespace FoodDiary.DAL.Migrations
{
    using FoodDiary.DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Bogus;

    internal sealed class Configuration : DbMigrationsConfiguration<FoodDiary.DAL.Entities.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FoodDiary.DAL.Entities.EFContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                Random rand = new Random();
                Faker faker = new Faker();
                string _FirstName, _LastName;
                bool _Gender;
                int _Age;
                float _Height, _Weight, _Calories, _Proteins, _Fats, _Carbohydrates;
                _Age = rand.Next(16, 60);
                _Height = rand.Next(1500, 2000) / 10;
                _Weight = rand.Next(600, 1000) / 10;
                if (rand.Next(1, 3) == 1)
                {
                    _Gender = true;
                    _FirstName = faker.Name.FirstName(Bogus.DataSets.Name.Gender.Male);
                    _LastName = faker.Name.LastName(Bogus.DataSets.Name.Gender.Male);
                    _Calories = (10 * _Weight + 6.25f * _Height - 5 * _Age + 5) * 1.3f;
                }
                else
                {
                    _Gender = false;
                    _FirstName = faker.Name.FirstName(Bogus.DataSets.Name.Gender.Female);
                    _LastName = faker.Name.LastName(Bogus.DataSets.Name.Gender.Female);
                    _Calories = (10 * _Weight + 6.25f * _Height - 5 * _Age - 161) * 1.3f;

                }
                float a = _Calories / 6;
                _Proteins = a / 4;
                _Fats = a / 9;
                _Carbohydrates = (a * 4) / 4;

                context.Users.AddOrUpdate(t => t.Id,
                    new User()
                    {
                        Id = i,
                        FirstName = _FirstName,
                        LastName = _LastName,
                        Gender = _Gender,
                        Age = _Age,
                        Height = _Height,
                        Weight = _Weight,
                        Login = "user" + i,
                        Password = "password" + i,
                        RecommentedCountOfCalories = _Calories,
                        RecommentedCountOfProteins = _Proteins,
                        RecommentedCountOfFats = _Fats,
                        RecommentedCountOfCarbohydrates = _Carbohydrates,
                        AtedCalories = 0,
                        AtedProteins = 0,
                        AtedFats = 0,
                        AtedCarbohydrates = 0
                    });
            }
            context.Products.AddOrUpdate(t => t.Id,
                new Product()
                {
                    Id = 1,
                    Name = "Apple",
                    CaloriesIn100g = 46,
                    ProteinsIn100g = 0.4f,
                    FatsIn100g = 0,
                    CarbohydratesIn100g = 11.3f
                });
            context.Products.AddOrUpdate(t => t.Id,
                new Product()
                {
                    Id = 2,
                    Name = "Carrot",
                    CaloriesIn100g = 33,
                    ProteinsIn100g = 1.3f,
                    FatsIn100g = 0.1f,
                    CarbohydratesIn100g = 7
                });
            context.Products.AddOrUpdate(t => t.Id,
                new Product()
                {
                    Id = 3,
                    Name = "Onion",
                    CaloriesIn100g = 43,
                    ProteinsIn100g = 1.7f,
                    FatsIn100g = 0,
                    CarbohydratesIn100g = 9.5f
                });
            context.Products.AddOrUpdate(t => t.Id,
                new Product()
                {
                    Id = 4,
                    Name = "Cucumber",
                    CaloriesIn100g = 15,
                    ProteinsIn100g = 0.8f,
                    FatsIn100g = 0,
                    CarbohydratesIn100g = 3
                });
            context.Products.AddOrUpdate(t => t.Id,
                new Product()
                {
                    Id = 5,
                    Name = "Potato",
                    CaloriesIn100g = 83,
                    ProteinsIn100g = 2,
                    FatsIn100g = 0.1f,
                    CarbohydratesIn100g = 19.7f
                });
        }
    }
}
