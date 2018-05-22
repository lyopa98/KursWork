using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Kursovoi
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public TextBlock TextBlockIn;
        public Registration()
        {
            InitializeComponent();

        }

        public Registration(TextBlock LogIn)
        {
            InitializeComponent();
            TextBlockIn = LogIn;
            
        }

        private void logIn(TextBlock In)
        {
            KursWorkEntities db = new KursWorkEntities();
            string tempLog = RegLogin.Text;
            string tempPass = RegPassword.Password;


            if (Users.Login != null && Users.Password != null)
            {
                MessageBox.Show("Необходимо выйти");
                return;
            }
            string validate = "^[a-zA-Z0-9]+$";

            Regex regex = new Regex(validate);

            if (regex.IsMatch(tempLog)) ;
            else
            {
                MessageBox.Show("Неправильно введён логин");
            }


            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum6Chars = new Regex(@".{6,}");

            if (hasNumber.IsMatch(RegPassword.Password) && hasUpperChar.IsMatch(RegPassword.Password) && hasMinimum6Chars.IsMatch(RegPassword.Password)) ;
            else
            {
                MessageBox.Show("Неправильно введён пароль: Необходимо присутствие цифры, буквы в верхнем регистре и длина пароля минимум 6 символов");
                return;
            }



            IQueryable<Users> temp = from t in db.Users where t.UserLogin == tempLog && t.UserPassword == tempPass select t;



            db.Users.Where(t => t.UserLogin == tempLog && t.UserPassword == tempPass);
            foreach (Users usrs in temp)
            {
                MessageBox.Show("Аутентификация прошла успешно");
                Users.Login = RegLogin.Text;
                Users.Password = RegLogin.Text;
                In.Text = "Выйти";



            }


            Close();
    }

        private void LogOut()
        {
            if (Users.Login != null && Users.Password != null)
            {
                Users.Login = null;
                Users.Password = null;
                MessageBox.Show("Выход произведён успешно");
                return;
            }
            else
            {
                MessageBox.Show("Не произведён вход в аккаунт");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)//log in
        {
            logIn(TextBlockIn);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//log out
        {
            LogOut();
        }
    }
}
