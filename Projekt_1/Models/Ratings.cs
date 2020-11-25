using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Models
{
   public class Ratings
    {
        public virtual Users Users_Id { get; set; }
        public virtual Songs Songs_Id { get; set; }
        public virtual decimal Value { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var i = obj as Ratings;
            return ((i.Users_Id == this.Users_Id) && (i.Songs_Id == this.Songs_Id));
        }

        public override int GetHashCode()
        {
            return 9999;
        }
    }
}
