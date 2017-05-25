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
using System.Windows.Media.Animation;

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

            DoubleAnimation buttonAnimation = new DoubleAnimation();
            buttonAnimation.From = buttonSignup1.ActualWidth;
            buttonAnimation.To = 214;
            buttonAnimation.Duration = TimeSpan.FromSeconds(2);
            buttonSignup1.BeginAnimation(Button.WidthProperty, buttonAnimation);
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

        private void buttonLogin1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.StartPage);
        }

        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        List<Person> list = new List<Person>();
        private void buttonSignup1_Click(object sender, RoutedEventArgs e)
        {
            if ((textBoxEmail.Text != "") && (textBoxPassword.Text != "") && (textBoxEmail.Text != "Email address") && (textBoxPassword.Text != "Password"))
            {
                using (FileStream fs = new FileStream("../../base.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        Person example = new Person(textBoxEmail.Text, CalculateHash(textBoxPassword.Text));
                        list.Add(example);
                        formatter.Serialize(fs, list);
                        MessageBox.Show("Signing up has passed successfully!");      
                    }
                }
            }
            else
            {
                MessageBox.Show("Check your data again", "Something gone wrong", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
