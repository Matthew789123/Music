using FluentNHibernate.Mapping;
using Projekt_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Mapping
{
    class GenresMap : ClassMap<Genres>
    {
        public GenresMap()
        {
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            Map(x => x.Name, "NAME");
            HasManyToMany(x => x.songs).Table("SONGS_GENRES").ParentKeyColumn("GENRES_ID").ChildKeyColumn("SONGS_ID").LazyLoad().Cascade.All();
            Table("GENRES");
        }
    }
}
