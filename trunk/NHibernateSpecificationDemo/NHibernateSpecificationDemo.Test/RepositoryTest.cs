using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NHibernateSpecificationDemo.Test
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void SimpleLoadTest()
        {
            using (var session = RepositoryFactory.Repository.SessionFactory.OpenSession())
            {
                var entity = new Entity { Value0 = 10 };
                session.SaveOrUpdate(entity);
                session.Flush();

                var spec = new ValidValue0(10);
                var entitiesFromDatabase = RepositoryFactory.Repository.GetEntity(spec);

                Assert.IsTrue(entitiesFromDatabase.Any(x => x.Id == entity.Id));
            }
        }
    }
}
