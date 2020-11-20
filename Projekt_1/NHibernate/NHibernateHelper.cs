using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt_1.DAL;
using NHibernate.Driver;
using NHibernate.Connection;

namespace Projekt_1.NHibernate
{
    class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    InitializeSessionFactory();
                }
                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure().Database(OracleDataClientConfiguration.Oracle10.ConnectionString(
                c => c.FromConnectionStringWithKey("DefaultConnection")).Provider<DriverConnectionProvider>().Driver<OracleManagedDataClientDriver>().ShowSql())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Database>())
                        .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
