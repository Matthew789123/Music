using Projekt_1.DAL;
using Projekt_1.NHibernate;
using Projekt_1.Views;
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
using System.Windows.Shapes;

namespace Projekt_1
{
    /// <summary>
    /// Interaction logic for AddPlaylistDialog.xaml
    /// </summary>
    public partial class AddPlaylistDialog : Window
    {
        public string name { get; set; }
        Database db;
        public AddPlaylistDialog()
        {
            InitializeComponent();
            db = Database.getInstanece();
            Binding b = new Binding();
            name = "Name";
            b.Source = this;
            b.Path=new PropertyPath("name");
            b.Mode = BindingMode.TwoWay;
            NewPlaylistName.SetBinding(TextBox.TextProperty, b);
        }

        private void textBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if(NewPlaylistName.Text=="")
            {
                name = "Name";
                NewPlaylistName.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
                
            }

        }

        private void textBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if(name=="Name")
            {
                name = "";
                NewPlaylistName.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            }
            
        }

        private void onCreateClick(object sender, RoutedEventArgs e)
        {
            if(name=="Name" || name=="Your Favourites")
            {
                return;
            }
            using(var session=NHibernateHelper.OpenSession())
            {
                
                MainWindow window = (MainWindow)Application.Current.MainWindow;
                MainView view = (MainView)window.MainFrame.Content;
                view.PlaylistListBox.Items.Add(db.AddNewPlaylist(name, session));
            }
            Close();
        }

        private void oncloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
