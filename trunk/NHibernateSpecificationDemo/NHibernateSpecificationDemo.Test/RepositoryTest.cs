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
                var entitiesFromDatabase = RepositoryFactory.Repository.FindAll(spec);

                Assert.IsTrue(entitiesFromDatabase.Any(x => x.Id == entity.Id));
            }
        }

        [TestMethod]
        public void LoadWithAndTest()
        {
            using (var session = RepositoryFactory.Repository.SessionFactory.OpenSession())
            {
                var entity = new Entity { Value0 = 11, Value1 = 12 };
                session.SaveOrUpdate(entity);
                session.Flush();

                var specValue0 = new ValidValue0(11);
                var specValue1 = new ValidValue1(12);
                var entitiesFromDatabase =
                    RepositoryFactory.Repository.FindAll(specValue0 & specValue1);

                Assert.IsTrue(entitiesFromDatabase.Any(x => x.Id == entity.Id));
            }
        }
    }
}
