using Projekt_1.DAL;
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

        public void setViewContent()
        {
            getFromDB();
        }

        protected abstract void getFromDB();

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

        protected abstract void onSearchButtonClick(object sender, RoutedEventArgs e);

        protected virtual void SelectItem(object sender, SelectionChangedEventArgs e) { }
    }
}

public class ArtistsDisplay : ItemsDisplay
{
    public ArtistsDisplay() : base()
    {
        var gridView = new GridView();
        this.ItemsContainer.View = gridView;
        ItemsLabel.Content = "ARTISTS";
        gridView.Columns.Add(new GridViewColumn
        {
            Header = "Name",
            DisplayMemberBinding = new Binding("Name")
        });
    }

    protected override void getFromDB()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            foreach (Artists a in db.GetAll<Artists>(session))
            {
                ItemsContainer.Items.Add(a);
            }
        }
    }

    protected override void onSearchButtonClick(object sender, RoutedEventArgs e)
    {
        SearchBar.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        ItemsContainer.Items.Clear();
        using (var session = NHibernateHelper.OpenSession())
        {
            foreach (Artists a in db.SearchForArtist(searchBar, session))
            {
                ItemsContainer.Items.Add(a);
            }
        }
    }
}

public class AlbumsDisplay : ItemsDisplay
{
    public AlbumsDisplay() : base()
    {
        var gridView = new GridView();
        this.ItemsContainer.View = gridView;
        ItemsLabel.Content = "ALBUMS";
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
    }

    protected override void getFromDB()
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

    protected override void onSearchButtonClick(object sender, RoutedEventArgs e)
    {
        SearchBar.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        ItemsContainer.Items.Clear();
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
        var gridView = new GridView();
        this.ItemsContainer.View = gridView;
        ItemsLabel.Content = "SONGS";
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

        gridView.Columns.Add(new GridViewColumn
        {
            CellTemplate = (DataTemplate)this.Resources["ListButton"]
        });
    }

    protected override void getFromDB()
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

    protected override void onSearchButtonClick(object sender, RoutedEventArgs e)
    {
        SearchBar.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        ItemsContainer.Items.Clear();
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
        SongDetails detail = new SongDetails();
        MainView view = (MainView)window.MainFrame.Content;
        view.ActivityFrame.Navigate(detail);
    }
}

public class PlaylistDisplay : ItemsDisplay
{
    public PlaylistDisplay() : base()
    {
        var gridView = new GridView();
        this.ItemsContainer.View = gridView;
        ItemsLabel.Content = "PLAYLIST";
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
    }

    protected override void getFromDB()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            MainWindow view = (MainWindow)Application.Current.MainWindow;
            MainView view2 = (MainView)view.MainFrame.Content;
            foreach (Songs s in db.GetSongsFromPlaylist((Playlists)view2.PlaylistListBox.SelectedItem, session))
            {
                s.genres.ToString();
                s.artists.ToString();

                ItemsContainer.Items.Add(s);
            }
        }
    }

    protected override void onSearchButtonClick(object sender, RoutedEventArgs e)
    {
        SearchBar.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        ItemsContainer.Items.Clear();
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
}
