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
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void buttonSignup_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.SignupPage);
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

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("../../base.dat", FileMode.Open, FileAccess.Read))
            {
                var person = new Person(textBoxEmail.Text, textBoxPassword.Text);
                try
                {
                    List<Person> list = new List<Person>();
                    BinaryFormatter formatter = new BinaryFormatter();
                    list = (List<Person>)formatter.Deserialize(fs);
                    if (textBoxEmail.Text == person.Email && textBoxPassword.Text == person.Password)
                    {
                        NavigationService.Navigate(Pages.ShowswatchedPage);
                    }
                    else
                    {
                        MessageBox.Show("Something gone wrong. Check your data again");
                    }
                }
                catch
                {
                    MessageBox.Show("Something gone wrong. Check your data again");
                }
            }
        }
    }
}
