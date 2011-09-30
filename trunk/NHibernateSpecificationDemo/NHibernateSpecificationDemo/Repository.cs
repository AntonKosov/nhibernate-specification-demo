namespace NHibernateSpecificationDemo
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;

    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using LinqSpecs;

    public sealed class Repository
    {
        public Repository(string databaseFileName)
        {
            if (String.IsNullOrEmpty(databaseFileName))
            {
                throw new ArgumentNullException("databaseFileName");
            }

            this.SessionFactory = Fluently
                .Configure()
                .Database(SQLiteConfiguration.Standard.ConnectionString(String.Format("data source={0}", databaseFileName)).IsolationLevel(IsolationLevel.ReadCommitted))
                .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(Repository).Assembly))
                .BuildConfiguration()
                .BuildSessionFactory();
        }

        public ISessionFactory SessionFactory { get; set; }

        public IList<Entity> GetEntity(Specification<Entity> specification)
        {
            if (specification == null)
            {
                throw new ArgumentNullException("specification");
            }

            using (var session = this.SessionFactory.OpenSession())
            {
                var result = session.QueryOver<Entity>().Where(specification.IsSatisfiedBy()).List();
                return result;
            }
        }
    }
}
