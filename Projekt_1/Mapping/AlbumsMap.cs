using FluentNHibernate.Mapping;
using Projekt_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Mapping
{
    class AlbumsMap : ClassMap<Albums>
    {
        public AlbumsMap()
        {
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            Map(x => x.Title, "TITLE");
            Map(x => x.Release_date, "RELEASE_DATE");
            HasManyToMany(x => x.artists).Inverse().Table("ARTISTS_ALBUMS").ParentKeyColumn("ALBUMS_ID").ChildKeyColumn("ARTISTS_ID").LazyLoad().Cascade.All();
            HasMany(x => x.songs).Inverse().KeyColumn("ALBUMS_ID");
            Table("ALBUMS");
        }
    }
}
