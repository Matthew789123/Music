using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Models
{
    public class Comments
    {
        public virtual int Id { get; set; }
        public virtual string Content { get; set; }
        public virtual DateTime Post_date { get; set; }
        public virtual Users Users_Id { get; set; }
        public virtual Songs Songs_Id { get; set; }
    }
}
