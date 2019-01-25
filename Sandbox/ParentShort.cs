using System;
using System.Linq.Expressions;

namespace Sandbox
{
    public class ParentShort
    {
        public int Id { get; set; }

        public string ChildName { get; set; }

        public int ItemsCount { get; set; }

        public static Expression<Func<Parent, ParentShort>> Projection
        {
            get
            {
                return x => new ParentShort
                {
                    Id = x.Id,
                    ChildName = x.ChildName,
                    ItemsCount = x.Items.Count
                };
            }
        }

        public static ParentShort FromEntity(Parent parent)
        {
            return Projection.Compile().Invoke(parent);
        }
    }
}
