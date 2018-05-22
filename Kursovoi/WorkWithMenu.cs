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
    public partial class MainWindow : Window
    {
        private void AutobusMenu()//клик на АВТОБУС
        {
            GridColumn1.SelectionChanged -= GridColumn1_SelectionChanged1;
            GridColumn1.SelectionChanged -= MetroSelect;
            GridColumn1.SelectionChanged -= Stops_Time;
            GridColumn1.ItemsSource = null;
            GridColumn2.Items.Clear();
            GridColumn3.Items.Clear();
            
            TitleOfSelected.Text = "Автобус";
            KursWorkEntities db = new KursWorkEntities();
            IQueryable<Route> Query = from t in db.Route
                                      where t.RouteType == "Автобус"
                                      select t;
            UnitOfWork unitOfWork = new UnitOfWork();

            //var prot = unitOfWork.route.GetAll();
            
            //var t =from f in prot
            //       where f.RouteType




            ObservableCollection < SomeShit > keka = new ObservableCollection<SomeShit>();

            if (GridColumn1.Items.Count == 0)
            {

                foreach (Route t in Query)
                {
                    keka.Add(new SomeShit(t.RouteNumber + "   " + t.RouteName));
                }

                GridColumn1.ItemsSource = keka;
                GridColumn1.SelectionChanged += GridColumn1_SelectionChanged1;
            }
            else
            {
                GridColumn1.ItemsSource = null;
                foreach (Route t in Query)
                {
                    keka.Add(new SomeShit(t.RouteNumber + "   " + t.RouteName));
                }
                GridColumn1.ItemsSource = keka;
                GridColumn1.SelectionChanged += GridColumn1_SelectionChanged1;
            }
        }

        private void TrollebusMenu()
        {
            TitleOfSelected.Text = "Троллейбус";
            GridColumn1.SelectionChanged -= GridColumn1_SelectionChanged1;
            GridColumn1.SelectionChanged -= MetroSelect;
            GridColumn1.SelectionChanged -= Stops_Time;
            GridColumn1.ItemsSource = null;
            GridColumn2.Items.Clear();
            GridColumn3.Items.Clear();

            KursWorkEntities db = new KursWorkEntities();
            IQueryable<Route> Query = from t in db.Route
                                      where t.RouteType == "Троллейбус"
                                      select t;


            ObservableCollection<SomeShit> keka = new ObservableCollection<SomeShit>();

            if (GridColumn1.ItemsSource==null)
            {

                foreach (Route t in Query)
                {
                    keka.Add(new SomeShit(t.RouteNumber + "   " + t.RouteName));
                }

                GridColumn1.ItemsSource = keka;
                GridColumn1.SelectionChanged += GridColumn1_SelectionChanged1;
            }
            else
            {
                GridColumn1.ItemsSource = null;
                foreach (Route t in Query)
                {
                    keka.Add(new SomeShit(t.RouteNumber + "   " + t.RouteName));
                }
                GridColumn1.ItemsSource = keka;

                GridColumn1.SelectionChanged += GridColumn1_SelectionChanged1;
            }
        }//клик на ТРОЛЛЕЙБУС

        private void TramvaiMenu()
        {
            TitleOfSelected.Text = "Трамвай";
            GridColumn1.SelectionChanged -= GridColumn1_SelectionChanged1;
            GridColumn1.SelectionChanged -= MetroSelect;
            GridColumn1.ItemsSource = null;
            GridColumn2.Items.Clear();
            GridColumn3.Items.Clear();

            KursWorkEntities db = new KursWorkEntities();
            IQueryable<Route> Query = from t in db.Route
                                      where t.RouteType == "Трамвай"
                                      select t;


            ObservableCollection<SomeShit> keka = new ObservableCollection<SomeShit>();

            if (GridColumn1.Items.Count == 0)
            {

                foreach (Route t in Query)
                {
                    keka.Add(new SomeShit(t.RouteNumber + "   " + t.RouteName));
                }

                GridColumn1.ItemsSource = keka;
                GridColumn1.SelectionChanged += GridColumn1_SelectionChanged1;
            }
            else
            {
                GridColumn1.ItemsSource = null;
                foreach (Route t in Query)
                {
                    keka.Add(new SomeShit(t.RouteNumber + "   " + t.RouteName));
                }
                GridColumn1.ItemsSource = keka;
                GridColumn1.SelectionChanged += GridColumn1_SelectionChanged1;
            }
        }//клик на ТРАМВАЙ

        private void OpenList()
        {
            countBl++;


            MenuItem Autobus = new MenuItem();
            Autobus.Header = " - Автобус";
            Autobus.Click += Autobus_Click;

            MenuItem Trolleibus = new MenuItem();
            Trolleibus.Header = " - Троллейбус";
            Trolleibus.Click += Trolleibus_Click;

            MenuItem Tramvai = new MenuItem();
            Tramvai.Header = " - Трамвай";
            Tramvai.Click += Tramvai_Click;


            if (MainMenu.Items.Count == 9)
            {
                MainMenu.Items.RemoveAt(5);
                MainMenu.Items.RemoveAt(4);
                MainMenu.Items.RemoveAt(3);
            }
            else
            {
                MainMenu.Items.Insert(3, Autobus);
                MainMenu.Items.Insert(4, Trolleibus);
                MainMenu.Items.Insert(5, Tramvai);
            }

            #region Artem
            //if (countBlia%2 == 0)
            //    {
            //    MainMenu.Items.RemoveAt(4);
            //    MainMenu.Items.RemoveAt(3);
            //    MainMenu.Items.RemoveAt(2);

            //}
            //else
            //{
            //    MainMenu.Items.Insert(2, Autobus);
            //    MainMenu.Items.Insert(3, Trolleibus);
            //    MainMenu.Items.Insert(4, Tramvai);
            //}
            #endregion
        }//Раскрытие списка

        private void StopMenu()
        {
            TitleOfSelected.Text = "Остановки";
            //GridColumn1.Items.Clear();
            GridColumn1.SelectionChanged -= GridColumn1_SelectionChanged1;
            GridColumn1.SelectionChanged -= MetroSelect;
            GridColumn1.SelectionChanged -= Stops_Time;
            GridColumn1.ItemsSource = null;
            GridColumn2.Items.Clear();
            KursWorkEntities db = new KursWorkEntities();
            IQueryable<Stop> queryable = from t in db.Stop select t;
            ObservableCollection<SomeShit> keka = new ObservableCollection<SomeShit>();
            foreach (Stop ds in queryable)
            {
                ListBoxItem item = new ListBoxItem();
                SomeShit ss = new SomeShit(ds.Route.RouteType + "  " + ds.Route.RouteNumber + ".  " + ds.StopName);
                ss.isFav = "false";
                keka.Add(ss);
            }

            GridColumn1.ItemsSource = keka;
            GridColumn1.SelectionChanged -= GridColumn1_SelectionChanged1;
            GridColumn1.SelectionChanged += Stops_Time;

        }//Клик на Остановки

        private void MetroMenu()
        {
            GridColumn1.SelectionChanged -= GridColumn1_SelectionChanged1;
            GridColumn1.ItemsSource = null;
            GridColumn2.Items.Clear();
            GridColumn3.Items.Clear();
            TitleOfSelected.Text = "Станции метро";
            KursWorkEntities dB = new KursWorkEntities();
            ObservableCollection<SomeShit> keka = new ObservableCollection<SomeShit>();
            IQueryable<Metro> temp2 = from t in dB.Metro
                                      select t;

            foreach (Metro t in temp2)
            {
                SomeShit ss = new SomeShit(t.NameBranch);
                ss.isFav = "true";
                keka.Add(ss);
            }
            GridColumn1.SelectionChanged += MetroSelect;
            GridColumn1.ItemsSource = keka;
        }//клик на МЕТРО

        private void FavoriteMenu()
        {
            TitleOfSelected.Text = "Избранное";
            GridColumn1.SelectionChanged -= GridColumn1_SelectionChanged1;
            GridColumn1.SelectionChanged -= MetroSelect;
            GridColumn1.ItemsSource = null;
            KursWorkEntities db = new KursWorkEntities();
            ObservableCollection<SomeShit> keka = new ObservableCollection<SomeShit>();
            var queryableUser = db.Users
               .Where(c => c.UserLogin == Users.Login)
               .FirstOrDefault();
            try
            {

                SomeShit someShit = new SomeShit(queryableUser.UserFavourite);
                someShit.isFav = "true";

                keka.Add(someShit);
                GridColumn1.ItemsSource = keka;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Необходимо войти");
            }
        }//клик на ИЗБРАННОЕ

        private void SearchRouteMenu()
        {
            SearchRouteWindow searchRouteWindow = new SearchRouteWindow();
            searchRouteWindow.Show();
            GridColumn1.ItemsSource = null;
            GridColumn2.Items.Clear();
            GridColumn3.Items.Clear();
        }//клик на ПОИСК МАРШРУТА

        private void SearchStopsMenu()
        {
            GridColumn1.ItemsSource = null;
            GridColumn2.Items.Clear();
            GridColumn3.Items.Clear();
            KursWorkEntities db = new KursWorkEntities();

            string s = Convert.ToString(SeacrhButton.SelectedItem);
            //try
            //{
            IQueryable<Stop> queryableStop = from t in db.Stop
                                             where t.StopName == s
                                             select t;
            ObservableCollection<SomeShit> keka = new ObservableCollection<SomeShit>();
            
            foreach (Stop t in queryableStop)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = t.StopName;
                listBoxItem.Selected += ListBoxItem_Selected;
                GridColumn2.Items.Add(listBoxItem);
            }
            IQueryable<Route> queryableRoute = from t in db.Stop
                                             where t.StopName == s
                                             select t.Route;
            foreach(Route t in queryableRoute)
            {
                SomeShit some = new SomeShit(t.RouteName);
                some.isFav = "true";
                keka.Add(some);
            }
            GridColumn1.ItemsSource = keka;
            


        }//клик на ПОИСК

        private void EnterMenu()
        {
            Registration registration = new Registration(Enter);
            registration.Owner = this;
            registration.Show();
        }//клик на ВХОД
        private void Registraton()
        {
            Registration2 registration2 = new Registration2();
            registration2.Show();
        }//клик на РЕГИСТРАЦИЯ
    }
}