using NHibernate;
using Projekt_1.DAL;
using Projekt_1.Models;
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
    /// Interaction logic for ChoosePlaylist.xaml
    /// </summary>
    public partial class ChoosePlaylist : Window
    {
        private Database db = Database.getInstanece();
        private Songs s;
        private ISession session = NHibernateHelper.OpenSession();
        public ChoosePlaylist(Songs s)
        {
            InitializeComponent();
            this.s = s;

            MainWindow window = (MainWindow)Application.Current.MainWindow;
            MainView view = (MainView)window.MainFrame.Content;
            
            List<Playlists> selectedFields = Database.getInstanece().GetPlaylists(session);


            foreach (Playlists p in selectedFields)
            {
                PlaylistsCombo.Items.Add(p);
            }

            PlaylistsCombo.SelectedIndex = 0;
        }


        private void oncloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void onAddClick(object sender, RoutedEventArgs e)
        {

                db.AddSongToPlaylist(s, (Playlists)PlaylistsCombo.SelectedItem, session);
                if (MainView.player.currentPlaylist == (Playlists)PlaylistsCombo.SelectedItem && !MainView.player.getSongs().Contains(s))
                    MainView.player.getSongs().Insert(((Playlists)PlaylistsCombo.SelectedItem).songs.IndexOf(s), s);
            Close();
        }
    }
}
