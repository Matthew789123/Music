using Projekt_1.DAL;
using Projekt_1.Models;
using Projekt_1.NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class ItemsDisplay : Page
    {
        private Database db;
        public string searchBar { get; set; }
        public ItemsDisplay()
        {
            InitializeComponent();
            db = Database.getInstanece();

            searchBar = "Search";
            Binding b = new Binding();
            b.Source = this;
            b.Path = new PropertyPath("searchBar");
            b.Mode = BindingMode.TwoWay;
            SearchBar.SetBinding(TextBox.TextProperty, b);


        }

        public void getAllArtists()
        {
            var gridView = new GridView();
            this.ItemsContainer.View = gridView;
            ItemsLabel.Content = "ARTISTS";
            GenresList.Visibility = Visibility.Hidden;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Name",
                DisplayMemberBinding = new Binding("Name")
            });
            using(var session = NHibernateHelper.OpenSession())
            {
                foreach (Artists a in db.GetAll<Artists>(session))
                {
                    ItemsContainer.Items.Add(a);
                }
            }
          
        }

        public void getAllAlbums()
        {
            var gridView = new GridView();
            this.ItemsContainer.View = gridView;
            ItemsLabel.Content = "ALBUMS";
            GenresList.Visibility = Visibility.Hidden;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Title",
                DisplayMemberBinding = new Binding("Title")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Release date",
                DisplayMemberBinding = new Binding("Release_date")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Artists",
                DisplayMemberBinding = new Binding("artistsToString")
            });

            using (var session = NHibernateHelper.OpenSession())
            {
                foreach (Albums a in db.GetAll<Albums>(session))
                {
                    a.artists.ToString();
                    ItemsContainer.Items.Add(a);
                }
            }
                
        }


        public void getPlaylistSongs(Playlists playlist)
        {
            var gridView = new GridView();
            this.ItemsContainer.View = gridView;
            ItemsLabel.Content = "PLAYLIST";

            GenresList.Visibility = Visibility.Visible;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Title",
                DisplayMemberBinding = new Binding("Title")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Release date",
                DisplayMemberBinding = new Binding("Release_date")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Duration",
                DisplayMemberBinding = new Binding("Duration")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Genre",
                DisplayMemberBinding = new Binding("genresToString")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Artists",
                DisplayMemberBinding = new Binding("artistsToString")
            });
            
            using(var session=NHibernateHelper.OpenSession())
            {
                foreach (Songs s in db.GetSongsFromPlaylist(playlist,session))
                {
                    s.genres.ToString();
                    s.artists.ToString();

                    ItemsContainer.Items.Add(s);
                }
            }
            
        }


        public void getAllSongs()
        {
            var gridView = new GridView();
            this.ItemsContainer.View = gridView;
            ItemsLabel.Content = "SONGS";
           
            GenresList.Visibility = Visibility.Visible;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Title",
                DisplayMemberBinding = new Binding("Title")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Release date",
                DisplayMemberBinding = new Binding("Release_date")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Duration",
                DisplayMemberBinding = new Binding("Duration")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Genre",
                DisplayMemberBinding = new Binding("genresToString")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Artists",
                DisplayMemberBinding = new Binding("artistsToString")
            });
           
            using (var session = NHibernateHelper.OpenSession())
            {
                foreach (Songs s in db.GetAll<Songs>(session))
                {
                    s.genres.ToString();
                    s.artists.ToString();

                    ItemsContainer.Items.Add(s);
                }
            }





        }

        private void SearchBarGotFocus(object sender, RoutedEventArgs e)
        {
            if (searchBar == "Search")
            {
                searchBar = "";
                SearchBar.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            }
        }

        private void SearchBarLostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBar.Text == "")
            {
                searchBar = "Search";
                SearchBar.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            }
        }

        private void onSearchButtonClick(object sender, RoutedEventArgs e)
        {
            SearchBar.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            using (var session=NHibernateHelper.OpenSession())
            {
                ItemsContainer.Items.Clear();
                if (ItemsLabel.Content.ToString() == "SONGS")
                {
                    foreach (Songs s in db.SearchForSong(searchBar, session))
                    {
                        s.genres.ToString();
                        s.artists.ToString();
                        ItemsContainer.Items.Add(s);
                    }
                }
                else if(ItemsLabel.Content.ToString() == "PLAYLIST")
                {
                    MainWindow window = (MainWindow)Application.Current.MainWindow;
                    MainView view = (MainView)window.MainFrame.Content;
                    foreach (Songs s in db.GetSongsFromPlaylist((Playlists)view.PlaylistListBox.SelectedItem,session))
                    {
                        if (s.Title.Contains(searchBar))
                        {
                            s.genres.ToString();
                            s.artists.ToString();
                            ItemsContainer.Items.Add(s);
                        }
                        
                    }
                }
                else if (ItemsLabel.Content.ToString() == "ARTISTS")
                {
                    foreach (Artists a in db.SearchForArtist(searchBar, session))
                    {
  
                        ItemsContainer.Items.Add(a);
                    }
                }
                else if (ItemsLabel.Content.ToString() == "ALBUMS")
                {
                    foreach (Albums a in db.SearchForAlbums(searchBar, session))
                    {
                        a.artists.ToString();
                        ItemsContainer.Items.Add(a);
                    }
                }


            }
        }
    }
}
