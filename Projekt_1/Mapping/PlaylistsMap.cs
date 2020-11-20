using FluentNHibernate.Mapping;
using Projekt_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Mapping
{
    class PlaylistsMap : ClassMap<Playlists>
    {
        public PlaylistsMap()
        {
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            Map(x => x.Name, "NAME");
            References(x => x.Users_Id).Column("USERS_ID");
            HasManyToMany(x => x.songs).Table("PLAYLISTS_SONGS").ParentKeyColumn("PLAYLISTS_ID").ChildKeyColumn("SONGS_ID").LazyLoad();
            Table("PLAYLISTS");
        }
    }
}
