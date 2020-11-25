using Projekt_1.DAL;
using Projekt_1.Models;
using Projekt_1.NHibernate;
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

namespace Projekt_1.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public string login { get; set ;}
        private Database db;
        public Login()
        {
            InitializeComponent();
            db = Database.getInstanece();
            login = "Username";
            Binding b = new Binding();
            b.Source = this;
            b.Path = new PropertyPath("login");
            b.Mode = BindingMode.TwoWay;
            LoginBox.SetBinding(TextBox.TextProperty, b);
        }


        private void usernameBoxFocused(object sender, RoutedEventArgs e)
        {
            if(login=="Username")
            {
                login = "";
                LoginBox.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            }
            
            
        }

        private void loginBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text == "")
            {
                login = "Username";
                LoginBox.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            }
        }

        private void passwordBoxFocused(object sender, RoutedEventArgs e)
        {
            PasswordBlock.Visibility = Visibility.Hidden;
        }

        private void passwordBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if(PasswordBox.Password=="")
            {
                PasswordBlock.Visibility = Visibility.Visible;
            }
        }

        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                if(db.LogUserIn(login, PasswordBox.Password, session))
                {
                    LoginError.Visibility = Visibility.Collapsed;
                    MainView view = new MainView();
                    NavigationService.Navigate(view);

                }
                else
                {
                    LoginError.Visibility = Visibility.Visible;
                    LoginError.Content = "Wrong username or password";
                }
            }
                
        }

    }
}
