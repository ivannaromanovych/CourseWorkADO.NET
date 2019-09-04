using FoodDiary.BLL.Concrate;
using FoodDiary.BLL.Models;
using FoodDiary.DAL.Concrate;
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
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
        }
        private static UserRepository _userRepository = new UserRepository();
        private UserService _userService = new UserService(_userRepository);
        private void ButSignIn_Click(object sender, RoutedEventArgs e)
        {
            UserDTO user = new UserDTO();
            if (!String.IsNullOrWhiteSpace(tbLogin.Text) && !String.IsNullOrWhiteSpace(tbPassword.Text))
            {
                if (_userService.GetAll().Count(t => t.Login == tbLogin.Text) > 0) 
                    user=_userService.GetAll().First(t => t.Login == tbLogin.Text);
                if (user.Password == tbPassword.Text)
                {
                    DiaryWindow diary = new DiaryWindow(user);
                    this.Close();
                    diary.ShowDialog();
                }
                else
                    tblError.Text = "You filled wrong Login or Password";
            }
            else
                tblError.Text = "You didn't filled Login or Password";
        }

        private void ButSingUp_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow sign = new SignUpWindow();
            sign.ShowDialog();
            tbLogin.Text = sign.tbLogin.Text;
            tbPassword.Text = sign.tbPassword.Text;
        }
    }
}
