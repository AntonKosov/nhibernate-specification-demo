namespace NHibernateSpecificationDemo.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Reflection;

    internal static class RepositoryFactory
    {
        static RepositoryFactory()
        {
            string databaseFileName = Path.Combine(Path.GetFullPath(".."), @"..\..\database.db3");
            Repository = new Repository(databaseFileName);
        }

        internal static Repository Repository { get; private set; }
    }
}
