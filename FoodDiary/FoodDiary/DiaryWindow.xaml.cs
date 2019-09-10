using FoodDiary.BLL.Concrate;
using FoodDiary.BLL.Models;
using FoodDiary.DAL.Concrate;
using FoodDiary.DAL.Entities;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for DiaryWindow.xaml
    /// </summary>
    public partial class DiaryWindow : Window
    {
        private UserDTO user;
        private static ProductRepository _productRepository = new ProductRepository();
        private ProductService _productService = new ProductService(_productRepository);
        private static UserRepository _userRepository = new UserRepository();
        private UserService _userService = new UserService(_userRepository);
        public DiaryWindow(UserDTO user)
        {
            InitializeComponent();
            this.user = _userService.FindById(user.Id);
            Calendar1.SelectionMode = CalendarSelectionMode.SingleDate;
            cbProducts.ItemsSource = _productService.GetAll().ToList();
            Calendar1.SelectedDate = DateTime.Now;
            FillWindow();
        }
        private void FillWindow()
        {
            _userRepository = new UserRepository();
            _userService = new UserService(_userRepository);
            this.user = _userService.FindById(user.Id);
            if (user.Gender == true)
                lbGender.Content = "Male";
            else
                lbGender.Content = "Female";
            lbAge.Content = user.Age;
            lbWeight.Content = user.Weight;
            lbHeight.Content = user.Height;
            lbName.Content = user.FirstName + " " + user.LastName;
            tblCalories.Text = user.RecommentedCountOfCalories.ToString();

            lbRecommendedCalories.Content = user.RecommentedCountOfCalories.ToString();
            lbRecommendedCarbs.Content = user.RecommentedCountOfCarbohydrates.ToString();
            lbRecommendedFats.Content = user.RecommentedCountOfFats.ToString();
            lbRecommendedProteins.Content = user.RecommentedCountOfProteins.ToString();

            cbProducts.SelectedIndex = -1;
            tboxProductWeight.Text = "";
            DayDTO day = user.FindDay(Convert.ToDateTime(Calendar1.SelectedDate));
            if (day != null)
            {
                day.FillDay();
                lbAtedCalories.Content = day.AtedCalories.ToString();
                lbAtedCarbs.Content = day.AtedCarbohydrates.ToString();
                lbAtedFats.Content = day.AtedFats.ToString();
                lbAtedProteins.Content = day.AtedProteins.ToString();
                lbAtedProducts.ItemsSource = day.AtedProducts.ToList();
            }
            else
            {
                lbAtedCalories.Content = 0;
                lbAtedCarbs.Content = 0;
                lbAtedFats.Content = 0;
                lbAtedProteins.Content = 0;
            }
        }
        private void ButEdit_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow sign = new SignUpWindow(user);
            sign.tbFirstName.Text = user.FirstName;
            sign.tbLastName.Text = user.LastName;
            if (user.Gender == true)
                sign.rbGenderMale.IsChecked = true;
            else
                sign.rbGenderFemale.IsChecked = true;
            sign.tbWeight.Text = user.Weight.ToString();
            sign.tbHeight.Text = user.Height.ToString();
            sign.tbAge.Text = user.Age.ToString(); 
            sign.tbLogin.Text = user.Login;
            sign.tbPassword.Text = user.Password;
            sign.lbTitle.Content = "Edit user";
            this.Close();
            sign.ShowDialog();
        }

        private void ButAddNewIngestion_Click(object sender, RoutedEventArgs e)
        {
            if (cbProducts.SelectedIndex == -1)
                lbError.Content="You didn't choose product";
            else if (String.IsNullOrWhiteSpace(tboxProductWeight.Text))
                lbError.Content = "You didn't enter product weight";
            else
            {
                float res;
                if (!float.TryParse(tboxProductWeight.Text, out res) || float.Parse(tboxProductWeight.Text) < 0 || float.Parse(tboxProductWeight.Text) > 1000)
                    lbError.Content = "You didn't fill product weight right";
                else
                {
                    AtedProductDTO product = new AtedProductDTO();
                    product.FillProduct((ProductDTO)cbProducts.SelectedItem, float.Parse(tboxProductWeight.Text));
                    _userService.AddIngestion(user.Id, Convert.ToDateTime(Calendar1.SelectedDate), product);
                    user = _userService.FindById(user.Id);
                    FillWindow();
                }
            }
        }

        private void Calendar1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Calendar1.SelectedDate.HasValue == true)
            {
                DayDTO day = user.Days.FirstOrDefault(t => t.Date.CompareTo(Calendar1.SelectedDate.Value) == 0);
                if (day != null)
                {
                    FillWindow();
                }
                else
                {
                    lbAtedCalories.Content = 0;
                    lbAtedCarbs.Content = 0;
                    lbAtedFats.Content = 0;
                    lbAtedProteins.Content = 0;
                    lbAtedProducts.ItemsSource = null;
                }
            }

        }
    }
}
