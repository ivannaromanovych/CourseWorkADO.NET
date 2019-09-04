using FoodDiary.BLL.Models;
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
        public DiaryWindow(UserDTO user)
        {
            InitializeComponent();
            this.user = user;
            if (user.Gender == true)
                lbGender.Content = "Male";
            else
                lbGender.Content = "Female";
            lbAge.Content = user.Age;
            lbWeight.Content = user.Weight;
            lbHeight.Content = user.Height;
            lbName.Content = user.FirstName + " " + user.LastName;
            tblCalories.Text = user.RecommentedCountOfCalories.ToString();
            lb

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
    }
}
