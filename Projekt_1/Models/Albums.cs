using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Models
{
    public class Albums
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime Release_date { get; set; }
        public virtual IList<Artists> artists { get; set; }
        public virtual IList<Songs> songs { get; set; }

        public virtual string artistsToString
        {
            get
            {
                string s = "";
                foreach (Artists g in artists)
                {
                    s += g.Name + "\n";
                }
                s = s.TrimEnd('\n');
                return s;
            }
        }

    }
}
