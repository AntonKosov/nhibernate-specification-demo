using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernateSpecificationDemo
{
    public class Entity
    {
        public virtual int Id { get; private set; }

        public virtual int Value0 { get; set; }

        public virtual int Value1 { get; set; }
    }
}
