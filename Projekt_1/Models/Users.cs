using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Models
{
   public class Users
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email {get; set;}
        public virtual IList<Playlists> playlists { get; set; }
        public virtual IList<Artists> artists { get; set; }
        public virtual IList<Comments> comments { get; set; }
        public virtual IList<Ratings> ratings { get; set; }
    }
}
