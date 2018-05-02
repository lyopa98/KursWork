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
        }
        public class SomeShit
        {
            public string text { get; set; }

            public string pict { get; set; }

            public SomeShit(string str)
            {
                text = str;
                pict = "Resourses\\Images\\FavoritePainted.png";
            }


        }


        private void SeacrhButton_GotFocus(object sender, RoutedEventArgs e)
        {
            SeacrhButton.Text = "";
        }

        int countBl = 0; 

#region Cars
        private void Autobus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("E:\\Учёба\\C#\\II semestr\\Kursovoi\\Kursovoi\\Resourses\\Transport\\Autobus.xaml")
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror: " + ex.Message);
            }
            GridColumn1.Items.Clear();
            TitleOfSelected.Text = "Автобус";

            ListBox AutobusBox = new ListBox();

            

            ListBoxItem listBoxItem = new ListBoxItem();

            //listBoxItem.Width = 358;
            //listBoxItem.Height = 30;
            ListBoxItem listBoxItem1 = new ListBoxItem();


            KursWorkEntities db = new KursWorkEntities();

            List<Route> queryable = db.Route.ToList();

            listBoxItem.Content = queryable[0].Number+"   "+ queryable[0].Name;
            listBoxItem.Selected += ListBoxItem_Selected;

            listBoxItem1.Content = queryable[1].Number + "   "+ queryable[1].Name;

            if (GridColumn1.Items.Count == 0)
            {
                GridColumn1.Items.Add(listBoxItem);
                GridColumn1.Items.Add(listBoxItem1);
            }
            else
            {
                GridColumn1.Items.Clear();
                GridColumn1.Items.Add(listBoxItem);
                GridColumn1.Items.Add(listBoxItem1);
            }


        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            GridColumn2.Items.Clear();

            ListBoxItem listBox = (ListBoxItem)sender;
            string temp = Convert.ToString(listBox.Content);
            int numberRoat = 0;
            string sad = "";
            for (int i=0;i<temp.Length;i++)
            {
                if (temp[i] != ' ')
                {
                    sad+= temp[i];
                }
                else break;
            }



            numberRoat = Convert.ToInt32(sad);

            KursWorkEntities db = new KursWorkEntities();

            IQueryable<Stop> queryable = from t in db.Stop where t.StopNum == numberRoat select t;

            foreach(Stop st in queryable)
            {
                GridColumn2.Items.Add(st.StopCounter + ".  " + st.StopName);
            }

            

        }

        private void Trolleibus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("E:\\Учёба\\C#\\II semestr\\Kursovoi\\Kursovoi\\Resourses\\Transport\\Trolleibus.xaml")
                };
            }catch(Exception ex)
            {
                MessageBox.Show("Eror: "+ex.Message);
            }
            TitleOfSelected.Text = "Троллейбус";
            GridColumn1.Items.Clear();


            ListBox AutobusBox = new ListBox();



            ListBoxItem listBoxItem = new ListBoxItem();

            ListBoxItem listBoxItem1 = new ListBoxItem();
            Image image = new Image();
            image.Width = 20;
            image.Height = 20;
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("Right.png", UriKind.Relative);
            bi3.EndInit();
            image.Stretch = Stretch.Fill;
            image.Source = bi3;

            //StackPanel stackPanel = new StackPanel();
            //ContentControl contentControl = new ContentControl();
            //contentControl.Content = image;

            //как добавить в listitem к тексту картинку



            listBoxItem.Content = "sdffsa";


            listBoxItem1.Content = "asdasasfsafaqdqd";
            if(GridColumn1.Items.Count==0)
            {
                GridColumn1.Items.Add(listBoxItem);
                GridColumn1.Items.Add(listBoxItem1);
            }
            else
            {
                GridColumn1.Items.Clear();
                GridColumn1.Items.Add(listBoxItem);
                GridColumn1.Items.Add(listBoxItem1);
            }


        }

        private void Tramvai_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("E:\\Учёба\\C#\\II semestr\\Kursovoi\\Kursovoi\\Resourses\\Transport\\Tramvai.xaml")
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror: " + ex.Message);
            }
            TitleOfSelected.Text = "Трамвай";
            GridColumn1.Items.Clear();



            ListBoxItem listBoxItem = new ListBoxItem();

            ListBoxItem listBoxItem1 = new ListBoxItem();
            Image image = new Image();
            image.Width = 20;
            image.Height = 20;
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("Right.png", UriKind.Relative);
            bi3.EndInit();
            image.Stretch = Stretch.Fill;
            image.Source = bi3;

            //StackPanel stackPanel = new StackPanel();
            //ContentControl contentControl = new ContentControl();
            //contentControl.Content = image;

            //как добавить в listitem к тексту картинку



            listBoxItem.Content = image+"qedsasda";


            listBoxItem1.Content = "rrrrrrrrrrrr";
            if (GridColumn1.Items.Count == 0)
            {
                GridColumn1.Items.Add(listBoxItem);
                GridColumn1.Items.Add(listBoxItem1);
            }
            else
            {
                GridColumn1.Items.Clear();
                GridColumn1.Items.Add(listBoxItem);
                GridColumn1.Items.Add(listBoxItem1);
            }
        }

        #endregion


