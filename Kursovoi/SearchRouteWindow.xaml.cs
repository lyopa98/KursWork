using System;
using System.Collections;
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
    /// Логика взаимодействия для SearchRouteWindow.xaml
    /// </summary>
    public partial class SearchRouteWindow : Window
    {
        TextBlock transp;
        TextBlock start;
        TextBlock finish;

        public SearchRouteWindow()
        {
            InitializeComponent();
            Initialzation();
        }

        private void Initialzation()
        {
            KursWorkEntities db = new KursWorkEntities();
            IQueryable<string> queryable = from t in db.Stop
                                           select t.StopName;
            foreach (string s in queryable)
            {
                FromCmb.Items.Add(s);
                WhereCmb.Items.Add(s);
            }
        }

        private void Drow(Grid grid,string one,string two,string transport)
        {
            Grid MainGrid = new Grid();
            ColumnDefinition columnDefinition0 = new ColumnDefinition();
            ColumnDefinition columnDefinition1 = new ColumnDefinition();
            RowDefinition rowDefinition = new RowDefinition();
            MainGrid.RowDefinitions.Add(rowDefinition);
            MainGrid.ColumnDefinitions.Add(columnDefinition0);
            MainGrid.ColumnDefinitions.Add(columnDefinition1);

            transp = new TextBlock();
            transp.HorizontalAlignment = HorizontalAlignment.Center;
            transp.VerticalAlignment = VerticalAlignment.Center;
            transp.Text = transport;
            transp.SetValue(Grid.RowProperty, 0);
            transp.SetValue(Grid.ColumnProperty, 0);
            MainGrid.Children.Add(transp);
            Grid ChildGrid = new Grid();
            RowDefinition rowDefinition0 = new RowDefinition();
            RowDefinition rowDefinition1 = new RowDefinition();
            ColumnDefinition columnDefinition00 = new ColumnDefinition();
            ChildGrid.RowDefinitions.Add(rowDefinition0);
            ChildGrid.RowDefinitions.Add(rowDefinition1);
            ChildGrid.ColumnDefinitions.Add(columnDefinition00);
            start = new TextBlock();
            start.Text = one;
            finish = new TextBlock();
            finish.Text = two;
            start.SetValue(Grid.RowProperty, 0);
            start.SetValue(Grid.ColumnProperty, 0);
            ChildGrid.Children.Add(start);
            finish.SetValue(Grid.RowProperty, 1);
            finish.SetValue(Grid.ColumnProperty, 0);
            ChildGrid.Children.Add(finish);
            ChildGrid.SetValue(Grid.RowProperty, 0);
            ChildGrid.SetValue(Grid.ColumnProperty, 1);
            MainGrid.Children.Add(ChildGrid);
            grid.Children.Add(MainGrid);
        }



        private void SearchRoute(object sender, RoutedEventArgs e)
        {
            Search();
        }
        private void Search()
        {
            #region OLD
            //string s1 = Convert.ToString(FromCmb.SelectedItem);
            //string s2= Convert.ToString(WhereCmb.SelectedItem);

            //List<string> result = new List<string>();
            //if (s1 == "" || s2 == "")
            //{
            //    MessageBox.Show("Заполните поля");
            //    return;
            //}
            //KursWorkEntities db = new KursWorkEntities();

            //var query = db.Stop
            //    .Where(c => c.StopName == s1)
            //    .FirstOrDefault();
            //var query2 = db.Stop
            //    .Where(c => c.StopName == s2)
            //    .FirstOrDefault();

            ////прушинских - ленина
            //// id=2 counter=2
            //int ID = query.StopNum;
            //int counter = query.StopCounter;

            ////прушинских - ленина
            //// id=1 counter=15
            //int ID2 = query2.StopNum;
            //int counter2 = query2.StopCounter;

            //int check = query.StopID;//28
            //int check2=query2.StopID;//24

            //if (ID == ID2)
            //{
            //    if (counter < counter2)
            //    {
            //        IQueryable<string> FinalQuery3 = from t in db.Stop
            //                                         where t.StopNum == ID && t.StopCounter >= counter && t.StopCounter <= counter2
            //                                         select t.StopName;

            //        foreach (string s in FinalQuery3)
            //        {
            //            result.Add(s);
            //        }
            //    }
            //    else
            //    {
            //        IQueryable<string> FinalQuery3 = from t in db.Stop
            //                                         where t.StopNum == ID && t.StopCounter >= counter2 && t.StopCounter <= counter
            //                                         select t.StopName;

            //        foreach (string s in FinalQuery3)
            //        {
            //            result.Add(s);
            //        }
            //        result.Reverse();
            //    }


            //}
            //else if (check < check2)
            //{
            //    IQueryable<string> FinalQuery1 = from t in db.Stop
            //                                     where t.StopNum == ID && t.StopCounter >= counter
            //                                     select t.StopName;

            //    foreach (string s in FinalQuery1)
            //    {
            //        result.Add(s);
            //    }

            //    IQueryable<string> FinalQuery2 = from t in db.Stop
            //                                     where t.StopNum == ID2 && t.StopCounter <= counter2
            //                                     select t.StopName;
            //    foreach (string ss in FinalQuery2)
            //    {
            //        result.Add(ss);
            //    }
            //}
            //else
            //{
            //    query = db.Stop
            //        .Where(c => c.StopName == s2)
            //        .FirstOrDefault();

            //    query2= db.Stop
            //        .Where(c => c.StopName == s1)
            //        .FirstOrDefault();

            //    IQueryable<string> FinalQuery1 = from t in db.Stop
            //                                     where t.StopNum == ID && t.StopCounter <= counter
            //                                     select t.StopName;

            //    foreach (string s in FinalQuery1)
            //    {
            //        result.Add(s);
            //    }
            //    result.Reverse();

            //    IQueryable<string> FinalQuery2 = from t in db.Stop
            //                                     where t.StopNum == ID2 && t.StopCounter >= counter2
            //                                     select t.StopName;
            //    List<string> rez = new List<string>();
            //    foreach (string ss in FinalQuery2)
            //    {
            //        rez.Add(ss);
            //    }
            //    rez.Reverse();
            //    result.AddRange(rez);


            //}
            //    if (result.Count == 0)
            //    {
            //        MessageBox.Show("Подбор маршрута невозможен");
            //    }


            //    foreach (string s in result)
            //    {
            //        MessageBox.Show(s);
            //    }
            #endregion
            Information.Children.Clear();
            Information.Visibility = Visibility.Visible;

            LabelMarsh.Visibility = Visibility.Visible;
            string s1 = Convert.ToString(FromCmb.SelectedItem);
            string s2 = Convert.ToString(WhereCmb.SelectedItem);

            List<string> result = new List<string>();
            if (s1 == "" || s2 == "")
            {
                MessageBox.Show("Заполните поля");
                return;
            }
            KursWorkEntities db = new KursWorkEntities();

            var query = db.Stop
                .Where(c => c.StopName == s1)
                .FirstOrDefault();
            var query2 = db.Stop
                .Where(c => c.StopName == s2)
                .FirstOrDefault();

            int check = query.StopNum;
            int check2 = query2.StopNum;
            int ID = query.StopID;//25 n
            int ID2 = query2.StopID;//28 n

            if (ID2 > ID)
            {

                #region
                //IQueryable<string> queryable = from t in db.Stop
                //                               where t.StopID <= ID2 && t.StopID >= ID
                //                               select t.StopName;
                //foreach (string t in queryable)
                //{
                //    result.Add(t);
                //    MessageBox.Show(t);
                //}
                #endregion
                if (check != check2)
                {
                    IQueryable<string> FinalQuery3 = from t in db.Stop
                                                   where t.StopID <= ID2 && t.StopID >= ID && t.StopNum == check
                                                   select t.StopName;
                    string firstOne= FinalQuery3.ToList().First();
                    string lastOne = FinalQuery3.ToList().Last();

                    var queryable = db.Stop
                         .Where(c => c.StopID <= ID2 && c.StopID >= ID && c.StopNum == check)//для маршрутов с другим id
                        .FirstOrDefault();


                    string info = queryable.Route.RouteType + "  " + queryable.Route.RouteNumber;


                    Drow(Information,firstOne, lastOne, info);

                    //-------------------------------------------------------------------------------------------------------

                    var queryable2 = db.Stop
                         .Where(c => c.StopID <= ID2 && c.StopID >= ID && c.StopNum == check2)//для маршрутов с другим id
                        .FirstOrDefault();

                    IQueryable<string> FinalQuery3_2 = from t in db.Stop
                                                     where t.StopID <= ID2 && t.StopID >= ID && t.StopNum == check2
                                                     select t.StopName;
                    string firstTwo=  FinalQuery3_2.ToList().First();
                    string lastTwo = FinalQuery3_2.ToList().Last();
                    string info2 = queryable2.Route.RouteType + "  " + queryable2.Route.RouteNumber;
                    Information2.Visibility = Visibility.Visible;
                    Drow(Information2, firstTwo, lastTwo, info2);
                }
                else
                {
                    var queryable = db.Stop
                        .Where(c => c.StopID <= ID2 && c.StopID >= ID)
                        .FirstOrDefault();
                    string info = queryable.Route.RouteNumber + "  " + queryable.Route.RouteType;


                    IQueryable<string> queryable22 = from t in db.Stop
                                                     where t.StopID <= ID2 && t.StopID >= ID
                                                     select t.StopName;

                    string firstTwo = queryable22.ToList().First();
                    string lastTwo = queryable22.ToList().Last();
                    Drow(Information,firstTwo, lastTwo, info);
                }
            }
            else if (ID2 < ID)
            {
                if (check != check2)
                {

                    var queryable = db.Stop
                    .Where(c => c.StopID <= ID2 && c.StopID >= ID && c.StopNum == check)//для маршрутов с другим id
                    .FirstOrDefault();

                    IQueryable<string> FinalQuery3 = from t in db.Stop
                                                   where t.StopID <= ID2 && t.StopID >= ID && t.StopNum == check
                                                   select t.StopName;
                    string firstOne = FinalQuery3.ToList().First();
                    string lastOne = FinalQuery3.ToList().Last();
                    string info = queryable.Route.RouteType + "  " + queryable.Route.RouteNumber;
                    Drow(Information, firstOne, lastOne, info);


                    IQueryable<string> FinalQuery3_2 = from t in db.Stop
                                                     where t.StopID <= ID2 && t.StopID >= ID && t.StopNum == check2
                                                     select t.StopName;
                    var queryable2 = db.Stop
                        .Where(c => c.StopID <= ID2 && c.StopID >= ID && c.StopNum == check)//для маршрутов с другим id
                        .FirstOrDefault();


                    string firstTwo = FinalQuery3_2.ToList().First();
                    string lastTwo = FinalQuery3_2.ToList().Last();
                    string info2 = queryable2.Route.RouteType + "  " + queryable2.Route.RouteNumber;
                    Information2.Visibility = Visibility.Visible;
                    Drow(Information2, firstTwo, lastTwo, info2);

                }
                else
                {
                    IQueryable<string> queryable = from t in db.Stop
                                                   where t.StopID <= ID && t.StopID >= ID2
                                                   select t.StopName;
                    var queryableInf = db.Stop
                    .Where(c => c.StopID <= ID && c.StopID >= ID2)
                    .FirstOrDefault();

                    string info = queryableInf.Route.RouteNumber + "  " + queryableInf.Route.RouteType;

                    foreach (string t in queryable)
                    {
                        result.Add(t);
                        
                    }
                    result.Reverse();
                    string firstOne = result.First();
                    string firstTwo = result.Last();
                    Drow(Information,firstOne, firstTwo, info);
                }
            }
        }
    }
}
