﻿using System;
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
    /// Логика взаимодействия для MovieswatchedPage.xaml
    /// </summary>
    public partial class MovieswatchedPage : Page
    {
        public MovieswatchedPage()
        {
            InitializeComponent();
        }

        List<Movies> list = new List<Movies>();

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("../../movies.dat", FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    Movies example = new Movies(textBoxShowname.Text, textBoxRating.Text);
                    list.Add(example);
                    formatter.Serialize(fs, list);
                }
            }
        }

        private void buttonAddtolist_Click(object sender, RoutedEventArgs e)
        {
            listBoxList.Items.Clear();
            using (FileStream fs = new FileStream("../../movies.dat", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    if (File.Exists("../../movieslist.dat"))
                    {
                        listBoxList.Items.Clear();
                        using (FileStream fs2 = new FileStream("../../movieslist.dat", FileMode.Open))
                        {
                            using (StreamReader sr2 = new StreamReader(fs2, Encoding.UTF8))
                            {
                                string line;
                                while ((line = sr2.ReadLine()) != null)
                                {
                                    listBoxList.Items.Add(line);
                                }
                            }
                        }
                    }
                    BinaryFormatter formatter = new BinaryFormatter();
                    list = (List<Movies>)formatter.Deserialize(fs);
                    for (int i = 0; i < list.Count; i++)
                    {
                        listBoxList.Items.Add(list[i].Showm());
                    }
                }
            }
        }

        private void buttonShowsSearch_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.ShowssearchPage);
        }

        private void buttonMoviesSearch_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.MoviessearchPage);
        }

        private void buttonSavelist_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("../../movieslist.dat", FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    for (int i = 0; i < listBoxList.Items.Count; i++)
                    {
                        listBoxList.SelectedIndex = i;
                        sw.WriteLine(listBoxList.SelectedItem.ToString());
                    }
                }
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            listBoxList.Items.Clear();
            File.WriteAllText("../../movieslist.dat", string.Empty);
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            listBoxList.Items.Clear();
            string[] line = File.ReadAllLines("../../movieslist.dat");
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i].Contains(textBoxSearch.Text) == true)
                {
                    listBoxList.Items.Add(line[i]);
                }
            }
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
