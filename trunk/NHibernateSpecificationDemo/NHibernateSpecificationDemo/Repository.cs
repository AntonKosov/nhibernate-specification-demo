namespace NHibernateSpecificationDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using System.Data;

    public sealed class Repository
    {
        public Repository(string databaseFileName)
        {
            this.SessionFactory = Fluently
                .Configure()
                .Database(SQLiteConfiguration.Standard.ConnectionString(String.Format("data source={0}", databaseFileName)).IsolationLevel(IsolationLevel.ReadCommitted))
                .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(Repository).Assembly))
                .BuildConfiguration()
                .BuildSessionFactory();
        }

        public ISessionFactory SessionFactory { get; set; }
    }
}
