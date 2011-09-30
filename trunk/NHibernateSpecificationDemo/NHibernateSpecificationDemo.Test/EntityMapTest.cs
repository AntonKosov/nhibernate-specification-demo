namespace NHibernateSpecificationDemo.Test
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EntityMapTest
    {
        [TestMethod]
        public void MapTest()
        {
            using (var session = RepositoryFactory.Repository.SessionFactory.OpenSession())
            {
                var entity = new Entity();
                entity.Value0 = 1;
                entity.Value1 = 2;

                session.SaveOrUpdate(entity);
                session.Flush();

                var targetEntity = session.QueryOver<Entity>().Where(x => x.Id == entity.Id).SingleOrDefault();
                Assert.AreEqual(1, targetEntity.Value0);
                Assert.AreEqual(2, targetEntity.Value1);
            }
        }
    }
}
