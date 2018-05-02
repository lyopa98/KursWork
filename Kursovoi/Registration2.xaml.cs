using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        private void Button_Click(object sender, RoutedEventArgs e)//registration
        {
           

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

        }
    }
}
