using NHibernate;
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
        private static Database db;

        private Database() { }
        public static Database getInstanece()
        {
            if (db == null)
            {
                db = new Database();
            }
            return db;
        }


        public static void AddNewUser()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                }
            }
        }



        public List<T> GetAll<T>(ISession session) where T: class
        {
            
            if(typeof(T)==typeof(Songs))
            {
                session.QueryOver<Albums>().List();
            }
            List<T> list = (List<T>)session.QueryOver<T>().List();


            return list ;
        }

    }
}
