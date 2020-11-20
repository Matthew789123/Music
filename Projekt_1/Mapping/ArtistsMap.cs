using FluentNHibernate.Mapping;
using Projekt_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Mapping
{
    class ArtistsMap : ClassMap<Artists>
    {
        public ArtistsMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Name);
            HasManyToMany(x => x.users).Table("USERS_FAVOURITES").ParentKeyColumn("ARTISTS_ID").ChildKeyColumn("USERS_ID").LazyLoad().Cascade.All();
            HasManyToMany(x => x.albums).Table("ARTISTS_ALBUMS").ParentKeyColumn("ARTISTS_ID").ChildKeyColumn("ALBUMS_ID").LazyLoad().Cascade.All();
            HasManyToMany(x => x.songs).Table("ARTISTS_SONGS").ParentKeyColumn("ARTISTS_ID").ChildKeyColumn("SONGS_ID").LazyLoad().Cascade.All();
            Table("ARTISTS");
        }
    }
}
