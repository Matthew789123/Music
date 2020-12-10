using Projekt_1.DAL;
using Projekt_1.Models;
using Projekt_1.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        Database db;
        Thread thread;
        public static Player player;
        public MainView()
        {

            InitializeComponent();
            player = new Player(this);
            thread = new Thread(() => MainView.player.threadPlay());
            thread.Start();
            db = Database.getInstanece();
            using(var session=NHibernateHelper.OpenSession())
            {
                foreach(Playlists p in db.GetPlaylists(session))
                {
                    
                    PlaylistListBox.Items.Add(p);
                }
            }
        }


        private void onArtistsButtonClick(object sender, RoutedEventArgs e)
        {
            ItemsDisplay items = new ArtistsDisplay();
            ActivityFrame.NavigationService.Navigate(items);
            items.setViewContent();
        }

        private void onSongsButtonClick(object sender, RoutedEventArgs e)
        {
            ItemsDisplay items = new SongsDisplay();
            ActivityFrame.NavigationService.Navigate(items);
            items.setViewContent();
        }

        private void onAlbumsButtonClick(object sender, RoutedEventArgs e)
        {
            ItemsDisplay items = new AlbumsDisplay();
            ActivityFrame.NavigationService.Navigate(items);
            items.setViewContent();
        }

        private void onAddPlaylistButtonClick(object sender, RoutedEventArgs e)
        {
            AddPlaylistDialog dlg = new AddPlaylistDialog();
            dlg.Owner = Application.Current.MainWindow;
            dlg.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dlg.ShowDialog();
            dlg.Owner = null;
        }

        private void playlistSelected(object sender, SelectionChangedEventArgs e)
        {
            ListBox box = (ListBox)sender;
          
            if (box.SelectedItem == null)
                return;
            ItemsDisplay items = new PlaylistDisplay();
            ActivityFrame.NavigationService.Navigate(items);
            items.setViewContent();
        }

        private void onHomeButtonClick(object sender, RoutedEventArgs e)
        {
            ItemsDisplay items = new HomeDisplay();
            ActivityFrame.NavigationService.Navigate(items);
            items.setViewContent();
        }

        private void timeSkipStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            player.setSliderFlag();
            player.setPauseFlag();
        }

        private void timeSkipDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            player.setSliderTime(timeSlider.Value);
            currentTime.Content = player.sliderTimeValueToString();
            player.setTime(player.getSliderTime());
        }

        private void timeSkipEnded(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            player.setSliderFlag();
            player.setPauseFlag();
        }

        private void closeMainView(object sender, RoutedEventArgs e)
        {
            thread.Abort();
        }
    }
}
