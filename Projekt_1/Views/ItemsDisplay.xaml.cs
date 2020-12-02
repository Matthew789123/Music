﻿using Projekt_1.DAL;
using Projekt_1.Models;
using Projekt_1.NHibernate;
using Projekt_1.Controls;
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
using Projekt_1.Views;
using Projekt_1;

namespace Projekt_1.Views 
{
    /// <summary>
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public abstract partial class ItemsDisplay : Page
    {
        protected Database db;
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

        public abstract void setViewContent();


        protected void SearchBarGotFocus(object sender, RoutedEventArgs e)
        {
            if (searchBar == "Search")
            {
                searchBar = "";
                SearchBar.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            }
        }

        protected void SearchBarLostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBar.Text == "")
            {
                searchBar = "Search";
                SearchBar.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            }
        }

        protected void onSearchButtonClick(object sender, RoutedEventArgs e)
        {
 
            SearchBar.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if(SearchBar.Text =="Search")
            {
                return;
            }
            ItemsContainer.Items.Clear();
            filterContent();
        }

        protected abstract void filterContent();
        
        protected virtual void SelectItem(object sender, SelectionChangedEventArgs e) { }

        protected virtual void OnDeleteButtonClick(object sender, RoutedEventArgs e) { }

        protected virtual void onUnloaded(object sender, RoutedEventArgs e) { }

 

        protected virtual void AddArtistToFavourites(object sender, EventArgs e) { }

        protected virtual void FavouriteStatus(object sender, RoutedEventArgs e) { }

        protected virtual void RemoveArtistsFromFavourites(object sender, EventArgs e) { }

    }
}

public class ArtistsDisplay : ItemsDisplay
{
    private List<Artists> favouriteArtists;
    private bool add;
    public ArtistsDisplay() : base()
    {    

        ItemsLabel.Content = "ARTISTS";
        
        ItemsGrid.Columns.Add(new GridViewColumn
        {
            HeaderContainerStyle = (Style)FindResource("HeaderStyle"),
            Header = "Name",
            DisplayMemberBinding = new Binding("Name")
        }) ;
        ItemsGrid.Columns.Add(new GridViewColumn
        {
            HeaderContainerStyle = (Style)FindResource("HeaderStyle"),
            CellTemplate = (DataTemplate)this.Resources["AddToFavourites"]
        });
        using(var session=NHibernateHelper.OpenSession())
        {
            favouriteArtists = db.GetUserFavouritesArtists(session);
            int a = 18;
        }
        
    }

    public override void setViewContent()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            foreach (Artists a in db.GetAll<Artists>(session))
            {
                ItemsContainer.Items.Add(a);
            }
        }
    }

    protected override void filterContent()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            foreach (Artists a in db.SearchForArtist(searchBar, session))
            {
                ItemsContainer.Items.Add(a);
            }
        }
    }

    protected override void AddArtistToFavourites(object sender, EventArgs e)
    {
        if (!add)
        {
            return;
        }
        Favourites ch = (Favourites)sender;
        Artists a = (Artists)ch.DataContext;
        using(var session=NHibernateHelper.OpenSession())
        {
            db.AddArtistToFavourites(a, session);
        }
    
    }
    protected override void FavouriteStatus(object sender, RoutedEventArgs e)
    {
        add = false;
        Favourites ch = (Favourites)sender;
        Artists a = (Artists)ch.DataContext;
        if (favouriteArtists.Find(x=>x.Id==a.Id)!=null)
        {
            ch.CheckBox1.IsChecked = true;
        }
        add = true;
    }
    protected override void RemoveArtistsFromFavourites(object sender, EventArgs e)
    {
        Favourites ch = (Favourites)sender;
        Artists a = (Artists)ch.DataContext;
        using(var session = NHibernateHelper.OpenSession())
        {
            db.RemoveArtistFromFavourites(a, session);
        }
    }
}

public class AlbumsDisplay : ItemsDisplay
{
    public AlbumsDisplay() : base()
    {
        ItemsLabel.Content = "ALBUMS";
        
        ItemsGrid.Columns.Add(new GridViewColumn
        {
            HeaderContainerStyle=(Style) FindResource("HeaderStyle"),
            Header = "Title",
            DisplayMemberBinding = new Binding("Title")
        });
        ItemsGrid.Columns.Add(new GridViewColumn
        {
            HeaderContainerStyle = (Style)FindResource("HeaderStyle"),
            Header = "Release date",
            DisplayMemberBinding = new Binding("Release_date")
        });
        ItemsGrid.Columns.Add(new GridViewColumn
        {
            HeaderContainerStyle = (Style)FindResource("HeaderStyle"),
            Header = "Artists",
            DisplayMemberBinding = new Binding("artistsToString")
        });
        ItemsGrid.Columns.Add(new GridViewColumn
        {
            HeaderContainerStyle = (Style)FindResource("HeaderStyle"),
            CellTemplate = (DataTemplate)this.Resources["AddPlaylist"]
        });
    }

    public override void setViewContent()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            foreach (Albums a in db.GetAll<Albums>(session))
            {
                a.artists.ToString();
                ItemsContainer.Items.Add(a);
            }
        }
    }

    protected override void filterContent()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            foreach (Albums a in db.SearchForAlbums(searchBar, session))
            {
                a.artists.ToString();
                ItemsContainer.Items.Add(a);
            }
        }
    }
}

