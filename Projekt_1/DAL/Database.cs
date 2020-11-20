using Projekt_1.Models;
using Projekt_1.NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.DAL
{
    class Database
    {
        public static void AddNewUser()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                }
            }
        }
    }
}
