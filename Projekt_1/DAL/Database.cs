using NHibernate;
using Projekt_1.Models;
using Projekt_1.NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.DAL
{
    public class Database
    {
        private static Database db;
        private Users loggedUser;

        private Database() { }
        public static Database getInstanece()
        {
            if (db == null)
            {
                db = new Database();
            }
            return db;
        }

        public List<Playlists> GetPlaylists(ISession session)
        {

            return (List<Playlists>) session.QueryOver<Playlists>().Where(x => x.Users_Id.Id == loggedUser.Id).List<Playlists>();

        }


        public Playlists AddNewPlaylist(string name, ISession session)
        {
            Playlists playlist;
            using (var transaction = session.BeginTransaction())
            {
                playlist = new Playlists();
                playlist.Name = name;
                playlist.Users_Id = loggedUser;
                session.Save(playlist);
                transaction.Commit();
            }
            return playlist;
        }


        public List<Songs> GetSongsFromPlaylist(Playlists playlist, ISession session)
        {
            List<Songs> list=new List<Songs>();
            foreach(Songs s in (List<Songs>)session.QueryOver<Songs>().List<Songs>())
            {
                foreach(Playlists p in s.playlists)
                {
                    if (p.Id==playlist.Id)
                    {
                        list.Add(s);
                    }
                }
            }
            return list;
        }

        public Boolean LogUserIn(string username, string password,ISession session)
        {
            Users user = session.QueryOver<Users>().Where(x => x.Username == username && x.Password == password).List<Users>().FirstOrDefault();
            if(user==null)
            {
               return false;
            }
            loggedUser = user;
            loggedUser.Password = "";
            return true;
        }

        public void AddNewUser(Users user,ISession session)
        {


            using (var transaction = session.BeginTransaction())
            {
                user.playlists = new List<Playlists>();
                Playlists playlist = new Playlists();
                playlist.Name = "Your Favourites";
                playlist.Users_Id = user;
                user.playlists.Add(playlist);
                session.Save(user);
                transaction.Commit();
            }

        }



        public Boolean usernameTaken(string username, ISession session)
        {
            if(session.QueryOver<Users>().Select(c=> c.Username).List<String>().Contains(username))
            {
                return true;
            }
            return false;
        }

        public Boolean emailTaken(string email, ISession session)
        {
            if (session.QueryOver<Users>().Select(c => c.Email).List<String>().Contains(email))
            {
                return true;
            }
            return false;
        }

        public List<T> GetAll<T>(ISession session) where T: class
        {
            
            if(typeof(T)==typeof(Songs))
            {
                session.QueryOver<Albums>().List();
            }
            List<T> list = (List<T>)session.QueryOver<T>().List();


            return list ;
        }

        public List<Songs> SearchForSong(string name, ISession session)
        {
            List<Songs> songs = new List<Songs>() ;
            foreach(Songs s in (List<Songs>)session.QueryOver<Songs>().List<Songs>())
            {
                if(s.Title.Contains(name))
                {
                    songs.Add(s);
                }
            }
            return songs;
        }

        public List<Artists> SearchForArtist(string name, ISession session)
        {
            List<Artists> artists = new List<Artists>();
            foreach (Artists a in (List<Artists>)session.QueryOver<Artists>().List<Artists>())
            {
                if (a.Name.Contains(name))
                {
                    artists.Add(a);
                }
            }
            return artists;
        }

        public List<Albums> SearchForAlbums(string name, ISession session)
        {
            List<Albums> albums = new List<Albums>();
            foreach (Albums a in (List<Albums>)session.QueryOver<Albums>().List<Albums>())
            {
                if (a.Title.Contains(name))
                {
                    albums.Add(a);
                }
            }
            return albums;
        }


        public void DeletePlaylist(Playlists playlist, ISession session)
        {
            using(var transaction=session.BeginTransaction())
            {
                session.Delete(playlist);
                transaction.Commit();
            }
            
        }

        public Songs GetSong(int id, ISession session)
        {
            return session.Get<Songs>(id);
        }

        public List<Ratings> GetSongRatings(Songs s, ISession session)
        {
            return (List<Ratings>)session.QueryOver<Ratings>().Where(x => x.Songs_Id == s).List<Ratings>();
        }

        public List<Comments> GetSongComments(Songs s, ISession session)
        {
            return (List<Comments>)session.QueryOver<Comments>().Where(x => x.Songs_Id == s).List<Comments>();
        }


        public void AddNewComment(Comments comment, ISession session)
        {
            using(var transaction=session.BeginTransaction())
            {
                comment.Users_Id = loggedUser;
                session.Save(comment);
                transaction.Commit();
            }
        }

        public Ratings GetYourRating(Songs s,ISession session)
        {
            return (Ratings)session.QueryOver<Ratings>().Where(x => x.Songs_Id == s && x.Users_Id == loggedUser).List<Ratings>().FirstOrDefault();
          
        }

        public void AddNewRating(Ratings r, ISession session)
        {
            using(var transaction=session.BeginTransaction())
            {
                r.Users_Id = loggedUser;
                session.Save(r);
                transaction.Commit();
            }
        }

        public void UpdateRating(Ratings r, ISession session)
        {
            using(var transaction = session.BeginTransaction())
            {
                session.Update(r);
                transaction.Commit();
            }
        }

        public void AddArtistToFavourites(Artists a, ISession session)
        {

            using (var transaction = session.BeginTransaction())
            {
                Users currentUser = session.Get<Users>(loggedUser.Id);
                Artists currentArtists = session.Get<Artists>(a.Id);
                currentArtists.users.Add(currentUser);
                currentUser.artists.Add(currentArtists);
                session.Save(currentUser);
                session.Save(currentArtists);
                transaction.Commit();

            }
        }

        public List<Artists> GetUserFavouritesArtists(ISession session)
        {
            Users currentUser = session.Get<Users>(loggedUser.Id);
            List<Artists> artists = new List<Artists>();
            foreach (Artists a in (List<Artists>)session.QueryOver<Artists>().List<Artists>())
            {
                if (currentUser.artists.Contains(a))
                {
                    artists.Add(a);
                }
            }
            return artists;
        }

        public void RemoveArtistFromFavourites(Artists a, ISession session)
        {  
            using (var transaction=session.BeginTransaction())
            {
                Users currentUser = session.Get<Users>(loggedUser.Id);
                Artists currentArtists = session.Get<Artists>(a.Id);
                currentArtists.users.Remove(currentUser);
                currentUser.artists.Remove(currentArtists);
                session.Save(currentUser);
                session.Save(currentArtists);
                transaction.Commit();
            }
        }
    }
}
