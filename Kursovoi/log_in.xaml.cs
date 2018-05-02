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

namespace Kursovoi
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//log in
        {
            KursWorkEntities db = new KursWorkEntities();



            string tempLog = RegLogin.Text;
            string tempPass = RegPassword.Password;

            IQueryable<Users> temp = from t in db.Users where t.UserLogin == tempLog && t.UserPassword == tempPass select t;


            

            foreach (Users usrs in temp)
            {
                MessageBox.Show("Аутентификация прошла успешно");
            }
            
            
            


           // Users usrs2 = new Users();
            //if (temp)
            //{
            //    MessageBox.Show("Аутентификация прошла успешно");
            //}


            //if (temp != null)
            //{
            //    MessageBox.Show("Аутентификация прошла успешно");
            //}
            //else
            //{
            //    MessageBox.Show("Аутентификация не прошла ");
            //}

            //здесь должна быть какая-то переменная, обозначающая номер введённого пользователя
            //db.Users.ElementAt(0);
            //А может строка сверху и не нужна


            //установка текущего пользователя
            db.Users.Where(t=>t.UserLogin==tempLog && t.UserPassword==tempPass);





        }
    }
}
