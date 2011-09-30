namespace NHibernateSpecificationDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using LinqSpecs;

    public sealed class ValidValue0 : Specification<Entity>
    {
        private readonly int value;

        public ValidValue0(int value)
        {
            this.value = value;
        }

        public override System.Linq.Expressions.Expression<Func<Entity, bool>> IsSatisfiedBy()
        {
            return x => x.Value0 == this.value;
        }
    }
}
