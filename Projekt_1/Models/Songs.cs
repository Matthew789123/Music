using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Models
{
    public class Songs
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime Release_date { get; set; }
        public virtual decimal Duration { get; set; }
        public virtual string Song { get; set; }
        public virtual Albums Albums_Id { get; set; }
        public virtual IList<Artists> artists { get; set; }
        public virtual IList<Playlists> playlists { get; set; } 
        public virtual IList<Comments> comments { get; set; }
        public virtual IList<Genres> genres { get; set; }
        public virtual IList<Ratings> ratings { get; set; }

        public  virtual string genresToString 
        {
            get 
            {
                string s="";
                foreach (Genres g in genres)
                {
                    s += g.Name+"\n";
                }
                return s;
            } 
        }

        public virtual string artistsToString
        {
            get
            {
                string s = "";
                foreach (Artists g in artists)
                {
                    s += g.Name + "\n";
                }
                return s;
            }
        }

    }
}
