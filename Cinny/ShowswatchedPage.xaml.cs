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

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            List<Shows> list = new List<Shows>();

            using (FileStream fs = new FileStream("../../shows.dat", FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    Shows example = new Shows(textBoxShowname.Text, textBoxSeason.Text, textBoxEpisode.Text, textBoxTime.Text);
                    list.Add(example);
                    formatter.Serialize(fs, list);
                    for (int i = 0; i < list.Count; i++)
                        sw.WriteLine(list[i].Show());

                }

                list = (List<Shows>)formatter.Deserialize(fs);
                for (int i = 0; i < list.Count; i++)
                {
                    string[] line = File.ReadAllLines("../../shows.dat");
                    string[] items = line[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Shows example = new Shows(items[0], items[1], items[2], items[3]);
                    listBoxList.Items.Add(example.Show());
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
    }
}
