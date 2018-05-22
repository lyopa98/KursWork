using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Mail;
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
    /// Логика взаимодействия для Registration2.xaml
    /// </summary>
    public partial class Registration2 : Window
    {
        public Registration2()
        {
            InitializeComponent();
        }

        public bool IsValidEmail(string emailaddress)//Валидация почта
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)//registration
        {
            if (Users.Login != null && Users.Password != null)
            {
                MessageBox.Show("Надо выйти");
                Close();
                return;
            }

            string validateForLogin = "^[a-zA-Z0-9]+$";

            Regex regex = new Regex(validateForLogin);

            if (regex.IsMatch(LoginTB.Text));
            else
            {
                MessageBox.Show("Неправильно введён логин");
                return;
            }
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum6Chars = new Regex(@".{6,}");

            if (hasNumber.IsMatch(PasswordTB.Password) && hasUpperChar.IsMatch(PasswordTB.Password) && hasMinimum6Chars.IsMatch(PasswordTB.Password)) ;
            else
            {
                MessageBox.Show("Неправильно введён пароль: Необходимо присутствие цифры, буквы в верхнем регистре и длина пароля минимум 6 символов");
                return;
            }

            if (IsValidEmail(EmailTB.Text));
            else {
                MessageBox.Show("неправильно введена почта");
                return;
            }

            KursWorkEntities dB = new KursWorkEntities();




                Users users = new Users()
                {


                    UserLogin = LoginTB.Text,
                    UserEmail = EmailTB.Text,
                    UserPassword = PasswordTB.Password

                };
            try
            {
                dB.Users.Add(users);
                dB.SaveChanges();
                MessageBox.Show("Регистрация прошла успешно");
            }
            catch (DbEntityValidationException ex)
            {

                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    MessageBox.Show("");
                        foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                        }
                }
            }
            Close();

        }
    }
}
