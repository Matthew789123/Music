using FluentNHibernate.Mapping;
using Projekt_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Mapping
{
    class SongsMap : ClassMap<Songs>
    {
        public SongsMap()
        {
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            Map(x => x.Title, "TITLE");
            Map(x => x.Release_date, "RELEASE_DATE");
            Map(x => x.Duration, "DURATION");
            Map(x => x.Song, "SONG");
            References(x => x.Albums_Id).Column("ALBUMS_ID");
            HasManyToMany(x => x.artists).Inverse().Table("ARTISTS_SONGS").ParentKeyColumn("SONGS_ID").ChildKeyColumn("ARTISTS_ID").LazyLoad().Cascade.All();
            HasManyToMany(x => x.playlists).Inverse().Table("PLAYLISTS_SONGS").ParentKeyColumn("SONGS_ID").ChildKeyColumn("PLAYLISTS_ID").LazyLoad();
            HasMany(x => x.comments).Inverse().KeyColumn("ID").Cascade.All();
            HasManyToMany(x => x.genres).Inverse().Table("SONGS_GENRES").ParentKeyColumn("SONGS_ID").ChildKeyColumn("GENRES_ID").LazyLoad().Cascade.All();
            HasMany(x => x.ratings).Inverse().KeyColumn("SONGS_ID").Cascade.All();
            Table("SONGS");
        }
    }
}
