using FluentNHibernate.Mapping;
using Projekt_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Mapping
{
    class CommentsMap : ClassMap<Comments>
    {
        public CommentsMap()
        {
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            Map(x => x.Content, "CONTENT");
            Map(x => x.Post_date, "POST_DATE");
            References(x => x.Users_Id).Column("USERS_ID");
            References(x => x.Songs_Id).Column("SONGS_ID");
            Table("COMMENTS");
        }
    }
}
