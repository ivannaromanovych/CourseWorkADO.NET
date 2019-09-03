using FoodDiary.BLL.Concrate;
using FoodDiary.BLL.Models;
using FoodDiary.DAL.Concrate;
using FoodDiary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FoodDiary
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private int _Id = 0;
        private static UserRepository _userRepository = new UserRepository();
        private UserService _userService = new UserService(_userRepository);
        public SignUpWindow()
        {
            InitializeComponent();
            _Id = _userService.GetAll().ToList()[_userService.GetAll().ToList().Count - 1].Id + 1;
        }
        UserDTO user = new UserDTO();

        public SignUpWindow(UserDTO user)
        {
            InitializeComponent();
            _Id = user.Id;
        }
        private void ButSave_Click(object sender, RoutedEventArgs e)
        {
            Brush errorBrush = new SolidColorBrush(Colors.Red);
            Brush okBrush = new SolidColorBrush(Colors.Black);

            if (!String.IsNullOrWhiteSpace(tbFirstName.Text))
            {
                user.FirstName = tbFirstName.Text;
                lbFirstName.Foreground = okBrush;
            }
            else
                lbFirstName.Foreground = errorBrush;

            if (!String.IsNullOrWhiteSpace(tbLastName.Text))
            {
                user.LastName = tbLastName.Text;
                lbLastName.Foreground = okBrush;
            }
            else
                lbLastName.Foreground = errorBrush;

            if (rbGenderMale.IsChecked == true || rbGenderFemale.IsChecked == true)
            {
                user.Gender = rbGenderMale.IsChecked == true;
                lbGender.Foreground = okBrush;
            }
            else
                lbGender.Foreground = errorBrush;

            if (!String.IsNullOrWhiteSpace(tbWeight.Text))
            {
                float res;
                if (!float.TryParse(tbWeight.Text, out res) || float.Parse(tbWeight.Text) < 30 || float.Parse(tbWeight.Text) > 230)
                    lbWeight.Foreground = errorBrush;
                else
                {
                    user.Weight = float.Parse(tbWeight.Text);
                    lbWeight.Foreground = okBrush;
                }
            }
            else
                lbWeight.Foreground = errorBrush;

            if (!String.IsNullOrWhiteSpace(tbHeight.Text))
            {
                float res;
                if (!float.TryParse(tbHeight.Text, out res) || float.Parse(tbHeight.Text) < 130 || float.Parse(tbHeight.Text) > 250)
                    lbHeight.Foreground = errorBrush;
                else
                {
                    user.Height = float.Parse(tbHeight.Text);
                    lbHeight.Foreground = okBrush;
                }
            }
            else
                lbHeight.Foreground = errorBrush;

            if (!String.IsNullOrWhiteSpace(tbAge.Text))
            {
                uint res;
                if (!uint.TryParse(tbAge.Text, out res) || uint.Parse(tbAge.Text) < 13 || uint.Parse(tbAge.Text) > 120)
                    lbAge.Foreground = errorBrush;
                else
                {
                    user.Age = int.Parse(tbAge.Text);
                    lbAge.Foreground = okBrush;
                }
            }
            else
                lbAge.Foreground = errorBrush;

            if (!String.IsNullOrEmpty(tbLogin.Text) && tbLogin.Text.Length >= 5)
            {
                if (_userService.GetAll().Count(t => t.Login == tbLogin.Text) == 0 || _Id != 0)
                {
                    user.Login = tbLogin.Text;
                    lbLogin.Foreground = okBrush;

                }
                else
                    lbLogin.Foreground = errorBrush;
            }
            else
                lbLogin.Foreground = errorBrush;

            if (!String.IsNullOrEmpty(tbPassword.Text) && tbPassword.Text.Length >= 8)
            {
                user.Password = tbPassword.Text;
                lbPassword.Foreground = okBrush;
            }
            else
                lbPassword.Foreground = errorBrush;
            EFContext _context = new EFContext();
            if (lbFirstName.Foreground == errorBrush ||
                lbLastName.Foreground == errorBrush ||
                lbGender.Foreground == errorBrush ||
                lbWeight.Foreground == errorBrush ||
                lbHeight.Foreground == errorBrush ||
                lbAge.Foreground == errorBrush ||
                lbLogin.Foreground == errorBrush ||
                lbPassword.Foreground == errorBrush)
            {
                lbTitle.Foreground = errorBrush;
                lbTitle.Content = "You didn't fill all fields right";
            }
            else
            {
                if (user.Gender == true)
                    user.RecommentedCountOfCalories = (10 * user.Weight + 6.25f * user.Height - 5 * user.Age + 5) * 1.3f;
                else
                    user.RecommentedCountOfCalories = (10 * user.Weight + 6.25f * user.Height - 5 * user.Age - 161) * 1.3f;
                float a = user.RecommentedCountOfCalories / 6;
                user.RecommentedCountOfProteins = a / 4;
                user.RecommentedCountOfFats = a / 9;
                user.RecommentedCountOfCarbohydrates = (a * 4) / 4;
                _userService.AddOrUpdate(user);
            }
        }
    }
}
