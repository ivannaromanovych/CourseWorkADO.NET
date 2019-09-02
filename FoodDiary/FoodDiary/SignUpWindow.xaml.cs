using FoodDiary.BLL.Models;
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
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private int _Id;
        public SignUpWindow()
        {
            InitializeComponent();
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
            if (rbGenderMale.IsChecked == true||rbGenderFemale.IsChecked==true)
            {
                user.Gender = rbGenderMale.IsChecked==true;
                lbGender.Foreground = okBrush;
            }
            else
                lbGender.Foreground = errorBrush;
            this.Close();
        }
    }
}
