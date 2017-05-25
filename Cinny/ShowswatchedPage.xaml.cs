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
    /// Логика взаимодействия для ShowsSearch.xaml
    /// </summary>
    public partial class ShowswatchedPage : Page
    {
        public ShowswatchedPage()
        {
            InitializeComponent();
        }

        List<Shows> list = new List<Shows>();

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("../../shows.dat", FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    Shows example = new Shows(textBoxShowname.Text, textBoxSeason.Text, textBoxEpisode.Text, textBoxTime.Text);
                    list.Add(example);
                    formatter.Serialize(fs, list);
                }
            }
        }

        private void buttonAddtolist_Click(object sender, RoutedEventArgs e)
        {
            listBoxList.Items.Clear();
            using (FileStream fs = new FileStream("../../shows.dat", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    if (File.Exists("../../showslist.dat"))
                    {
                        listBoxList.Items.Clear();
                        using (FileStream fs2 = new FileStream("../../showslist.dat", FileMode.Open))
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
                    list = (List<Shows>)formatter.Deserialize(fs);
                    for (int i = 0; i < list.Count; i++)
                    {
                        listBoxList.Items.Add(list[i].Show());
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
            using (FileStream fs = new FileStream("../../showslist.dat", FileMode.OpenOrCreate))
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
            File.WriteAllText("../../showslist.dat", string.Empty);
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            //listBoxList.Items.Clear();
            //List<Shows> showslist = new List<Shows>();
            //string[] line = File.ReadAllLines("../../showslist.dat"); 
            //for (int i = 0; i < line.Length; i++)
            //{
            //    string[] items = line[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //    Shows example = new Shows(items[0], items[1], items[2], items[3]);
            //    showslist.Add(example);
            //}
            //for (int j = 0; j < showslist.Count; j++)
            //{
            //    if (showslist[j].Name == textBoxSearch.Text)
            //        {
            //        listBoxList.Items.Add(showslist[j].Show());
            //        }
            //}
            listBoxList.Items.Clear();
            string[] line = File.ReadAllLines("../../showslist.dat");
            for (int i = 0; i < line.Length; i++)
            {
                //string[] items = line[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //Shows example = new Shows(items[0], items[1], items[2], items[3]);
                if (line[i].Contains(textBoxSearch.Text) == true)
                {
                    listBoxList.Items.Add(line[i]);
                }
            }
        }
    }
}
