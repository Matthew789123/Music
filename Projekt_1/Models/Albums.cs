using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Models
{
    class Albums
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime Release_date { get; set; }
        public virtual IList<Artists> artists { get; set; }
        public virtual IList<Songs> songs { get; set; }
    }
}
