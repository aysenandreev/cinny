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
using System.Windows.Shapes;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cinny
{
    /// <summary>
    /// Логика взаимодействия для Moviessearch.xaml
    /// </summary>
    public partial class MoviessearchPage : Page
    {
        public MoviessearchPage()
        {
            InitializeComponent();
        }
        private void buttonShowsSearch_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.ShowssearchPage);
        }

        private void buttonShowsPlans_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pages.ShowsplansPage.listBoxList.Items.Clear();
                using (FileStream fs3 = new FileStream("../../showsplanslist.dat", FileMode.Open))
                {
                    using (StreamReader sr3 = new StreamReader(fs3, Encoding.UTF8))
                    {
                        string line2;
                        while ((line2 = sr3.ReadLine()) != null)
                        {
                            Pages.ShowsplansPage.listBoxList.Items.Add(line2);
                        }
                    }
                }
            }

            catch
            {
                NavigationService.Navigate(Pages.ShowsplansPage);
            }
            NavigationService.Navigate(Pages.ShowsplansPage);
        }

        private void buttonMoviesWatched_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pages.MovieswatchedPage.listBoxList.Items.Clear();
                using (FileStream fs3 = new FileStream("../../movieslist.dat", FileMode.Open))
                {
                    using (StreamReader sr3 = new StreamReader(fs3, Encoding.UTF8))
                    {
                        string line2;
                        while ((line2 = sr3.ReadLine()) != null)
                        {
                            Pages.MovieswatchedPage.listBoxList.Items.Add(line2);
                        }
                    }
                }
            }

            catch
            {
                NavigationService.Navigate(Pages.MovieswatchedPage);
            }
            NavigationService.Navigate(Pages.MovieswatchedPage);
        }

        private void buttonShowsWatched_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pages.ShowswatchedPage.listBoxList.Items.Clear();
                using (FileStream fs3 = new FileStream("../../showslist.dat", FileMode.Open))
                {
                    using (StreamReader sr3 = new StreamReader(fs3, Encoding.UTF8))
                    {
                        string line2;
                        while ((line2 = sr3.ReadLine()) != null)
                        {
                            Pages.ShowswatchedPage.listBoxList.Items.Add(line2);
                        }
                    }
                }
            }

            catch
            {
                NavigationService.Navigate(Pages.ShowswatchedPage);
            }

            NavigationService.Navigate(Pages.ShowswatchedPage);
        }

        private void buttonMoviesPlans_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pages.MoviesplansPage.listBoxList.Items.Clear();
                using (FileStream fs3 = new FileStream("../../moviesplanslist.dat", FileMode.Open))
                {
                    using (StreamReader sr3 = new StreamReader(fs3, Encoding.UTF8))
                    {
                        string line2;
                        while ((line2 = sr3.ReadLine()) != null)
                        {
                            Pages.MoviesplansPage.listBoxList.Items.Add(line2);
                        }
                    }
                }
            }

            catch
            {
                NavigationService.Navigate(Pages.MoviesplansPage);
            }
            NavigationService.Navigate(Pages.MoviesplansPage);
        }
    }
}
