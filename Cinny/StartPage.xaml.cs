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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Media.Animation;

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

            DoubleAnimation buttonAnimation = new DoubleAnimation();
            buttonAnimation.From = buttonLogin.ActualWidth;
            buttonAnimation.To = 214;
            buttonAnimation.Duration = TimeSpan.FromSeconds(2);
            buttonLogin.BeginAnimation(Button.WidthProperty, buttonAnimation);
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

        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }


        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            if ((textBoxEmail.Text != "Email address") && (textBoxPassword.Text != "Password"))
            {
                try
                {
                    using (FileStream fs = new FileStream("../../base.dat", FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                        {
                            List<Person> list;
                            BinaryFormatter formatter = new BinaryFormatter();
                            list = (List<Person>)formatter.Deserialize(fs);
                            for (int i = 0; i < list.Count; i++)
                            {
                                if ((list[i].Email == textBoxEmail.Text) && (list[i].Password == CalculateHash(textBoxPassword.Text)))
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
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Check your data again", "Something gone wrong", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }                      
            else
            {
                MessageBox.Show("Check your data again", "Something gone wrong", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
