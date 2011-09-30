using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.IO;

namespace NHibernateSpecificationDemo.Test
{
    [TestClass]
    public class EntityMapTest
    {
        [TestMethod]
        public void MapTest()
        {
            string databaseFileName = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "database.db3");
            var repository = new Repository(databaseFileName);
            using (var session = repository.SessionFactory.OpenSession())
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
