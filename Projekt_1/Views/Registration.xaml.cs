using Projekt_1.DAL;
using Projekt_1.Models;
using Projekt_1.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Projekt_1.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        private Database db;
        public Users user=new Users();
        public Registration()
        {
            InitializeComponent();
            db = Database.getInstanece();
            user.Username = "Username";
            user.Email = "Email";
            Binding b = new Binding();
            b.Source = user;
            b.Path = new PropertyPath("Username");
            b.Mode = BindingMode.TwoWay;
            UsernameBox.SetBinding(TextBox.TextProperty, b);
            b = new Binding();
            b.Source = user;
            b.Path = new PropertyPath("Email");
            b.Mode = BindingMode.TwoWay;
            EmailBox.SetBinding(TextBox.TextProperty, b);
        }

        private void usernameLostFocus(object sender, RoutedEventArgs e)
        {
            if (UsernameBox.Text == "")
            {
                user.Username = "Username";
                UsernameBox.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            }
        }

        private void usernameGotFocus(object sender, RoutedEventArgs e)
        {
            if (user.Username == "Username")
            {
                user.Username = "";
                UsernameBox.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            }
                

        }

        private void emailLostFocus(object sender, RoutedEventArgs e)
        {
            if (EmailBox.Text == "")
            {
                user.Email = "Email";
                EmailBox.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            }
        }

        private void emailGotFocus(object sender, RoutedEventArgs e)
        {
            if (user.Email == "Email")
            {
                user.Email = "";
                EmailBox.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            }
                
        }


        private void passwordLostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password == "")
            {
                PasswordBlock.Visibility = Visibility.Visible;
            }
        }

        private void passwordGotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBlock.Visibility = Visibility.Hidden;
        }

        private void confirmLostFocus(object sender, RoutedEventArgs e)
        {
            if (ConfirmBox.Password == "")
            {
                ConfirmBlock.Visibility = Visibility.Visible;
            }
        }

        private void confirmGotFocus(object sender, RoutedEventArgs e)
        {
            ConfirmBlock.Visibility = Visibility.Hidden;
        }

        private void onRegisterButtonClick(object sender, RoutedEventArgs e)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                BrushConverter converter = new BrushConverter();
                bool dataIsCorrect = true;
                if (user.Username == "Username")
                {
                    UsernameBox.BorderBrush = Brushes.Red;
                    UsernameError.Content = "Please enter a name";
                    UsernameError.Visibility = Visibility.Visible;
                    dataIsCorrect = false;
                }
                else if (db.usernameTaken(user.Username, session))
                {
                    UsernameBox.BorderBrush = Brushes.Red;
                    UsernameError.Content = "Name already taken";
                    UsernameError.Visibility = Visibility.Visible;
                    dataIsCorrect = false;
                }
                else
                {
                    UsernameError.Visibility = Visibility.Collapsed;
                    UsernameBox.BorderBrush = (SolidColorBrush)converter.ConvertFrom("#FFABADB3");
                }
                if (!IsValidEmailAddress(user.Email))
                {
                    EmailBox.BorderBrush = Brushes.Red;
                    EmailError.Visibility = Visibility.Visible;
                    dataIsCorrect = false;
                }
                else if (db.emailTaken(user.Email, session))
                {
                    EmailBox.BorderBrush = Brushes.Red;
                    EmailError.Content = "Email already taken";
                    EmailError.Visibility = Visibility.Visible;
                    dataIsCorrect = false;
                }
                else
                {
                    EmailError.Visibility = Visibility.Collapsed;
                    EmailBox.BorderBrush = (SolidColorBrush)converter.ConvertFrom("#FFABADB3");
                }
                if (PasswordBox.Password.Length < 8)
                {
                    dataIsCorrect = false;
                    if (PasswordBox.Password.Length == 0)
                    {
                        PasswordBox.BorderBrush = Brushes.Red;
                        PasswordError.Content = "Please choose a password";
                        PasswordError.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        PasswordBox.BorderBrush = Brushes.Red;
                        PasswordError.Content = "Password must be at least 8 characters long";
                        PasswordError.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    PasswordError.Visibility = Visibility.Collapsed;
                    PasswordBox.BorderBrush = (SolidColorBrush)converter.ConvertFrom("#FFABADB3");
                }
                if (PasswordBox.Password.Length < 8 || ConfirmBox.Password != PasswordBox.Password)
                {
                    dataIsCorrect = false;
                    if (ConfirmBox.Password.Length == 0)
                    {
                        ConfirmBox.BorderBrush = Brushes.Red;
                        ConfirmationError.Content = "Please confirm password";
                        ConfirmationError.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        ConfirmBox.BorderBrush = Brushes.Red;
                        ConfirmationError.Content = "Passwords don't match";
                        ConfirmationError.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    ConfirmationError.Visibility = Visibility.Collapsed;
                    ConfirmBox.BorderBrush = (SolidColorBrush)converter.ConvertFrom("#FFABADB3");
                }
                if (!dataIsCorrect)
                {
                    return;
                }
                user.Password = PasswordBox.Password;
                db.AddNewUser(user, session);
                NavigationService.GoBack();

            }
        }

        private bool IsValidEmailAddress(string s)
        {
            Regex regex = new Regex(@"^[\w-.]+@([\w-]+.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }

        private void EnterDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                onRegisterButtonClick(sender, e);
            }
        }
    }
}
