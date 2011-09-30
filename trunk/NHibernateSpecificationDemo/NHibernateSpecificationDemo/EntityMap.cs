namespace NHibernateSpecificationDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using FluentNHibernate.Mapping;

    public sealed class EntityMap : ClassMap<Entity>
    {
        public EntityMap()
        {
            this.Table("Entity");

            this.Id(x => x.Id).GeneratedBy.Native();
            this.Map(x => x.Value0).Column("Value0");
            this.Map(x => x.Value1).Column("Value1");
        }
    }
}
