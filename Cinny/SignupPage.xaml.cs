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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Security.Cryptography;

namespace Cinny
{
    /// <summary>
    /// Логика взаимодействия для SignupPage.xaml
    /// </summary>
    public partial class SignupPage : Page
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        Color color = (Color)ColorConverter.ConvertFromString("#FFCBC2C2");

        bool _emailEntered = false;

        private void textBoxEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!_emailEntered)
            {
                textBoxEmail.Text = "";
                textBoxEmail.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void textBoxEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxEmail.Text))
                _emailEntered = true;
            else
            {
                textBoxEmail.Text = "Email address";
                _emailEntered = false;
                textBoxEmail.Foreground = new SolidColorBrush(color);
            }
        }

        bool _passwordEntered = false;

        private void textBoxPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!_passwordEntered)
            {
                textBoxPassword.Text = "";
                textBoxPassword.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void textBoxPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxPassword.Text))
                _passwordEntered = true;
            else
            {
                textBoxPassword.Text = "Password";
                _passwordEntered = false;
                textBoxPassword.Foreground = new SolidColorBrush(color);
            }
        }

        bool _nameEntered = false;

        private void textBoxName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!_nameEntered)
            {
                textBoxName.Text = "";
                textBoxName.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void textBoxName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxName.Text))
                _nameEntered = true;
            else
            {
                textBoxName.Text = "Name";
                _nameEntered = false;
                textBoxName.Foreground = new SolidColorBrush(color);
            }
        }

        private void buttonLogin1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.StartPage);
        }

        List<Person> list = new List<Person>();

        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        private void buttonSignup1_Click(object sender, RoutedEventArgs e)
        {
            var person = new Person(textBoxName.Text, textBoxEmail.Text, CalculateHash(textBoxPassword.Text));
            list.Add(person);


            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("../../base.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    list = (List<Person>)formatter.Deserialize(fs);
                }
                catch
                {
                    list = new List<Person>();
                }
            }
            using (FileStream fs = new FileStream("../../base.dat", FileMode.Open))
            {
                formatter.Serialize(fs, list);
            }
        }
    }
}
