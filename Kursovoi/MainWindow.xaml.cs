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
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Shapes;

namespace Kursovoi
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitlzationSearchBut();


        }

        private void InitlzationSearchBut()
        {

            KursWorkEntities db = new KursWorkEntities();

            IQueryable<string> queryable = from t in db.Stop
                                           select t.StopName;

            foreach (string s in queryable)
            {
                SeacrhButton.Items.Add(s);
            }
        }


        public class SomeShit
        {
            public string text { get; set; }

            public string pict { get; set; }

            public string isFav { get; set; }

            public SomeShit(string str)
            {
                text = str;
                pict = "Resourses\\Images\\FavoritePainted.png";
                isFav = "true";

            }


        }




        //private void SeacrhButton_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    SeacrhButton.Text = "";
        //}

        int countBl = 0;

        #region Менюшка
        private void Autobus_Click(object sender, RoutedEventArgs e)//При нажатии на АВТОБУУС
        {
            AutobusMenu();
        }
        private void Trolleibus_Click(object sender, RoutedEventArgs e)//при нажатии на ТРОЛЛЕЙБУС
        {
            TrollebusMenu();
        }
        private void Tramvai_Click(object sender, RoutedEventArgs e)//При нажатии на ТРАМВАЙ
        {
            TramvaiMenu();
        }
        private void MITimetable_Click(object sender, RoutedEventArgs e)
        {
            OpenList();
        }//при РАСКРЫТИИ
        private void MIStation_Click(object sender, RoutedEventArgs e)//Клик на ОСТАНОВКИ
        {
            StopMenu();
        }
        private void MIMetroStation_Click(object sender, RoutedEventArgs e)//клик на МЕТРО
        {
            MetroMenu();
        }
        private void MIFavorites_Click(object sender, RoutedEventArgs e)//клик на ИЗБРАННОЕ
        {
            FavoriteMenu();
        }
        private void SearchRoute(object sender, RoutedEventArgs e)//клик на ПОИСК МАРШРУТА
        {
            SearchRouteMenu();
        }
        private void SearchStops(object sender, RoutedEventArgs e)
        {
            SearchStopsMenu();

        }//клик на ПОИСК
        private void EnterBut(object sender, RoutedEventArgs e)
        {
            EnterMenu();
        }//клик на ВХОД
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registraton();
        }




        #endregion

        private void GridColumn1_SelectionChanged1(object sender, SelectionChangedEventArgs e)//Вывод остановок
        {
            
            GridColumn2.Items.Clear();
            ListBox listBox = (ListBox)sender;

            SomeShit someShit = (SomeShit)listBox.SelectedItems[0];

            //----------------------------------
            someShit.isFav = "true";
            //----------------------------------
            string TempStr = someShit.text;
            string sad = "  ";
            int index = TempStr.IndexOf(sad) + 3;
            string FinalStr = TempStr.Remove(0, index);
            KursWorkEntities db = new KursWorkEntities();
            IQueryable<int> queryable = from t in db.Route
                                        where t.RouteName == FinalStr
                                        select t.RouteID;
            List<int> listT = queryable.ToList();

            int Id = Convert.ToInt32(listT[0]);

            IQueryable<string> StopQuery = from t in db.Stop
                                           where t.StopNum == Id
                                           select t.StopName;
            

            foreach (string s in StopQuery)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Selected += ListBoxItem_Selected;
                listBoxItem.Content = s;
                GridColumn2.Items.Add(listBoxItem);

            }
           

        }
        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)//маршруты-остановки-время
        {
            ListBoxItem temp = (ListBoxItem)sender;
            string content = Convert.ToString(temp.Content);
            KursWorkEntities db = new KursWorkEntities();
            IQueryable<Stop> SomeQuery = from t in db.Stop
                                         where t.StopName == content
                                         select t;
            foreach (Stop t in SomeQuery)
            {
                foreach (Time tt in t.Time)
                {
                    GridColumn3.Items.Add(tt.Hour + " : " + tt.Minute);
                }
            }
            #region oldVers
            //GridColumn2.Items.Clear();

            //ListBoxItem listBox = (ListBoxItem)sender;




            //string temp = Convert.ToString(listBox.Content);


            ////---------------------------тут всё норм
            //string sad = "  ";
            //int index = temp.IndexOf(sad)+3;
            //string FinalStr = temp.Remove(0, index);
            //KursWorkEntities db = new KursWorkEntities();
            //IQueryable<int> queryable = from t in db.Route
            //                            where t.RouteName == FinalStr
            //                            select t.RouteID;
            //List<int> listT = queryable.ToList();

            //int Id=Convert.ToInt32(listT[0]);

            //IQueryable<string> StopQuery = from t in db.Stop
            //                             where t.StopNum == Id
            //                             select t.StopName;


            //foreach(string s in StopQuery)
            //{
            //    ListBoxItem listBoxItem = new ListBoxItem();
            //    listBoxItem.Selected += List_Selected;
            //    listBoxItem.Content = s;
            //    GridColumn2.Items.Add(listBoxItem);
            //}


            #endregion
        }
        private void Stops_Time(object sender, SelectionChangedEventArgs e)//ОСТАНОВКИ-ВРЕМЯ
        {
            
            GridColumn2.Items.Clear();
            GridColumn3.Items.Clear();
            ListBox listBox = (ListBox)sender;
            SomeShit someShit = (SomeShit)listBox.SelectedItems[0];
            string TempStr = someShit.text;
            string sad = ". ";
            int index = TempStr.IndexOf(sad) + 3;
            string FinalStr = TempStr.Remove(0, index);
            KursWorkEntities db = new KursWorkEntities();
            IQueryable<Stop> SomeQuery = from t in db.Stop
                                         where t.StopName == FinalStr
                                         select t;
            foreach (Stop t in SomeQuery)
            {
                foreach (Time tt in t.Time)
                {
                    GridColumn3.Items.Add(tt.Hour + " : " + tt.Minute);
                }
            }
        }

        private void MetroSelect(object sender, SelectionChangedEventArgs e)
        {
            GridColumn2.Items.Clear();
            ListBox listBox = (ListBox)sender;

            SomeShit someShit = (SomeShit)listBox.SelectedItems[0];
            string TempStr = someShit.text;
            

            KursWorkEntities db = new KursWorkEntities();

            IQueryable<int> query = from t in db.Metro
                        where t.NameBranch == TempStr
                        select t.ID;

            int cifra = query.FirstOrDefault();

            IQueryable<Metro_Branch> queryable = from t in db.Metro_Branch
                                                 where t.Number == cifra
                                                 select t;

            foreach(Metro_Branch t in queryable)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content =  t.NameStation;
                listBoxItem.Selected += NameMetroStation_Time;
                GridColumn2.Items.Add(listBoxItem);
            }



        }

        private void NameMetroStation_Time(object sender, RoutedEventArgs e)
        {
            
            
            GridColumn3.Items.Clear();
            ListBoxItem listBox = (ListBoxItem)sender;
            string TempStr = Convert.ToString(listBox.Content);

            KursWorkEntities db = new KursWorkEntities();


            IQueryable<int> SomeQuery = from t in db.Metro_Branch
                                         where t.NameStation == TempStr
                                         select t.ID;
            int chislo = SomeQuery.FirstOrDefault();

            IQueryable<Metro_Time> queryable = from t in db.Metro_Time
                                               where t.ID == chislo
                                               select t;

            foreach (Metro_Time t in queryable)
            {
                GridColumn3.Items.Add(t.Hours + " : " + t.Minuts);
            }
        }

       







      

  

        private void FavoriteBtn(object sender, RoutedEventArgs e)
        {
            if(Users.Login==null && Users.Password==null)
            {
                MessageBox.Show("Необходимо войти или зарегестрироваться");
                return;
            }

            KursWorkEntities db = new KursWorkEntities();
            IQueryable<Users> queryable=from t in db.Users
                                        select t;

            Button self = (Button)sender;
            string nameOstanovka = (string)self.Tag;

            foreach(Users t in queryable)
            {
                if(t.UserFavourite==nameOstanovka)
                {
                    MessageBox.Show("Пользователь уже содержит этот объект");
                    return;
                }
            }

            var queryableUser = db.Users
                .Where(c => c.UserLogin == Users.Login)
                .FirstOrDefault();

            queryableUser.UserFavourite = nameOstanovka;

            db.SaveChanges();





            MessageBox.Show(nameOstanovka);
        }




        



        
    }
}
