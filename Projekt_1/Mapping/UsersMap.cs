using FluentNHibernate.Mapping;
using FluentNHibernate.Utils;
using Projekt_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Mapping
{
    class UsersMap : ClassMap<Users>
    {
        public UsersMap()
        {
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            Map(x => x.Username, "USERNAME");
            Map(x => x.Password, "PASSWORD");
            Map(x => x.Email, "EMAIL");
            HasMany(x => x.playlists).Inverse().KeyColumn("ID").Cascade.All();
            HasManyToMany(x => x.artists).Inverse().Table("USERS_FAVOURITES").ParentKeyColumn("USERS_ID").ChildKeyColumn("ARTISTS_ID").LazyLoad().Cascade.All();
            HasMany(x => x.comments).Inverse().KeyColumn("ID").Cascade.All();
            HasMany(x => x.ratings).Inverse().KeyColumn("USERS_ID").Cascade.All();
            Table("USERS");
        }
    }
}
