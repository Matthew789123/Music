using FluentNHibernate.Mapping;
using Projekt_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Mapping
{
    class RatingsMap : ClassMap<Ratings>
    {
        public RatingsMap()
        {
            CompositeId().KeyReference(x => x.Users_Id, "USERS_ID").KeyReference(x => x.Songs_Id, "SONGS_ID");
            Map(x => x.Value, "VALUE");
            Table("RATINGS");
        }
    }
}
