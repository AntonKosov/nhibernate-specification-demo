namespace NHibernateSpecificationDemo
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;

    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate.Linq;
    using NHibernate;
    using LinqSpecs;

    public sealed class Repository
    {
        private readonly ISession session;

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

            this.session = this.SessionFactory.OpenSession();
        }

        public ISessionFactory SessionFactory { get; set; }

        public IEnumerable<T> FindAll<T>(Specification<T> specification)
            where T : class
        {
            var query = this.GetQuery<T>(specification);
            return query.ToList();
        }

        private IQueryable<T> GetQuery<T>(Specification<T> specification)
            where T : class
        {
            return this.session.Query<T>().Where(specification.IsSatisfiedBy());
        }
    }
}
