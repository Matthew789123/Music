using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Models
{
    public class Playlists
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Users Users_Id { get; set; }
        public virtual IList<Songs> songs { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
