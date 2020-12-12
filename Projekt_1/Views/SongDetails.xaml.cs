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
using Projekt_1.Models;
using Projekt_1.NHibernate;
using Projekt_1.DAL;
using System.Threading;

namespace Projekt_1.Views
{
    /// <summary>
    /// Interaction logic for SongDetails.xaml
    /// </summary>
    public partial class SongDetails : Page
    {
        private Database db = Database.getInstanece();
        private Songs song;
        private Ratings ratingFromDb;
        public SongDetails(int song_id)
        {
            InitializeComponent();
            
            using(var session=NHibernateHelper.OpenSession())
            {
                Binding b = new Binding();
                b.Source=CommentTextBox;
                b.Path = new PropertyPath("Text.Length");
                b.Mode = BindingMode.OneWay;
                CharacterCount.SetBinding(TextBlock.TextProperty, b);
                song = db.GetSong(song_id, session);
                SongTitle.Content = song.Title;
                AlbumName.Content = song.Albums_Id?.Title;
                string s = "by ";
                foreach (Artists g in song.artists)
                {
                    s += g.Name + ", ";
                }
                ArtistName.Content = s.Substring(0, s.Length-2);
                if (song.genres.Count != 0)
                {
                    s = "";
                    foreach (Genres g in song.genres)
                    {
                        s += g.Name + ", ";
                    }

                    Genre.Content = s.Substring(0, s.Length - 2);
                }
                List<Ratings> r = db.GetSongRatings(song, session);
                NumberOfRatings.Text = "("+r.Count.ToString()+")";
                if(r.Count!=0)
                {
                    decimal score = 0;

                    foreach (Ratings rating in r)
                    {
                        score += rating.Value;
                    }
                    score /= r.Count;
                    AverageScore.Text = score.ToString("#.##");

                }
                List<Comments> comments = db.GetSongComments(song, session);
                if (comments.Count != 0)
                {
                    NoCommentsBlock.Visibility = Visibility.Collapsed;
                    foreach (Comments c in comments)
                    {
                        s = c.Users_Id.Username + " " + c.Post_date.ToString().Substring(0, 10) + "\n" + c.Content;
                        CommentsList.Items.Add(s);
                    }
                }

                ratingFromDb = db.GetYourRating(song, session);
                if (ratingFromDb != null)
                {
                   
                    switch (ratingFromDb.Value)
                    {
                        case (1):
                            Rating.CheckBox1.IsChecked = true;
                            break;
                        case (2):
                            Rating.CheckBox1.IsChecked = true;
                            Rating.CheckBox2.IsChecked = true;
                            break;
                        case (3):
                            Rating.CheckBox1.IsChecked = true;
                            Rating.CheckBox2.IsChecked = true;
                            Rating.CheckBox3.IsChecked = true;
                            break;
                        case (4):
                            Rating.CheckBox1.IsChecked = true;
                            Rating.CheckBox2.IsChecked = true;
                            Rating.CheckBox3.IsChecked = true;
                            Rating.CheckBox4.IsChecked = true;
                            break;
                        case (5):
                            Rating.CheckBox1.IsChecked = true;
                            Rating.CheckBox2.IsChecked = true;
                            Rating.CheckBox3.IsChecked = true;
                            Rating.CheckBox4.IsChecked = true;
                            Rating.CheckBox5.IsChecked = true;
                            break;
                    }
                }
               
                
            }
   
        }

        private void OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void PostComment(object sender, RoutedEventArgs e)
        {
            if(CommentTextBox.Text!="")
            {
                Comments comment;
                using (var session = NHibernateHelper.OpenSession())
                {
                    comment = new Comments();

                    comment.Content = CommentTextBox.Text;
                    comment.Post_date = DateTime.Now;
                    comment.Songs_Id = song;
                    db.AddNewComment(comment, session);
                }
                string s = comment.Users_Id.Username + " " + comment.Post_date.ToString().Substring(0, 10) + "\n" + comment.Content;
                CommentTextBox.Text = "";
                CommentsList.Items.Insert(0, s);
                NoCommentsBlock.Visibility = Visibility.Collapsed;
            }
            
        }


        private void SongRated(object sender, EventArgs e)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                List<Ratings> r = db.GetSongRatings(song, session);
                int countRatings = r.Count;
                decimal average = 0;
                decimal sum = 0;
                foreach (Ratings rating in r)
                {
                    sum += rating.Value;
                }
                int yourRating = 0;
                if (ratingFromDb==null)
                {
                    countRatings++;
                    NumberOfRatings.Text = "(" + countRatings.ToString() + ")";
                
                }
                else
                {
                    sum -= ratingFromDb.Value;
                }
                if (Rating.CheckBox5.IsChecked == true)
                    yourRating = 5;
                else if (Rating.CheckBox4.IsChecked == true)
                    yourRating = 4;
                else if (Rating.CheckBox3.IsChecked == true)
                    yourRating = 3;
                else if (Rating.CheckBox2.IsChecked == true)
                    yourRating = 2;
                else if (Rating.CheckBox1.IsChecked == true)
                    yourRating = 1;
                sum += yourRating;
                average = (sum ) / countRatings;

                AverageScore.Text = average.ToString("#.##");

                if (ratingFromDb == null)
                {
                    ratingFromDb = new Ratings();
                    ratingFromDb.Value = yourRating;
                    ratingFromDb.Songs_Id = song;
                    db.AddNewRating(ratingFromDb, session);
                }
                else
                {
                    ratingFromDb.Value = yourRating;
                    db.UpdateRating(ratingFromDb, session);
                }
            }

        }

        private void OnPlayButtonClick(object sender, RoutedEventArgs e)
        {
            List<Songs> s = new List<Songs>();
            s.Add(song);
            MainView.player.setSongs(s); 
        }
    }
}