public class SongsDisplay : ItemsDisplay
{
    public SongsDisplay() : base()
    {

        ItemsLabel.Content = "SONGS";
        ItemsGrid.Columns.Add(new GridViewColumn
        {
            HeaderContainerStyle = (Style)FindResource("HeaderStyle"),
            Header = "Title",
            DisplayMemberBinding = new Binding("Title")
        });
        ItemsGrid.Columns.Add(new GridViewColumn
        {
            HeaderContainerStyle = (Style)FindResource("HeaderStyle"),
            Header = "Release date",
            DisplayMemberBinding = new Binding("Release_date")
        });
        ItemsGrid.Columns.Add(new GridViewColumn
        {
            HeaderContainerStyle = (Style)FindResource("HeaderStyle"),
            Header = "Duration",
            DisplayMemberBinding = new Binding("Duration")
        });
        ItemsGrid.Columns.Add(new GridViewColumn
        {
            HeaderContainerStyle = (Style)FindResource("HeaderStyle"),
            Header = "Genre",
            DisplayMemberBinding = new Binding("genresToString")
        });
        ItemsGrid.Columns.Add(new GridViewColumn
        {
            HeaderContainerStyle = (Style)FindResource("HeaderStyle"),
            Header = "Artists",
            DisplayMemberBinding = new Binding("artistsToString")
        });

        ItemsGrid.Columns.Add(new GridViewColumn
        {
            HeaderContainerStyle = (Style)FindResource("HeaderStyle"),
            CellTemplate = (DataTemplate)this.Resources["AddToPlaylistButton"]
        });
    }

    public override void setViewContent()
    {
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

    protected override void filterContent()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            foreach (Songs s in db.SearchForSong(searchBar, session))
            {
                s.genres.ToString();
                s.artists.ToString();
                ItemsContainer.Items.Add(s);
            }
        }
    }

    protected override void SelectItem(object sender, SelectionChangedEventArgs e)
    {
        MainWindow window = (MainWindow)Application.Current.MainWindow;
        Songs s = (Songs)ItemsContainer.SelectedItem;
        SongDetails detail = new SongDetails(s.Id);
        MainView view = (MainView)window.MainFrame.Content;
        view.ActivityFrame.Navigate(detail);
    }

    
}

public class PlaylistDisplay : ItemsDisplay
{
    public PlaylistDisplay() : base()
    {
        DeleteButton.Visibility = Visibility.Visible;
        ItemsLabel.Content = "PLAYLIST";

        ItemsGrid.Columns.Add(new GridViewColumn
        {
            HeaderContainerStyle = (Style)FindResource("HeaderStyle"),
            Header = "Title",
            DisplayMemberBinding = new Binding("Title")
        });
        ItemsGrid.Columns.Add(new GridViewColumn
        {
            HeaderContainerStyle = (Style)FindResource("HeaderStyle"),
            Header = "Release date",
            DisplayMemberBinding = new Binding("Release_date")
        });
        ItemsGrid.Columns.Add(new GridViewColumn
        {
            HeaderContainerStyle = (Style)FindResource("HeaderStyle"),
            Header = "Duration",
            DisplayMemberBinding = new Binding("Duration")
        });
        ItemsGrid.Columns.Add(new GridViewColumn
        {
            HeaderContainerStyle = (Style)FindResource("HeaderStyle"),
            Header = "Genre",
            DisplayMemberBinding = new Binding("genresToString")
        });
        ItemsGrid.Columns.Add(new GridViewColumn
        {
            HeaderContainerStyle = (Style)FindResource("HeaderStyle"),
            Header = "Artists",
            DisplayMemberBinding = new Binding("artistsToString")
        });
    }

    public override void setViewContent()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            MainWindow view = (MainWindow)Application.Current.MainWindow;
            MainView view2 = (MainView)view.MainFrame.Content;
            Playlists pl = (Playlists)view2.PlaylistListBox.SelectedItem;
            if (pl.Name == "Your Favourites")
                DeleteButton.Visibility = Visibility.Hidden;
            foreach (Songs s in db.GetSongsFromPlaylist(pl, session))
            {
                s.genres.ToString();
                s.artists.ToString();

                ItemsContainer.Items.Add(s);
            }
        }
    }

    protected override void filterContent()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            MainView view = (MainView)window.MainFrame.Content;
            foreach (Songs s in db.GetSongsFromPlaylist((Playlists)view.PlaylistListBox.SelectedItem, session))
            {
                if (s.Title.Contains(searchBar))
                {
                    s.genres.ToString();
                    s.artists.ToString();
                    ItemsContainer.Items.Add(s);
                }

            }
        }
    }

    protected override void SelectItem(object sender, SelectionChangedEventArgs e)
    {
        MainWindow window = (MainWindow)Application.Current.MainWindow;
        Songs s = (Songs)ItemsContainer.SelectedItem;
        SongDetails detail = new SongDetails(s.Id);
        MainView view = (MainView)window.MainFrame.Content;
        view.ActivityFrame.Navigate(detail);
    }

    protected override void OnDeleteButtonClick(object sender, RoutedEventArgs e)
    {
        MainWindow window = (MainWindow)Application.Current.MainWindow;
        MainView view = (MainView)window.MainFrame.Content;
        Playlists playlist = (Playlists)view.PlaylistListBox.SelectedItem;
        using (var session=NHibernateHelper.OpenSession())
        {
           
            db.DeletePlaylist(playlist,session);
        }
        view.PlaylistListBox.Items.Remove(playlist);
        view.PlaylistListBox.SelectedItem = view.PlaylistListBox.Items.GetItemAt(0);
        

    }

    protected override void onUnloaded(object sender, RoutedEventArgs e)
    {
        MainWindow window = (MainWindow)Application.Current.MainWindow;
        MainView view = (MainView)window.MainFrame.Content;
        if (view.PlaylistListBox.IsMouseOver==false)
        {
            view.PlaylistListBox.SelectedIndex = -1;
        }
  
    }

}