#region MainButtons
        private void MITimetable_Click(object sender, RoutedEventArgs e)
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


            if (MainMenu.Items.Count == 10)
            {
                MainMenu.Items.RemoveAt(4);
                MainMenu.Items.RemoveAt(3);
                MainMenu.Items.RemoveAt(2);
            }
            else
            {
                MainMenu.Items.Insert(2, Autobus);
                MainMenu.Items.Insert(3, Trolleibus);
                MainMenu.Items.Insert(4, Tramvai);
            }

            #region
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



        }

        
        private void MIStation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("E:\\Учёба\\C#\\II semestr\\Kursovoi\\Kursovoi\\Resourses\\Stations.xaml")
                };
            }catch(Exception ex)
            {
                MessageBox.Show("Eror:" + ex.Message);
            }
            TitleOfSelected.Text = "Остановки";
            GridColumn1.Items.Clear();
            GridColumn2.Items.Clear();


            KursWorkEntities db = new KursWorkEntities();

            IQueryable<Stop> queryable = from t in db.Stop select t;
            IQueryable<string> queryableR = from t in db.Stop where t.Route.Number == t.StopNum select t.Route.Type;
            List<string> temp = queryableR.ToList();
            int i = 0;



            ObservableCollection<SomeShit> keka = new ObservableCollection<SomeShit>();

            ListBox StopBox = new ListBox();

            foreach(Stop ds in queryable)
            {
                //GridColumn1.Items.Add(temp[i]+"  "+ds.StopCounter + ".  " + ds.StopName);
                //keka.Add(new SomeShit(temp[i] + "  " + ds.StopCounter + ".  " + ds.StopName));
                ListBoxItem item = new ListBoxItem();
                keka.Add(new SomeShit(temp[i] + "  " + ds.StopCounter + ".  " + ds.StopName));
                i++;
            }
          
            //listBoxItem.Content = queryable[0].Number + "   " + queryable[0].Name;
            //listBoxItem.Selected += ListBoxItem_Selected;
            GridColumn1.ItemsSource = keka;

            

            


        }


        
        private void MIMetroStation_Click(object sender, RoutedEventArgs e)
        {

            GridColumn1.Items.Clear();
#region
            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("E:\\Учёба\\C#\\II semestr\\Kursovoi\\Kursovoi\\Resourses\\MetroStations.xaml")
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror:" + ex.Message);
            }

#endregion

            TitleOfSelected.Text = "Станции метро";



            ListBoxItem listBox1 = new ListBoxItem();
            ListBoxItem listBox2 = new ListBoxItem();


            listBox1.Selected += GridColumn1_Selected;
            listBox2.Selected += GridColumn2_Selected;

            KursWorkEntities dB = new KursWorkEntities();


            var temp2 = dB.Metro.ToList();


            listBox1.Content = temp2[0].NameBranch;
            listBox2.Content = temp2[1].NameBranch;

            GridColumn1.Items.Add(listBox1);
            GridColumn1.Items.Add(listBox2);



        }

        
        private void MINews_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("E:\\Учёба\\C#\\II semestr\\Kursovoi\\Kursovoi\\Resourses\\News.xaml")
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror:" + ex.Message);
            }

            TitleOfSelected.Text = "Новости";
            GridColumn1.Items.Clear();
        }
        
        private void MIFavorites_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("E:\\Учёба\\C#\\II semestr\\Kursovoi\\Kursovoi\\Resourses\\Favorites.xaml")
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror:" + ex.Message);
            }
            TitleOfSelected.Text = "Избранное";
            GridColumn1.Items.Clear();


            //ЭТОТ КУСОК КОДА ПОТОМ УБРАТЬ!!!!!
            using (KursWorkEntities db = new KursWorkEntities())
            {
                foreach(Users user in db.Users)
                {
                    GridColumn1.Items.Add(user.ToString());
                }
            }
            //------------------------------------------


        }

        
        private void MIInformation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("E:\\Учёба\\C#\\II semestr\\Kursovoi\\Kursovoi\\Resourses\\Information.xaml")
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror:" + ex.Message);
            }

            TitleOfSelected.Text = "Информация";
            GridColumn1.Items.Clear();
        }
        #endregion

        private void EnterBut(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registration2 registration2 = new Registration2();
            registration2.Show();
        }

        private void GridColumn2_Selected(object sender, RoutedEventArgs e)//ID=2
        {
            GridColumn2.Items.Clear();

            using (KursWorkEntities db = new KursWorkEntities())
            {

                IQueryable<Metro_Branch> temp2 = from tt in db.Metro_Branch
                                                 where tt.Number == 2
                                                 select tt;
                int countStation = 1;
                foreach (Metro_Branch qw in temp2)
                {
                    GridColumn2.Items.Add(countStation+". "+qw.NameStation);
                    countStation++;
                }
            }
        }


            private void GridColumn1_Selected(object sender, RoutedEventArgs e)//ID=1
        {
            GridColumn2.Items.Clear();
            using (KursWorkEntities db = new KursWorkEntities())
            {


                //надо взять те значения из MetroBranch, где number = id из metro
                //надо взять только то id , которое выбрано(selected)
             IQueryable<Metro_Branch> temp2 = from tt in db.Metro_Branch
                                          where tt.Number == 1
                                          select tt;



                // IQueryable < Metro_Branch > mBranch = from t in db.Metro_Branch where t.Number == db.Metro.

                //IQueryable <Metro_Branch> temp = from t in db.Metro_Branch
                //                                 where t.Number==temp2.




                //foreach ()
                //{
                //    GridColumn2.Items.Add();
                //}



                int countStation = 1;
                foreach (Metro_Branch qw in temp2)
                {
                    GridColumn2.Items.Add(countStation + ". " + qw.NameStation);
                    countStation++;
                }


            }


        }

        private void GridColumn1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FavoriteBtn(object sender, RoutedEventArgs e)
        {
            Button self = (Button)sender;
            string nameOstanovka = (string)self.Tag;
            MessageBox.Show(nameOstanovka);
        }
    }
}
